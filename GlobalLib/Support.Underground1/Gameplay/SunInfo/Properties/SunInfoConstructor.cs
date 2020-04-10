using GlobalLib.Core;
using GlobalLib.Reflection.Abstract;
using GlobalLib.Support.Underground1.Parts.GameParts;
using GlobalLib.Utils;
using System;

namespace GlobalLib.Support.Underground1.Gameplay
{
	public partial class SunInfo : Collectable
	{
		// Default constructor
		public SunInfo() { }

		// Default constructor: create new suninfo
		public SunInfo(string CName, Database.Underground1 db)
		{
			this.Database = db;
			this.CollectionName = CName;
			this.SUNLAYER1 = new SunLayer();
			this.SUNLAYER2 = new SunLayer();
			this.SUNLAYER3 = new SunLayer();
			this.SUNLAYER4 = new SunLayer();
			this.SUNLAYER5 = new SunLayer();
			this.SUNLAYER6 = new SunLayer();
			Map.BinKeys[Bin.Hash(CName)] = CName;
		}

		// Default constructor: disassemble suninfo
		public unsafe SunInfo(IntPtr byteptr_t, string CName, Database.Underground1 db)
		{
			this.Database = db;
			this._collection_name = CName;
			this.SUNLAYER1 = new SunLayer();
			this.SUNLAYER2 = new SunLayer();
			this.SUNLAYER3 = new SunLayer();
			this.SUNLAYER4 = new SunLayer();
			this.SUNLAYER5 = new SunLayer();
			this.SUNLAYER6 = new SunLayer();
			this.Disassemble((byte*)byteptr_t);
		}

		~SunInfo() { }
	}
}