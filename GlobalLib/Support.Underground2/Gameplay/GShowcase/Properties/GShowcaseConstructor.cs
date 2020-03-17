namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class GShowcase : Reflection.Abstract.ICollectable, Reflection.Interface.ICastable<GShowcase>
	{
		// Default constructor
		public GShowcase() { }

		// Default constructor: create new world challenge
		public GShowcase(string CName, Database.Underground2 db)
		{
			this.Database = db;
			this._collection_name = CName;
			Core.Map.BinKeys[Utils.Bin.Hash(CName)] = CName;
		}

		// Default constructor: disassemble world challenge
		public unsafe GShowcase(byte* byteptr_t, Database.Underground2 db)
		{
			this.Database = db;
			this.Disassemble(byteptr_t);
		}

		~GShowcase() { }
	}
}