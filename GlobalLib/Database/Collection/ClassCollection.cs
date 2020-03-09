﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalLib.Database.Collection
{
	public class ClassCollection<TypeID> where TypeID : Reflection.Abstract.ICollectable 
	{
		public List<TypeID> Classes { get; set; }

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
		public int GetClassIndex(uint key, KeyType type)
		{
			for (int a1 = 0; a1 < this.Classes.Count; ++a1)
			{
				switch (type)
				{
					case KeyType.BINKEY:
						if (Utils.Bin.Hash(this.Classes[a1].CollectionName) == key)
							return a1;
						continue;
					case KeyType.VLTKEY:
						if (Utils.Vlt.Hash(this.Classes[a1].CollectionName) == key)
							return a1;
						continue;
					case KeyType.CUSTOM:
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
		public TypeID FindClass(uint key, KeyType type)
		{
			switch (type)
			{
				case KeyType.BINKEY:
					return this.Classes.Find(c => Utils.Bin.Hash(c.CollectionName) == key);
				case KeyType.VLTKEY:
					return this.Classes.Find(c => Utils.Vlt.Hash(c.CollectionName) == key);
				case KeyType.CUSTOM:
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

		public override string ToString()
		{
			return base.ToString();
		}
	}
}
