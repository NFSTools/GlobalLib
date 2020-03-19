namespace GlobalLib.Support.Underground2.Framework
{
	public static partial class CareerManager
	{
		private static unsafe byte[] WritePartPerformances(Database.Underground2 db)
		{
			var result = new byte[0x2C90]; // max size of perf part block
			int offset = 8; // for calculating offsets
			int index = 0; // for keeping track of perf index

			fixed (byte* byteptr_t = &result[0])
			{
				*(uint*)byteptr_t = Reflection.ID.CareerInfo.PERF_PACK_BLOCK; // write ID
				*(int*)(byteptr_t + 4) = result.Length - 8; // write size
				for (int a1 = 0; a1 < 10; ++a1)
				{
					for (int a2 = 0; a2 < 3; ++a2)
					{
						int count = 0;
						*(int*)(byteptr_t + offset) = a1;
						*(int*)(byteptr_t + offset + 4) = a2 + 1;
						if (Core.Map.PerfPartTable[a1, a2, 0] != 0)
						{
							var cla = db.PartPerformances.FindClass(Core.Map.PerfPartTable[a1, a2, 0], Database.Collection.eKeyType.BINKEY);
							cla.Assemble(byteptr_t + offset + 0xC, index);
							++count;
							++index;
						}
						if (Core.Map.PerfPartTable[a1, a2, 1] != 0)
						{
							var cla = db.PartPerformances.FindClass(Core.Map.PerfPartTable[a1, a2, 1], Database.Collection.eKeyType.BINKEY);
							cla.Assemble(byteptr_t + offset + 0x68, index);
							++count;
							++index;
						}
						if (Core.Map.PerfPartTable[a1, a2, 2] != 0)
						{
							var cla = db.PartPerformances.FindClass(Core.Map.PerfPartTable[a1, a2, 2], Database.Collection.eKeyType.BINKEY);
							cla.Assemble(byteptr_t + offset + 0xC4, index);
							++count;
							++index;
						}
						if (Core.Map.PerfPartTable[a1, a2, 3] != 0)
						{
							var cla = db.PartPerformances.FindClass(Core.Map.PerfPartTable[a1, a2, 3], Database.Collection.eKeyType.BINKEY);
							cla.Assemble(byteptr_t + offset + 0x120, index);
							++count;
							++index;
						}
						*(int*)(byteptr_t + 8) = count;
						offset += 0x17C;
					}
				}
			}
			return result;
		}
	}
}