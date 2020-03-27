using System;
using System.IO;
using System.Collections.Generic;
using GlobalLib.Reflection.Abstract;



namespace GlobalLib.Database.Collection
{
	public class Root<TypeID> where TypeID : Collectable, new()
	{
		public Dictionary<string, TypeID> Classes { get; set; }
		public string ThisName { get; set; }
		public int Length { get => this.Classes.Count; }
		public int MaxCNameLength { get; }
		public int CNameOffsetAt { get; }
		public int BaseClassSize { get; }
		public bool Resizable { get; }
		private readonly bool importable = false;
		public BasicBase Database { get; set; }

		public Root(string name, int maxlength, int offsetat, int basesize, bool resizable, bool importable, BasicBase data)
		{
			this.Classes = new Dictionary<string, TypeID>();
			this.ThisName = name;
			this.MaxCNameLength = maxlength;
			this.CNameOffsetAt = offsetat;
			this.BaseClassSize = basesize;
			this.Resizable = resizable;
			this.importable = importable;
			this.Database = data;
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
			else return (string[])cla.GetAccessibles(eGetInfoType.PROPERTY_NAMES);
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
			TypeID instance = null;

			try
			{
				if (!this.Resizable) return false;
				if (string.IsNullOrWhiteSpace(value)) return false;
				if (this.MaxCNameLength != -1 && value.Length > this.MaxCNameLength) return false;
				if (this.Classes.ContainsKey(value)) return false;
				var ctor = typeof(TypeID).GetConstructor(new Type[] { typeof(string), this.Database.GetType() });
				instance = (TypeID)ctor.Invoke(new object[] { value, this.Database });
				this.Classes.Add(value, instance);
				return true;
			}
			catch (Exception)
			{
				instance = null;
				return false;
			}
		}
		public bool TryAddClass(string value, out string error)
		{
			TypeID instance = null;
			error = null;

			try
			{
				if (!this.Resizable)
				{
					error = "Class collection specified is non-resizable.";
					return false;
				}
				if (string.IsNullOrWhiteSpace(value))
				{
					error = "CollectionName cannot be empty or whitespace.";
					return false;
				}
				if (this.MaxCNameLength != -1 && value.Length > this.MaxCNameLength)
				{
					error = $"Length of the value passed should not exceed {MaxCNameLength} characters.";
					return false;
				}
				if (this.Classes.ContainsKey(value))
				{
					error = $"Class with CollectionName {value} already exists.";
					return false;
				}
				var ctor = typeof(TypeID).GetConstructor(new Type[] { typeof(string), this.Database.GetType() });
				instance = (TypeID)ctor.Invoke(new object[] { value, this.Database });
				this.Classes.Add(value, instance);
				return true;
			}
			catch (Exception e)
			{
				while (e.InnerException != null) e = e.InnerException;
				error = e.Message;
				instance = null;
				return false;
			}
		}

		public bool TryRemoveClass(string value)
		{
			if (!this.Resizable) return false;
			if (string.IsNullOrWhiteSpace(value)) return false;
			if (!this.Classes.TryGetValue(value, out var cla)) return false;
			if (!cla.Deletable) return false;
			bool done = this.Classes.Remove(value);
			if (done) this.ResortClasses();
			return done;
		}
		public bool TryRemoveClass(string value, out string error)
		{
			error = null;
			if (!this.Resizable)
			{
				error = "Class collection specified is non-resizable.";
				return false;
			}
			if (string.IsNullOrWhiteSpace(value))
			{
				error = "Class with empty or whitespace CollectionName does not exist.";
				return false;
			}
			if (!this.Classes.TryGetValue(value, out var cla))
			{
				error = $"Class with CollectionName {value} does not exist.";
				return false;
			}
			if (!cla.Deletable)
			{
				error = $"This collection cannot be deleted because it is important to the game.";
				return false;
			}
			bool done = this.Classes.Remove(value);
			if (done) this.ResortClasses();
			else error = $"Unable to remove class with CollectionName {value}.";
			return done;
		}

		public bool TryCloneClass(string value, string copyfrom)
		{
			TypeID instance = null;

			try
			{
				if (!this.Resizable) return false;
				if (string.IsNullOrWhiteSpace(value)) return false;
				if (this.MaxCNameLength != -1 && value.Length > this.MaxCNameLength) return false;
				if (this.Classes.ContainsKey(value)) return false;
				if (!this.Classes.TryGetValue(copyfrom, out var cla)) return false;

				instance = (TypeID)cla.MemoryCast(value);
				this.Classes.Add(value, instance);
				return true;
			}
			catch (Exception)
			{
				instance = null;
				return false;
			}
		}
		public bool TryCloneClass(string value, string copyfrom, out string error)
		{
			TypeID instance = null;
			error = null;

			try
			{
				if (!this.Resizable)
				{
					error = "Class collection specified is non-resizable.";
					return false;
				}
				if (string.IsNullOrWhiteSpace(value))
				{
					error = "CollectionName cannot be empty or whitespace.";
					return false;
				}
				if (this.MaxCNameLength != -1 && value.Length > this.MaxCNameLength)
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

				instance = (TypeID)cla.MemoryCast(value);
				this.Classes.Add(value, instance);
				return true;
			}
			catch (Exception e)
			{
				while (e.InnerException != null) e = e.InnerException;
				error = e.Message;
				instance = null;
				return false;
			}
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

				var ctor = typeof(TypeID).GetConstructor(new Type[] { typeof(IntPtr), typeof(string), this.Database.GetType() });
				var instance = (TypeID)ctor.Invoke(new object[] { (IntPtr)dataptr_t, CName, this.Database });
				this.Classes.Add(CName, instance);
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

				var ctor = typeof(TypeID).GetConstructor(new Type[] { typeof(IntPtr), typeof(string), this.Database.GetType() });
				var instance = (TypeID)ctor.Invoke(new object[] { (IntPtr)dataptr_t, CName, this.Database });
				this.Classes.Add(CName, instance);
			}
			return true;
		}

		public bool TryExportClass(string value, string filepath)
		{
			if (!this.importable) return false;
			if (string.IsNullOrWhiteSpace(value)) return false;
			if (!this.Classes.TryGetValue(value, out var cla)) return false;
			if (!Directory.Exists(Path.GetDirectoryName(filepath))) return false;

			var arr = (byte[])cla.GetType()
				.GetMethod("Assemble").Invoke(cla, new object[0] { });

			using (var bw = new BinaryWriter(File.Open(filepath, FileMode.Create)))
			{
				bw.Write(arr);
			}
			return true;
		}
		public bool TryExportClass(string value, string filepath, out string error)
		{
			error = null;
			if (!this.importable)
			{
				error = "Class collection specified is not exportable.";
				return false;
			}
			if (string.IsNullOrWhiteSpace(value))
			{
				error = "CollectionName cannot be empty or whitespace.";
				return false;
			}
			if (!this.Classes.TryGetValue(value, out var cla))
			{
				error = $"Class with CollectionName {value} does not exist.";
				return false;
			}
			if (!Directory.Exists(Path.GetDirectoryName(filepath)))
			{
				error = $"Directory of the file path {filepath} specified does not exist.";
				return false;
			}
			var arr = (byte[])cla.GetType().GetMethod("Assemble").Invoke(cla, new object[0] { });

			using (var bw = new BinaryWriter(File.Open(filepath, FileMode.Create)))
			{
				bw.Write(arr);
			}
			return true;
		}

		public Dictionary<string, CollectionAttrib> GetAttributeMap()
		{
			var map = new Dictionary<string, CollectionAttrib>();
			foreach (var Class in this.Classes)
			{
				string path = $"{this.ThisName}\\{Class.Key}";
				var properties = Class.Value.GetAccessibles(eGetInfoType.PROPERTY_INFOS);
				foreach (var property in properties)
				{
					var attrib = new CollectionAttrib((System.Reflection.PropertyInfo)property, Class.Value);
					string subpath = $"{path}\\{attrib.PropertyName}";
					attrib.FullPath = subpath;
					attrib.Directory = path;
					map[subpath] = attrib;
				}

				var nodes = Class.Value.GetAllNodes();
				foreach (var node in nodes)
				{
					if (node.SubNodes == null) continue;
					foreach (var subnode in node.SubNodes)
					{
						var name = Class.Value.GetType().GetProperty(subnode.NodeName).GetValue(Class.Value);
						var attribs = Class.Value.GetSubnodeAttribs(subnode.NodeName, eGetInfoType.PROPERTY_INFOS);
						foreach (var attrib in attribs)
						{
							var field = new CollectionAttrib((System.Reflection.PropertyInfo)attrib, name);
							string subpath = $"{path}\\{node.NodeName}\\{subnode.NodeName}\\{field.PropertyName}";
							field.FullPath = subpath;
							map[subpath] = field;
						}
					}
				}

			}
			return map;
		}
		public List<VirtualNode> GetAllNodes()
		{
			var list = new List<VirtualNode>(this.Length);
			foreach (var cla in this.Classes)
			{
				var node = new VirtualNode(cla.Key);
				node.SubNodes = cla.Value.GetAllNodes();
				list.Add(node);
			}
			return list;
		}
		private void ResortClasses()
		{
			var newdict = new Dictionary<string, TypeID>(this.Length);
			foreach (var Class in this.Classes)
				newdict.Add(Class.Key, Class.Value);
			this.Classes = null; // for GC
			this.Classes = newdict;
			GC.Collect(0, GCCollectionMode.Forced);
			GC.Collect(1, GCCollectionMode.Forced);
			GC.Collect(2, GCCollectionMode.Forced);
		}

		public override string ToString()
		{
			return $"Collection: {this.ThisName} | Count = {this.Length}";
		}
	}
}
