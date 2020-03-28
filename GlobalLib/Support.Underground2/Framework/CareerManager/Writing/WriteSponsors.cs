namespace GlobalLib.Support.Underground2.Framework
{
	public static partial class CareerManager
	{
		private static unsafe byte[] WriteSponsors(Utils.MemoryWriter mw, Database.Underground2 db)
		{
			var result = new byte[8 + db.Sponsors.Length * 0x10];
			int offset = 8; // for calculating offsets
			fixed (byte* byteptr_t = &result[0])
			{
				*(uint*)byteptr_t = Reflection.ID.CareerInfo.SPONSOR_BLOCK; // write ID
				*(int*)(byteptr_t + 4) = result.Length - 8; // write size
				foreach (var sponsor in db.Sponsors.Collections)
				{
					sponsor.Assemble(byteptr_t + offset, mw);
					offset += 0x10;
				}
			}
			return result;
		}
	}
}