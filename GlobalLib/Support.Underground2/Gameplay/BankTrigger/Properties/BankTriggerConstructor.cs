namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class BankTrigger : Reflection.Abstract.Collectable
	{
		// Default constructor
		public BankTrigger() { }

		// Default constructor: create new bank trigger
		public BankTrigger(string CName, Database.Underground2 db)
		{
			this.Database = db;
			this.CollectionName = CName;
			byte maxindex = 0;
			foreach (var bank in this.Database.BankTriggers.Classes.Values)
				if (bank.BankIndex > maxindex) maxindex = bank.BankIndex;
			this.BankIndex = (byte)(maxindex + 1);
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