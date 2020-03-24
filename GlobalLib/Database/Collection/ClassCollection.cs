using System;
using System.Collections.Generic;
using GlobalLib.Reflection.Abstract;



namespace GlobalLib.Database.Collection
{
	public class Binary<TypeID> where TypeID : Collectable, new()
	{
		public Dictionary<string, TypeID> Classes { get; set; }
		public string ThisName { get; set; }
		public int Length { get => this.Classes.Count; }
		public int MaxCNameLength { get; }
		public int CNameOffsetAt { get; }
		public int BaseClassSize { get; }
		private readonly bool importable = false;
		public BasicBase Database { get; set; }

		public Binary(string name, int maxlength, int offsetat, int basesize, bool importable)
		{
			this.Classes = new Dictionary<string, TypeID>();
			this.ThisName = name;
			this.MaxCNameLength = maxlength;
			this.CNameOffsetAt = offsetat;
			this.BaseClassSize = basesize;
			this.importable = importable;
		}

		public TypeID FindClass(string CName)
		{
			return this.Classes.TryGetValue(CName ?? string.Empty, out var result) ? result : null;
		}
		public TypeID FindClass(uint key, eKeyType type)
		{
			switch (type)
			{
				case eKeyType.BINKEY:
					foreach (var bin in this.Classes.Values)
						if (Utils.Bin.SmartHash(bin.CollectionName) == key)
							return bin;
					goto default;

				case eKeyType.VLTKEY:
					foreach (var vlt in this.Classes.Values)
						if (Utils.Bin.SmartHash(vlt.CollectionName) == key)
							return vlt;
					goto default;

				case eKeyType.CUSTOM:
					throw new NotImplementedException();
				default:
					return null;
			}
		}
		public TypeID FindClassWithValue(string field, object value)
		{
			try
			{
				foreach (var obj in this.Classes.Values)
				{
					if (obj.GetType().GetProperty(field).GetValue(obj) == value)
						return obj;
				}
				return null;
			}
			catch (Exception)
			{
				return null;
			}
		}

		public string[] GetAccessibleProperties(string CName)
		{
			if (!this.Classes.TryGetValue(CName, out var cla)) return null;
			else return cla.GetAccessibles();
		}

		public bool TrySetClassValue(params string[] tokens)
		{
			switch (tokens.Length)
			{
				case 3:
					return this.FindClass(tokens[0]).SetValue(tokens[1], tokens[2]);
				case 5:
					return this.FindClass(tokens[0]).SetValueOfInternalObject(tokens[1], tokens[2], tokens[3], tokens[4]);
				default:
					return false;
			}
		}
		public bool TrySetClassValue(ref string error, params string[] tokens)
		{
			switch (tokens.Length)
			{
				case 3:
					return this.FindClass(tokens[0]).SetValue(tokens[1], tokens[2], ref error);
				case 5:
					return this.FindClass(tokens[0]).SetValueOfInternalObject(ref error, tokens[1], tokens[2], tokens[3], tokens[4]);
				default:
					error = $"Invalid amount of parameters passed";
					return false;
			}
		}
		public bool TrySetStaticValue(params string[] tokens)
		{
			switch (tokens.Length)
			{
				case 3:
					return this.FindClass(tokens[0]).SetStaticValue(tokens[1], tokens[2]);
				default:
					return false;
			}
		}

		public bool TryAddClass(string value)
		{
			if (string.IsNullOrWhiteSpace(value)) return false;
			if (value.Length > MaxCNameLength) return false;
			if (this.Classes.ContainsKey(value)) return false;
			var ctor = typeof(TypeID).GetConstructor(new Type[] { typeof(string), typeof(BasicBase) });
			var instance = (TypeID)ctor.Invoke(new object[] { value, this.Database });
			this.Classes[value] = instance;
			return true;
		}
		public bool TryAddClass(string value, out string error)
		{
			error = null;
			if (string.IsNullOrWhiteSpace(value))
			{
				error = "CollectionName cannot be empty or whitespace.";
				return false;
			}
			if (value.Length >= MaxCNameLength)
			{
				error = $"Length of the value passed should not exceed {MaxCNameLength} characters.";
				return false;
			}
			if (this.Classes.ContainsKey(value))
			{
				error = $"Class with CollectionName {value} already exists.";
				return false;
			}
			var ctor = typeof(TypeID).GetConstructor(new Type[] { typeof(string), typeof(BasicBase) });
			var instance = (TypeID)ctor.Invoke(new object[] { value, this.Database });
			this.Classes[value] = instance;
			return true;
		}

		public bool TryRemoveClass(string value)
		{
			if (string.IsNullOrWhiteSpace(value)) return false;
			return this.Classes.Remove(value);
		}
		public bool TryRemoveClass(string value, out string error)
		{
			error = null;
			if (string.IsNullOrWhiteSpace(value))
			{
				error = "Class with empty or whitespace CollectionName does not exist.";
				return false;
			}
			bool done = this.Classes.Remove(value);
			if (!done) error = $"Class with CollectionName {value} does not exist.";
			return done;
		}

		public bool TryCloneClass(string value, string copyfrom)
		{
			if (string.IsNullOrWhiteSpace(value)) return false;
			if (value.Length > MaxCNameLength) return false;
			if (this.Classes.ContainsKey(value)) return false;
			if (!this.Classes.TryGetValue(copyfrom, out var cla)) return false;

			var copy = cla.MemoryCast(value);
			this.Classes[value] = (TypeID)copy;
			return true;
		}
		public bool TryCloneClass(string value, string copyfrom, out string error)
		{
			error = null;
			if (string.IsNullOrWhiteSpace(value))
			{
				error = "CollectionName cannot be empty or whitespace.";
				return false;
			}
			if (value.Length > MaxCNameLength)
			{
				error = $"Length of the value passed should not exceed {MaxCNameLength} characters.";
				return false;
			}
			if (this.Classes.ContainsKey(value))
			{
				error = $"Class with CollectionName {value} already exists.";
				return false;
			}
			if (!this.Classes.TryGetValue(copyfrom, out var cla))
			{
				error = $"Class with CollectionName {copyfrom} does not exist.";
				return false;
			}

			var copy = cla.MemoryCast(value);
			this.Classes[value] = (TypeID)copy;
			return true;
		}

		public unsafe bool TryImportClass(byte[] data)
		{
			if (!this.importable) return false;
			if (data.Length != this.BaseClassSize) return false;
			
			string CName = string.Empty;
			fixed (byte* dataptr_t = &data[0])
			{
				CName = Utils.ScriptX.NullTerminatedString(dataptr_t);
				if (this.Classes.ContainsKey(CName)) return false;

				var ctor = typeof(TypeID).GetConstructor(new Type[] { typeof(byte).MakePointerType(), typeof(string), typeof(BasicBase) });
				var instance = (TypeID)ctor.Invoke(new object[] { (IntPtr)dataptr_t, CName, this.Database });
				this.Classes[CName] = instance;
			}
			return true;
		}
		public unsafe bool TryImportClass(byte[] data, out string error)
		{
			error = null;
			if (!this.importable)
			{
				error = "Class collection specified is not importable.";
				return false;
			}
			if (data.Length != this.BaseClassSize)
			{
				error = $"Size of the class imported is {data.Length} bytes, while should be {this.BaseClassSize} bytes.";
				return false;
			}

			string CName = string.Empty;
			fixed (byte* dataptr_t = &data[0])
			{
				CName = Utils.ScriptX.NullTerminatedString(dataptr_t);
				if (this.Classes.ContainsKey(CName))
				{
					error = $"Class with CollectionName {CName} already exists.";
					return false;
				}

				var ctor = typeof(TypeID).GetConstructor(new Type[] { typeof(byte).MakePointerType(), typeof(string), typeof(BasicBase) });
				var instance = (TypeID)ctor.Invoke(new object[] { (IntPtr)dataptr_t, CName, this.Database });
				this.Classes[CName] = instance;
			}
			return true;
		}

		public override string ToString()
		{
			return $"Collection: {this.ThisName} | Count = {this.Length}";
		}
	}
}
