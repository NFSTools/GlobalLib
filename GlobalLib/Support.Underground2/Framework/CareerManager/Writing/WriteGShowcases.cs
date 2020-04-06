﻿using GlobalLib.Reflection.ID;
using GlobalLib.Utils;

namespace GlobalLib.Support.Underground2.Framework
{
	public static partial class CareerManager
	{
		private static unsafe byte[] WriteGShowcases(MemoryWriter mw, Database.Underground2 db)
		{
			var result = new byte[8 + db.GShowcases.Length * 0x40];
			int offset = 8; // for calculating offsets
			fixed (byte* byteptr_t = &result[0])
			{
				*(uint*)byteptr_t = CareerInfo.SHOWCASE_BLOCK; // write ID
				*(int*)(byteptr_t + 4) = result.Length - 8; // write size
				foreach (var showcase in db.GShowcases.Collections)
				{
					showcase.Assemble(byteptr_t + offset, mw);
					offset += 0x40;
				}
			}
			return result;
		}
	}
}