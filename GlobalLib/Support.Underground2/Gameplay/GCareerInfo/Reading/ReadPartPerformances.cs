namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class GCareerInfo
	{
		private unsafe void ReadPartPerformances(byte* byteptr_t, int[] PartOffsets)
		{
			if (PartOffsets[4] == -1) return; // if strings block does not exist
			if (*(uint*)(byteptr_t + PartOffsets[4]) != Reflection.ID.GCareerInfo.PERF_PACK_BLOCK)
				return; // check strings block ID

			int size = *(int*)(byteptr_t + PartOffsets[4] + 4) / 0x17C;

			for (int a1 = 0; a1 < size; ++a1)
			{
				byte* offset_ptr = byteptr_t + PartOffsets[4] + a1 * 0x17C + 8;
				int index = *(int*)(offset_ptr);
				int level = *(int*)(offset_ptr + 4);
				int total = *(int*)(offset_ptr + 8);

				for (int a2 = 0; a2 < total; ++a2)
				{
					int ptr_header = 12 + a2 * 0x5C;
					var Class = new PartPerformance(offset_ptr + ptr_header, this.Database, index, level, a2);
					this.Database.PartPerformances.Classes.Add(Class);
				}
			}
		}
	}
}