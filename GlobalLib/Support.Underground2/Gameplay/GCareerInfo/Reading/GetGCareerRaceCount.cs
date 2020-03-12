namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class GCareerInfo
	{
		private unsafe int GetGCareerRaceCount(byte* byteptr_t, int offset)
		{
			if (offset == -1) return 0; // check if block even exists
			uint ReaderID = *(uint*)(byteptr_t + offset);
			int ReaderSize = *(int*)(byteptr_t + offset + 4);
			if (ReaderID != Reflection.ID.GCareerInfo.EVENT_BLOCK) return 0; // check if ID matches

			return (ReaderSize / 0x88); // 0x88 bytes for one GCareerRace
		}
	}
}