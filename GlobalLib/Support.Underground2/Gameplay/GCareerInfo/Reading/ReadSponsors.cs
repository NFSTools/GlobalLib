namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class GCareerInfo
	{
		private unsafe void ReadSponsors(byte* byteptr_t, int[] PartOffsets)
		{
			if (PartOffsets[7] == -1) return; // if sponsors block does not exist
			if (*(uint*)(byteptr_t + PartOffsets[7]) != Reflection.ID.GCareerInfo.SPONSOR_BLOCK)
				return; // check sponsors block ID

			int size = *(int*)(byteptr_t + PartOffsets[7] + 4) / 0x10;

			for (int a1 = 0; a1 < size; ++a1)
			{
				int ptr_string = PartOffsets[0] + 8;
				int ptr_header = PartOffsets[7] + a1 * 0x10 + 8;
				var Class = new Sponsor(byteptr_t + ptr_header, byteptr_t + ptr_string, this.Database);
				this.Database.Sponsors.Classes.Add(Class);
			}
		}
	}
}