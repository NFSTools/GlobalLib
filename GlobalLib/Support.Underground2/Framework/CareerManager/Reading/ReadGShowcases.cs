﻿using GlobalLib.Reflection.ID;
using GlobalLib.Support.Underground2.Gameplay;

namespace GlobalLib.Support.Underground2.Framework
{
	public static partial class CareerManager
	{
		private static unsafe void ReadGShowcases(byte* byteptr_t, int[] PartOffsets, Database.Underground2 db)
		{
			if (PartOffsets[5] == -1) return; // if showcases block does not exist
			if (*(uint*)(byteptr_t + PartOffsets[5]) != CareerInfo.SHOWCASE_BLOCK)
				return; // check showcases block ID

			int size = *(int*)(byteptr_t + PartOffsets[5] + 4) / 0x40;

			for (int a1 = 0; a1 < size; ++a1)
			{
				int ptr_header = PartOffsets[5] + a1 * 0x40 + 8;
				var Class = new GShowcase(byteptr_t + ptr_header, db);
				db.GShowcases.Collections.Add(Class);
			}
		}
	}
}