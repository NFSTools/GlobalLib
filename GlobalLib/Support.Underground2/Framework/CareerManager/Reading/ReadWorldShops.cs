using GlobalLib.Reflection.ID;
using GlobalLib.Support.Underground2.Gameplay;

namespace GlobalLib.Support.Underground2.Framework
{
	public static partial class CareerManager
	{
		private static unsafe void ReadWorldShops(byte* byteptr_t, int[] PartOffsets, Database.Underground2 db)
		{
			if (PartOffsets[2] == -1) return; // if world shops block does not exist
			if (*(uint*)(byteptr_t + PartOffsets[2]) != CareerInfo.SHOP_BLOCK)
				return; // check world shops block ID

			int size = *(int*)(byteptr_t + PartOffsets[2] + 4) / 0xA0;

			for (int a1 = 0; a1 < size; ++a1)
			{
				int ptr_header = PartOffsets[2] + a1 * 0xA0 + 8;
				var Class = new WorldShop(byteptr_t + ptr_header, db);
				db.WorldShops.Collections.Add(Class);
			}
		}
	}
}