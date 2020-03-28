namespace GlobalLib.Support.Underground2.Framework
{
	public static partial class CareerManager
	{
		private static unsafe byte[] WritePartUnlockables(Database.Underground2 db)
		{
			var result = new byte[8 + db.PartUnlockables.Length * 0x28];
			int offset = 8; // for calculating offsets
			fixed (byte* byteptr_t = &result[0])
			{
				*(uint*)byteptr_t = Reflection.ID.CareerInfo.PART_UNLOCKS_BLOCK; // write ID
				*(int*)(byteptr_t + 4) = result.Length - 8; // write size
				foreach (var part in db.PartUnlockables.Collections)
				{
					part.Assemble(byteptr_t + offset);
					offset += 0x28;
				}
			}
			return result;
		}
	}
}