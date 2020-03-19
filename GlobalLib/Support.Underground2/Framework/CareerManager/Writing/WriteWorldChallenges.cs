namespace GlobalLib.Support.Underground2.Framework
{
	public static partial class CareerManager
	{
		private static unsafe byte[] WriteWorldChallenges(Utils.MemoryWriter mw, Database.Underground2 db)
		{
			var result = new byte[8 + db.WorldChallenges.Length * 0x18];
			int offset = 8; // for calculating offsets
			fixed (byte* byteptr_t = &result[0])
			{
				*(uint*)byteptr_t = Reflection.ID.CareerInfo.WORLD_CHAL_BLOCK; // write ID
				*(int*)(byteptr_t + 4) = result.Length - 8; // write size
				for (int a1 = 0; a1 < db.WorldChallenges.Length; ++a1)
				{
					db.WorldChallenges.Classes[a1].Assemble(byteptr_t + offset, mw);
					offset += 0x18;
				}
			}
			return result;
		}
	}
}