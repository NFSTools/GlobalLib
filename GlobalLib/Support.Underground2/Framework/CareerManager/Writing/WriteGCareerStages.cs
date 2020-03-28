namespace GlobalLib.Support.Underground2.Framework
{
	public static partial class CareerManager
	{
		private static unsafe byte[] WriteGCareerStages(Database.Underground2 db)
		{
			var result = new byte[8 + db.GCareerStages.Length * 0x50];
			int offset = 8; // for calculating offsets
			fixed (byte* byteptr_t = &result[0])
			{
				*(uint*)byteptr_t = Reflection.ID.CareerInfo.STAGE_BLOCK; // write ID
				*(int*)(byteptr_t + 4) = result.Length - 8; // write size
				foreach (var stage in db.GCareerStages.Collections)
				{
					stage.Assemble(byteptr_t + offset);
					offset += 0x50;
				}
			}
			return result;
		}
	}
}