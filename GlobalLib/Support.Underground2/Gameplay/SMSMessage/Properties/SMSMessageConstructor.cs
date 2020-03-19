namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class SMSMessage : Reflection.Abstract.Collectable, Reflection.Interface.ICastable<SMSMessage>
	{
		// Default constructor
		public SMSMessage() { }

		// Default constructor: create new sms message
		public SMSMessage(string CName, Database.Underground2 db)
		{
			this.Database = db;
			this._collection_name = CName;
			Core.Map.BinKeys[Utils.Bin.Hash(CName)] = CName;
		}

		// Default constructor: disassemble sms message
		public unsafe SMSMessage(byte* ptr_header, byte* ptr_string, Database.Underground2 db)
		{
			this.Database = db;
			this.Disassemble(ptr_header, ptr_string);
		}

		~SMSMessage() { }
	}
}