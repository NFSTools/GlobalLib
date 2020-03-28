namespace GlobalLib.Support.Underground2.Framework
{
	public static partial class CareerManager
	{
		private static unsafe void ReadBankTriggers(byte* byteptr_t, int[] PartOffsets, Database.Underground2 db)
		{
			if (PartOffsets[12] == -1) return; // if bank trigger block does not exist
			if (*(uint*)(byteptr_t + PartOffsets[12]) != Reflection.ID.CareerInfo.BANK_TRIGS_BLOCK)
				return; // check bank trigger block ID

			int size = *(int*)(byteptr_t + PartOffsets[12] + 4) / 0xC;

			for (int a1 = 0; a1 < size; ++a1)
			{
				int ptr_header = PartOffsets[12] + a1 * 0xC + 8;
				var Class = new Gameplay.BankTrigger(byteptr_t + ptr_header, db);
				db.BankTriggers.Collections.Add(Class);
			}
		}
	}
}