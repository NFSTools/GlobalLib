using GlobalLib.Reflection.ID;

namespace GlobalLib.Support.Underground2.Framework
{
	public static partial class CareerManager
	{
		private static unsafe byte[] WriteGCarUnlocks(Database.Underground2 db)
		{
			var result = new byte[8 + db.GCarUnlocks.Length * 0xC];
			int offset = 8; // for calculating offsets
			fixed (byte* byteptr_t = &result[0])
			{
				*(uint*)byteptr_t = CareerInfo.CAR_UNLOCKS_BLOCK; // write ID
				*(int*)(byteptr_t + 4) = result.Length - 8; // write size
				foreach (var carunlock in db.GCarUnlocks.Collections)
				{
					carunlock.Assemble(byteptr_t + offset);
					offset += 0xC;
				}
			}
			return result;
		}
	}
}