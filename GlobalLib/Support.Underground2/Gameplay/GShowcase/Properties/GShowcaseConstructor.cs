namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class GShowcase : Reflection.Abstract.Collectable
	{
		// Default constructor
		public GShowcase() { }

		// Default constructor: create new showcase
		public GShowcase(string CName, Database.Underground2 db)
		{
			this.Database = db;
			this._collection_name = CName;
			Core.Map.BinKeys[Utils.Bin.Hash(CName)] = CName;
		}

		// Default constructor: disassemble showcase
		public unsafe GShowcase(byte* byteptr_t, Database.Underground2 db)
		{
			this.Database = db;
			this.Disassemble(byteptr_t);
		}

		~GShowcase() { }
	}
}