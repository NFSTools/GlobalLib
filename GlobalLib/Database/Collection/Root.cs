using System;
using System.IO;
using System.Collections.Generic;
using GlobalLib.Reflection.Abstract;



namespace GlobalLib.Database.Collection
{
	public class Root<TypeID> where TypeID : Collectable, new()
	{
		public List<TypeID> Collections { get; set; }
		public string ThisName { get; set; }
		public int Length { get => this.Collections.Count; }
		public int MaxCNameLength { get; }
		public int CNameOffsetAt { get; }
		public int BaseClassSize { get; }
		public bool Resizable { get; }
		private readonly bool importable = false;
		public BasicBase Database { get; set; }

		public Root(string name, int maxlength, int offsetat, int basesize, bool resizable, bool importable, BasicBase data)
		{
			this.Collections = new List<TypeID>();
			this.ThisName = name;
			this.MaxCNameLength = maxlength;
			this.CNameOffsetAt = offsetat;
			this.BaseClassSize = basesize;
			this.Resizable = resizable;
			this.importable = importable;
			this.Database = data;
		}

		public TypeID this[string CName] => this.FindCollection(CName);

		public bool TryGetCollectionIndex(string CName, out int index)
		{
			for (index = 0; index < this.Length; ++index)
			{
				if (this.Collections[index].CollectionName == CName)
					return true;
			}
			index = -1;
			return false;
		}
		public TypeID FindCollection(string CName)
		{
			return this.Collections.Find(c => c.CollectionName == (CName ?? string.Empty));
		}
		public TypeID FindCollection(uint key, eKeyType type)
		{
			switch (type)
			{
				case eKeyType.BINKEY:
					foreach (var bin in this.Collections)
						if (Utils.Bin.SmartHash(bin.CollectionName) == key)
							return bin;
					goto default;

				case eKeyType.VLTKEY:
					foreach (var vlt in this.Collections)
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
				foreach (var obj in this.Collections)
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
		public bool TryGetCollection(string CName, out TypeID collection)
		{
			collection = this.FindCollection(CName);
			if (collection != null) return true;
			else return false;
		}

		public object[] GetAccessibleProperties(string CName)
		{
			if (!this.TryGetCollection(CName, out var cla)) return null;
			else return cla.GetAccessibles(eGetInfoType.PROPERTY_NAMES);
		}

		public bool TrySetClassValue(params string[] tokens)
		{
			switch (tokens.Length)
			{
				case 3:
					return this.FindCollection(tokens[0]).SetValue(tokens[1], tokens[2]);
				case 5:
					return this.FindCollection(tokens[0]).SetValueOfInternalObject(tokens[1], tokens[2], tokens[3], tokens[4]);
				default:
					return false;
			}
		}
		public bool TrySetClassValue(ref string error, params string[] tokens)
		{
			switch (tokens.Length)
			{
				case 3:
					return this.FindCollection(tokens[0]).SetValue(tokens[1], tokens[2], ref error);
				case 5:
					return this.FindCollection(tokens[0]).SetValueOfInternalObject(ref error, tokens[1], tokens[2], tokens[3], tokens[4]);
				default:
					error = $"Invalid amount of parameters passed";
					return false;
			}
		}
		public bool TrySetStaticValue(string field, string value)
		{
			// Works only for Collectable and StaticModifiable properties
			var property = typeof(TypeID).GetProperty(field);
			if (property == null) return false;
			if (!Attribute.IsDefined(property, typeof(Reflection.Attributes.StaticModifiableAttribute)))
				return false;

			foreach (var collection in this.Collections)
			{
				bool pass = collection.SetValue(field, value);
				if (!pass) return false;
			}
			return true;
		}
		public bool TrySetStaticValue(string field, string value, out string error)
		{
			error = null;
			var property = typeof(TypeID).GetProperty(field);
			if (property == null)
			{
				error = $"Field named {field} does not exist.";
				return false;
			}
			if (!Attribute.IsDefined(property, typeof(Reflection.Attributes.StaticModifiableAttribute)))
			{
				error = $"Field named {field} is not a static-modifiable field.";
				return false;
			}
			foreach (var collection in this.Collections)
			{
				bool pass = collection.SetValue(field, value, ref error);
				if (!pass) return false;
			}
			return true;
		}

		public bool TryAddCollection(string value)
		{
			TypeID instance = null;

			try
			{
				if (!this.Resizable) return false;
				if (string.IsNullOrWhiteSpace(value)) return false;
				if (this.MaxCNameLength != -1 && value.Length > this.MaxCNameLength) return false;
				if (this.FindCollection(value) != null) return false;
				var ctor = typeof(TypeID).GetConstructor(new Type[] { typeof(string), this.Database.GetType() });
				instance = (TypeID)ctor.Invoke(new object[] { value, this.Database });
				this.Collections.Add(instance);
				return true;
			}
			catch (Exception)
			{
				instance = null;
				return false;
			}
		}
		public bool TryAddCollection(string value, out string error)
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
				if (this.FindCollection(value) != null)
				{
					error = $"Class with CollectionName {value} already exists.";
					return false;
				}
				var ctor = typeof(TypeID).GetConstructor(new Type[] { typeof(string), this.Database.GetType() });
				instance = (TypeID)ctor.Invoke(new object[] { value, this.Database });
				this.Collections.Add(instance);
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

		public bool TryRemoveCollection(string value)
		{
			if (!this.Resizable) return false;
			if (string.IsNullOrWhiteSpace(value)) return false;
			if (!this.TryGetCollection(value, out var cla)) return false;
			if (!cla.Deletable) return false;
			return this.Collections.Remove(cla);
		}
		public bool TryRemoveCollection(string value, out string error)
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
			if (!this.TryGetCollection(value, out var cla))
			{
				error = $"Class with CollectionName {value} does not exist.";
				return false;
			}
			if (!cla.Deletable)
			{
				error = $"This collection cannot be deleted because it is important to the game.";
				return false;
			}
			bool done = this.Collections.Remove(cla);
			if (!done) error = $"Unable to remove class with CollectionName {value}.";
			return done;
		}

		public bool TryCloneCollection(string value, string copyfrom)
		{
			TypeID instance = null;

			try
			{
				if (!this.Resizable) return false;
				if (string.IsNullOrWhiteSpace(value)) return false;
				if (this.MaxCNameLength != -1 && value.Length > this.MaxCNameLength) return false;
				if (this.FindCollection(value) != null) return false;
				if (!this.TryGetCollection(copyfrom, out var cla)) return false;

				instance = (TypeID)cla.MemoryCast(value);
				this.Collections.Add(instance);
				return true;
			}
			catch (Exception)
			{
				instance = null;
				return false;
			}
		}
		public bool TryCloneCollection(string value, string copyfrom, out string error)
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
				if (this.FindCollection(value) != null)
				{
					error = $"Class with CollectionName {value} already exists.";
					return false;
				}
				if (!this.TryGetCollection(copyfrom, out var cla))
				{
					error = $"Class with CollectionName {copyfrom} does not exist.";
					return false;
				}

				instance = (TypeID)cla.MemoryCast(value);
				this.Collections.Add(instance);
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

		public unsafe bool TryImportCollection(byte[] data)
		{
			if (!this.importable) return false;
			if (data.Length != this.BaseClassSize) return false;
			
			string CName = string.Empty;
			fixed (byte* dataptr_t = &data[0])
			{
				CName = Utils.ScriptX.NullTerminatedString(dataptr_t);
				if (this.FindCollection(CName) != null) return false;

				var ctor = typeof(TypeID).GetConstructor(new Type[] { typeof(IntPtr), typeof(string), this.Database.GetType() });
				var instance = (TypeID)ctor.Invoke(new object[] { (IntPtr)dataptr_t, CName, this.Database });
				this.Collections.Add(instance);
			}
			return true;
		}
		public unsafe bool TryImportCollection(byte[] data, out string error)
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
				if (this.FindCollection(CName) != null)
				{
					error = $"Class with CollectionName {CName} already exists.";
					return false;
				}

				var ctor = typeof(TypeID).GetConstructor(new Type[] { typeof(IntPtr), typeof(string), this.Database.GetType() });
				var instance = (TypeID)ctor.Invoke(new object[] { (IntPtr)dataptr_t, CName, this.Database });
				this.Collections.Add(instance);
			}
			return true;
		}

		public bool TryExportCollection(string value, string filepath)
		{
			if (!this.importable) return false;
			if (string.IsNullOrWhiteSpace(value)) return false;
			if (!this.TryGetCollection(value, out var cla)) return false;
			if (!Directory.Exists(Path.GetDirectoryName(filepath))) return false;

			var arr = (byte[])cla.GetType()
				.GetMethod("Assemble").Invoke(cla, new object[0] { });

			using (var bw = new BinaryWriter(File.Open(filepath, FileMode.Create)))
			{
				bw.Write(arr);
			}
			return true;
		}
		public bool TryExportCollection(string value, string filepath, out string error)
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
			if (!this.TryGetCollection(value, out var cla))
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
			foreach (var Class in this.Collections)
			{
				string path = $"{this.ThisName}\\{Class.CollectionName}";
				var properties = Class.GetAccessibles(eGetInfoType.PROPERTY_INFOS);
				foreach (var property in properties)
				{
					var attrib = new CollectionAttrib((System.Reflection.PropertyInfo)property, Class);
					string subpath = $"{path}\\{attrib.PropertyName}";
					attrib.FullPath = subpath;
					attrib.Directory = path;
					map[subpath] = attrib;
				}

				var nodes = Class.GetAllNodes();
				foreach (var node in nodes)
				{
					if (node.SubNodes == null) continue;
					foreach (var subnode in node.SubNodes)
					{
						var name = Class.GetType().GetProperty(subnode.NodeName).GetValue(Class);
						var attribs = Class.GetSubnodeAttribs(subnode.NodeName, eGetInfoType.PROPERTY_INFOS);
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
			foreach (var cla in this.Collections)
			{
				var node = new VirtualNode(cla.CollectionName);
				node.SubNodes = cla.GetAllNodes();
				list.Add(node);
			}
			return list;
		}

		public override string ToString()
		{
			return $"Collection: {this.ThisName} | Count = {this.Length}";
		}
	}
}
