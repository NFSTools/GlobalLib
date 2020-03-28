namespace GlobalLib.Support.Underground2.Framework
{
	public static partial class CareerManager
	{
		private static unsafe void ReadPartPerformances(byte* byteptr_t, int[] PartOffsets, Database.Underground2 db)
		{
			if (PartOffsets[4] == -1) return; // if part perf block does not exist
			if (*(uint*)(byteptr_t + PartOffsets[4]) != Reflection.ID.CareerInfo.PERF_PACK_BLOCK)
				return; // check part perf block ID

			int size = *(int*)(byteptr_t + PartOffsets[4] + 4) / 0x17C;

			for (int a1 = 0; a1 < size; ++a1)
			{
				byte* offset_ptr = byteptr_t + PartOffsets[4] + a1 * 0x17C + 8;
				int index = *(int*)(offset_ptr);
				int level = *(int*)(offset_ptr + 4) - 1;
				int total = *(int*)(offset_ptr + 8);

				for (int a2 = 0; a2 < total; ++a2)
				{
					int ptr_header = 12 + a2 * 0x5C;
					var Class = new Gameplay.PartPerformance(offset_ptr + ptr_header, db, index, level, a2);
					db.PartPerformances.Collections.Add(Class);
				}
			}
		}
	}
}