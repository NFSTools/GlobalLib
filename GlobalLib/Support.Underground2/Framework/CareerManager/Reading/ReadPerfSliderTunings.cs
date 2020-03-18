namespace GlobalLib.Support.Underground2.Framework
{
	public static partial class CareerManager
	{
		private static unsafe void ReadPerfSliderTunings(byte* byteptr_t, int[] PartOffsets, Database.Underground2 db)
		{
			if (PartOffsets[9] == -1) return; // if career brands block does not exist
			if (*(uint*)(byteptr_t + PartOffsets[9]) != Reflection.ID.GCareerInfo.TUNING_PERF_BLOCK)
				return; // check career brands block ID

			int size = *(int*)(byteptr_t + PartOffsets[9] + 4) / 0x18;

			for (int a1 = 0; a1 < size; ++a1)
			{
				int ptr_header = PartOffsets[9] + a1 * 0x18 + 8;
				var Class = new Gameplay.PerfSliderTuning(byteptr_t + ptr_header, db);
				db.PerfSliderTunings.Classes.Add(Class);
			}
		}
	}
}