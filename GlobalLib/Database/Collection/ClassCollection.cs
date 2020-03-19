using System;
using System.Collections.Generic;



namespace GlobalLib.Database.Collection
{
	public class ClassCollection<TypeID> where TypeID : Reflection.Abstract.Collectable 
	{
		public List<TypeID> Classes { get; set; }
		public int Length { get => this.Classes.Count; }

		public ClassCollection()
		{
			this.Classes = new List<TypeID>();
		}

		public int GetClassIndex(string CName)
		{
			for (int a1 = 0; a1 < this.Classes.Count; ++a1)
			{
				if (this.Classes[a1].CollectionName == CName)
					return a1;
			}
			return -1;
		}
		public int GetClassIndex(uint key, eKeyType type)
		{
			for (int a1 = 0; a1 < this.Classes.Count; ++a1)
			{
				switch (type)
				{
					case eKeyType.BINKEY:
						if (Utils.Bin.Hash(this.Classes[a1].CollectionName) == key)
							return a1;
						continue;
					case eKeyType.VLTKEY:
						if (Utils.Vlt.Hash(this.Classes[a1].CollectionName) == key)
							return a1;
						continue;
					case eKeyType.CUSTOM:
						throw new NotImplementedException("No custom hashing method is available.");
					default:
						return -1;
				}
			}
			return -1;
		}

		public TypeID FindClass(string CName)
		{
			return this.Classes.Find(c => c.CollectionName == CName);
		}
		public TypeID FindClass(uint key, eKeyType type)
		{
			switch (type)
			{
				case eKeyType.BINKEY:
					return this.Classes.Find(c => Utils.Bin.Hash(c.CollectionName) == key);
				case eKeyType.VLTKEY:
					return this.Classes.Find(c => Utils.Vlt.Hash(c.CollectionName) == key);
				case eKeyType.CUSTOM:
					throw new NotImplementedException();
				default:
					return null;
			}
		}

		public string[] GetAccessibleProperties(string CName)
		{
			int index = this.GetClassIndex(CName);
			if (index == -1) return null;
			else return this.Classes[index].GetAccessibles();
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

		public override string ToString()
		{
			return $"Count = {this.Length}";
		}
	}
}
