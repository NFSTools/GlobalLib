namespace GlobalLib.Support.Underground2.Framework
{
	public static partial class CareerManager
	{
		private static unsafe byte[] WritePerfSliderTunings(Database.Underground2 db)
		{
			var result = new byte[8 + db.PerfSliderTunings.Length * 0x18];
			int offset = 8; // for calculating offsets
			fixed (byte* byteptr_t = &result[0])
			{
				*(uint*)byteptr_t = Reflection.ID.CareerInfo.TUNING_PERF_BLOCK; // write ID
				*(int*)(byteptr_t + 4) = result.Length - 8; // write size
				foreach (var slider in db.PerfSliderTunings.Collections)
				{
					slider.Assemble(byteptr_t + offset);
					offset += 0x18;
				}
			}
			return result;
		}
	}
}