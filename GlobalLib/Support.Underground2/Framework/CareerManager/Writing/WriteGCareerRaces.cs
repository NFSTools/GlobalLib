using GlobalLib.Reflection.ID;
using GlobalLib.Utils;

namespace GlobalLib.Support.Underground2.Framework
{
	public static partial class CareerManager
	{
		private static unsafe byte[] WriteGCareerRaces(MemoryWriter mw, Database.Underground2 db)
		{
			var result = new byte[8 + db.GCareerRaces.Length * 0x88];
			int offset = 8; // for calculating offsets
			fixed (byte* byteptr_t = &result[0])
			{
				*(uint*)byteptr_t = CareerInfo.EVENT_BLOCK; // write ID
				*(int*)(byteptr_t + 4) = result.Length - 8; // write size
				foreach (var race in db.GCareerRaces.Collections)
				{
					race.Assemble(byteptr_t + offset, mw);
					offset += 0x88;
				}
			}
			return result;
		}
	}
}