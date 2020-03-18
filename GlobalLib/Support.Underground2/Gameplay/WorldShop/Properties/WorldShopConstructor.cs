namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class WorldShop : Reflection.Abstract.ICollectable, Reflection.Interface.ICastable<WorldShop>
	{
		// Default constructor
		public WorldShop() { }

		// Default constructor: create new world shop
		public WorldShop(string CName, Database.Underground2 db)
		{
			this.Database = db;
			this._collection_name = CName;
			Core.Map.BinKeys[Utils.Bin.Hash(CName)] = CName;
		}

		// Default constructor: disassemble world shop
		public unsafe WorldShop(byte* byteptr_t, Database.Underground2 db)
		{
			this.Database = db;
			this.Disassemble(byteptr_t);
		}

		~WorldShop() { }
	}
}