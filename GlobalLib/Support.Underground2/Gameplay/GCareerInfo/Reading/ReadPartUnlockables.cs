namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class GCareerInfo
	{
		private unsafe void ReadPartUnlockables(byte* byteptr_t, int[] PartOffsets)
		{
			if (PartOffsets[11] == -1) return; // if strings block does not exist
			if (*(uint*)(byteptr_t + PartOffsets[11]) != Reflection.ID.GCareerInfo.PART_UNLOCKS_BLOCK)
				return; // check strings block ID

			int size = *(int*)(byteptr_t + PartOffsets[11] + 4) / 0x28;

			for (int a1 = 0; a1 < size; ++a1)
			{
				int ptr_header = PartOffsets[11] + a1 * 0x28 + 8;
				var Class = new PartUnlockable(byteptr_t + ptr_header, this.Database);
				this.Database.PartUnlockables.Classes.Add(Class);
			}
		}
	}
}