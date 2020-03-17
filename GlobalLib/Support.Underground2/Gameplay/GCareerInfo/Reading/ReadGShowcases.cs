namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class GCareerInfo
	{
		private unsafe void ReadGShowcases(byte* byteptr_t, int[] PartOffsets)
		{
			if (PartOffsets[5] == -1) return; // if strings block does not exist
			if (*(uint*)(byteptr_t + PartOffsets[5]) != Reflection.ID.GCareerInfo.SHOWCASE_BLOCK)
				return; // check strings block ID

			int size = *(int*)(byteptr_t + PartOffsets[5] + 4) / 0x40;

			for (int a1 = 0; a1 < size; ++a1)
			{
				int ptr_header = PartOffsets[5] + a1 * 0x40 + 8;
				var Class = new GShowcase(byteptr_t + ptr_header, this.Database);
				this.Database.GShowcases.Classes.Add(Class);
			}
		}
	}
}