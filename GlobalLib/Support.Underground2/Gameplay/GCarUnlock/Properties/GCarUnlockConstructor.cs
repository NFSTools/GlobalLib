namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class GCarUnlock : Reflection.Abstract.ICollectable, Reflection.Interface.ICastable<GCarUnlock>
	{
		// Default constructor
		public GCarUnlock() { }

		// Default constructor: create new car unlock
		public GCarUnlock(string CName, Database.Underground2 db)
		{
			this.Database = db;
			this._collection_name = CName;
			Core.Map.BinKeys[Utils.Bin.Hash(CName)] = CName;
		}

		// Default constructor: disassemble car unlock
		public unsafe GCarUnlock(byte* byteptr_t, Database.Underground2 db)
		{
			this.Database = db;
			this.Disassemble(byteptr_t);
		}

		~GCarUnlock() { }
	}
}