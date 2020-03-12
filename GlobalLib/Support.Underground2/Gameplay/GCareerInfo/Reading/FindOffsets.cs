namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class GCareerInfo
	{
		private unsafe int[] FindOffsets(byte* byteptr_t)
		{
			var offsets = new int[] { -1, -1 };
			int ReaderOffset = 8;
			uint ReaderID = 0;
			int size = *(int*)(byteptr_t + 4) + 8;

			while (ReaderOffset < size)
			{
				ReaderID = *(uint*)(byteptr_t + ReaderOffset);
				switch (ReaderID)
				{
					case Reflection.ID.GCareerInfo.STRING_BLOCK:
						offsets[0] = ReaderOffset;
						goto default;

					case Reflection.ID.GCareerInfo.EVENT_BLOCK:
						offsets[1] = ReaderOffset;
						goto default;

					default:
						ReaderOffset += 8 + *(int*)(byteptr_t + ReaderOffset + 4);
						break;
				}
			}
			return offsets;
		}
	}
}