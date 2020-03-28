namespace GlobalLib.Support.Underground2.Framework
{
	public static partial class CareerManager
	{
		private static unsafe byte[] WritePartPerformances(Database.Underground2 db)
		{
			var result = new byte[0x2C90]; // max size of perf part block
			int offset = 8; // for calculating offsets

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
							uint key = Core.Map.PerfPartTable[a1, a2, 0];
							var cla = db.PartPerformances.FindCollection(key, Database.Collection.eKeyType.BINKEY);
							cla.Assemble(byteptr_t + offset + 0xC);
							++count;
						}
						if (Core.Map.PerfPartTable[a1, a2, 1] != 0)
						{
							uint key = Core.Map.PerfPartTable[a1, a2, 1];
							var cla = db.PartPerformances.FindCollection(key, Database.Collection.eKeyType.BINKEY);
							cla.Assemble(byteptr_t + offset + 0x68);
							++count;
						}
						if (Core.Map.PerfPartTable[a1, a2, 2] != 0)
						{
							uint key = Core.Map.PerfPartTable[a1, a2, 2];
							var cla = db.PartPerformances.FindCollection(key, Database.Collection.eKeyType.BINKEY);
							cla.Assemble(byteptr_t + offset + 0xC4);
							++count;
						}
						if (Core.Map.PerfPartTable[a1, a2, 3] != 0)
						{
							uint key = Core.Map.PerfPartTable[a1, a2, 3];
							var cla = db.PartPerformances.FindCollection(key, Database.Collection.eKeyType.BINKEY);
							cla.Assemble(byteptr_t + offset + 0x120);
							++count;
						}
						*(int*)(byteptr_t + offset + 8) = count;
						offset += 0x17C;
					}
				}
			}
			return result;
		}
	}
}