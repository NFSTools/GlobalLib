namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class BankTrigger : Reflection.Abstract.ICollectable, Reflection.Interface.ICastable<BankTrigger>
	{
		// Default constructor
		public BankTrigger() { }

		// Default constructor: create new bank trigger
		public BankTrigger(string CName, Database.Underground2 db)
		{
			this.Database = db;
			this._collection_name = CName;
			Core.Map.BinKeys[Utils.Bin.Hash(CName)] = CName;
		}

		// Default constructor: disassemble bank trigger
		public unsafe BankTrigger(byte* byteptr_t, Database.Underground2 db)
		{
			this.Database = db;
			this.Disassemble(byteptr_t);
		}

		~BankTrigger() { }
	}
}