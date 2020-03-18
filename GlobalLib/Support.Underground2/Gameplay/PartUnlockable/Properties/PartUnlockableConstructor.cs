namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class PartUnlockable : Reflection.Abstract.ICollectable, Reflection.Interface.ICastable<PartUnlockable>
	{
		// Default constructor
		public PartUnlockable() { }

		// Default constructor: create new part unlockable
		public PartUnlockable(string CName, Database.Underground2 db)
		{
			this.Database = db;
			this._collection_name = CName;
			Core.Map.BinKeys[Utils.Bin.Hash(CName)] = CName;
		}

		// Default constructor: disassemble part unlockable
		public unsafe PartUnlockable(byte* byteptr_t, Database.Underground2 db)
		{
			this.Database = db;
			this.Disassemble(byteptr_t);
		}

		~PartUnlockable() { }
	}
}