namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class SunInfo : Reflection.Abstract.ICollectable, Reflection.Interface.ICastable<SunInfo>
	{
		// Default constructor
		public SunInfo() { }

		// Default constructor: create new suninfo
		public SunInfo(string CName, Database.Underground2 db)
		{
			this.Database = db;
			this._collection_name = CName;
			this.SUNLAYER1 = new Parts.GameParts.SunLayer();
			this.SUNLAYER2 = new Parts.GameParts.SunLayer();
			this.SUNLAYER3 = new Parts.GameParts.SunLayer();
			this.SUNLAYER4 = new Parts.GameParts.SunLayer();
			this.SUNLAYER5 = new Parts.GameParts.SunLayer();
			this.SUNLAYER6 = new Parts.GameParts.SunLayer();
			Core.Map.BinKeys[Utils.Bin.Hash(CName)] = CName;
		}

		// Default constructor: disassemble suninfo
		public unsafe SunInfo(byte* byteptr_t, string CName, Database.Underground2 db)
		{
			this.Database = db;
			this._collection_name = CName;
			this.SUNLAYER1 = new Parts.GameParts.SunLayer();
			this.SUNLAYER2 = new Parts.GameParts.SunLayer();
			this.SUNLAYER3 = new Parts.GameParts.SunLayer();
			this.SUNLAYER4 = new Parts.GameParts.SunLayer();
			this.SUNLAYER5 = new Parts.GameParts.SunLayer();
			this.SUNLAYER6 = new Parts.GameParts.SunLayer();
			this.Disassemble(byteptr_t);
		}

		~SunInfo() { }
	}
}