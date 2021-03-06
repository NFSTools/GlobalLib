﻿using GlobalLib.Reflection.ID;

namespace GlobalLib.Support.Underground2.Framework
{
	public static partial class CareerManager
	{
		private static unsafe int[] FindOffsets(byte* byteptr_t)
		{
			var offsets = new int[] { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };
			int ReaderOffset = 8;
			uint ReaderID = 0;
			int size = *(int*)(byteptr_t + 4) + 8;

			while (ReaderOffset < size)
			{
				ReaderID = *(uint*)(byteptr_t + ReaderOffset);
				switch (ReaderID)
				{
					case CareerInfo.STRING_BLOCK:
						offsets[0] = ReaderOffset;
						goto default;

					case CareerInfo.EVENT_BLOCK:
						offsets[1] = ReaderOffset;
						goto default;

					case CareerInfo.SHOP_BLOCK:
						offsets[2] = ReaderOffset;
						goto default;

					case CareerInfo.BRAND_BLOCK:
						offsets[3] = ReaderOffset;
						goto default;

					case CareerInfo.PERF_PACK_BLOCK:
						offsets[4] = ReaderOffset;
						goto default;

					case CareerInfo.SHOWCASE_BLOCK:
						offsets[5] = ReaderOffset;
						goto default;

					case CareerInfo.SMS_MESSAGE_BLOCK:
						offsets[6] = ReaderOffset;
						goto default;

					case CareerInfo.SPONSOR_BLOCK:
						offsets[7] = ReaderOffset;
						goto default;

					case CareerInfo.STAGE_BLOCK:
						offsets[8] = ReaderOffset;
						goto default;

					case CareerInfo.TUNING_PERF_BLOCK:
						offsets[9] = ReaderOffset;
						goto default;

					case CareerInfo.WORLD_CHAL_BLOCK:
						offsets[10] = ReaderOffset;
						goto default;

					case CareerInfo.PART_UNLOCKS_BLOCK:
						offsets[11] = ReaderOffset;
						goto default;

					case CareerInfo.BANK_TRIGS_BLOCK:
						offsets[12] = ReaderOffset;
						goto default;

					case CareerInfo.CAR_UNLOCKS_BLOCK:
						offsets[13] = ReaderOffset;
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