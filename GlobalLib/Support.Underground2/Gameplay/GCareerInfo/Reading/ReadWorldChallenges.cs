namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class GCareerInfo
	{
		private unsafe void ReadWorldChallenges(byte* byteptr_t, int[] PartOffsets)
		{
			if (PartOffsets[10] == -1) return; // if strings block does not exist
			if (*(uint*)(byteptr_t + PartOffsets[10]) != Reflection.ID.GCareerInfo.WORLD_CHAL_BLOCK)
				return; // check strings block ID

			int size = *(int*)(byteptr_t + PartOffsets[10] + 4) / 0x18;

			for (int a1 = 0; a1 < size; ++a1)
			{
				int ptr_string = PartOffsets[0] + 8;
				int ptr_header = PartOffsets[10] + a1 * 0x18 + 8;
				var Class = new WorldChallenge(byteptr_t + ptr_header, byteptr_t + ptr_string, this.Database);
				this.Database.WorldChallenges.Classes.Add(Class);
			}
		}
	}
}