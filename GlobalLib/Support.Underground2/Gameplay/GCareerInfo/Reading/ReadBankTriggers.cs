namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class GCareerInfo
	{
		private unsafe void ReadBankTriggers(byte* byteptr_t, int[] PartOffsets)
		{
			if (PartOffsets[12] == -1) return; // if bank trigger block does not exist
			if (*(uint*)(byteptr_t + PartOffsets[12]) != Reflection.ID.GCareerInfo.BANK_TRIGS_BLOCK)
				return; // check bank trigger block ID

			int size = *(int*)(byteptr_t + PartOffsets[12] + 4) / 0xC;

			for (int a1 = 0; a1 < size; ++a1)
			{
				int ptr_header = PartOffsets[12] + a1 * 0xC + 8;
				var Class = new BankTrigger(byteptr_t + ptr_header, this.Database);
				this.Database.BankTriggers.Classes.Add(Class);
			}
		}
	}
}