namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class GCareerBrand : Reflection.Abstract.ICollectable, Reflection.Interface.ICastable<GCareerBrand>
	{
		// Default constructor
		public GCareerBrand() { }

		// Default constructor: create new world challenge
		public GCareerBrand(string CName, Database.Underground2 db)
		{
			this.Database = db;
			this._collection_name = CName;
			Core.Map.BinKeys[Utils.Bin.Hash(CName)] = CName;
		}

		// Default constructor: disassemble world challenge
		public unsafe GCareerBrand(byte* byteptr_t, Database.Underground2 db)
		{
			this.Database = db;
			this.Disassemble(byteptr_t);
		}

		~GCareerBrand() { }
	}
}