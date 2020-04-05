using GlobalLib.Reflection.ID;
using GlobalLib.Utils;

namespace GlobalLib.Support.Underground2.Framework
{
	public static partial class CareerManager
	{
		private static unsafe byte[] WriteWorldShops(MemoryWriter mw, Database.Underground2 db)
		{
			var result = new byte[8 + db.WorldShops.Length * 0xA0];
			int offset = 8; // for calculating offsets
			fixed (byte* byteptr_t = &result[0])
			{
				*(uint*)byteptr_t = CareerInfo.SHOP_BLOCK; // write ID
				*(int*)(byteptr_t + 4) = result.Length - 8; // write size
				foreach (var shop in db.WorldShops.Collections)
				{
					shop.Assemble(byteptr_t + offset, mw);
					offset += 0xA0;
				}
			}
			return result;
		}
	}
}