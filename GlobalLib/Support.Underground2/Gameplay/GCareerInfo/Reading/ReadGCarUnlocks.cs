namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class GCareerInfo
	{
		private unsafe void ReadGCarUnlocks(byte* byteptr_t, int[] PartOffsets)
		{
			if (PartOffsets[13] == -1) return; // if car unlocks block does not exist
			if (*(uint*)(byteptr_t + PartOffsets[13]) != Reflection.ID.GCareerInfo.CAR_UNLOCKS_BLOCK)
				return; // check car unlocks block ID

			int size = *(int*)(byteptr_t + PartOffsets[13] + 4) / 0xC;

			for (int a1 = 0; a1 < size; ++a1)
			{
				int ptr_header = PartOffsets[13] + a1 * 0xC + 8;
				var Class = new GCarUnlock(byteptr_t + ptr_header, this.Database);
				this.Database.GCarUnlocks.Classes.Add(Class);
			}
		}
	}
}