using GlobalLib.Core;
using GlobalLib.Reflection.Abstract;
using GlobalLib.Utils;

namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class SMSMessage : Collectable
	{
		// Default constructor
		public SMSMessage() { }

		// Default constructor: create new sms message
		public SMSMessage(string CName, Database.Underground2 db)
		{
			this.Database = db;
			this.CollectionName = CName;
			Map.BinKeys[Bin.Hash(CName)] = CName;
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