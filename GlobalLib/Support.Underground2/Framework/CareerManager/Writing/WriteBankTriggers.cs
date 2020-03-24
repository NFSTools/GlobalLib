namespace GlobalLib.Support.Underground2.Framework
{
	public static partial class CareerManager
	{
		private static unsafe byte[] WriteBankTriggers(Database.Underground2 db)
		{
			var result = new byte[8 + db.BankTriggers.Length * 0xC];
			int offset = 8; // for calculating offsets
			fixed (byte* byteptr_t = &result[0])
			{
				*(uint*)byteptr_t = Reflection.ID.CareerInfo.BANK_TRIGS_BLOCK; // write ID
				*(int*)(byteptr_t + 4) = result.Length - 8; // write size
				foreach (var bank in db.BankTriggers.Classes.Values)
				{
					bank.Assemble(byteptr_t + offset);
					offset += 0xC;
				}
			}
			return result;
		}
	}
}