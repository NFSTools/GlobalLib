namespace GlobalLib.Support.Underground2.Framework
{
	public static partial class CareerManager
	{
		private static unsafe byte[] WriteSMSMessages(Utils.MemoryWriter mw, Database.Underground2 db)
		{
			var result = new byte[8 + db.SMSMessages.Length * 0x14];
			int offset = 8; // for calculating offsets
			fixed (byte* byteptr_t = &result[0])
			{
				*(uint*)byteptr_t = Reflection.ID.CareerInfo.SMS_MESSAGE_BLOCK; // write ID
				*(int*)(byteptr_t + 4) = result.Length - 8; // write size
				foreach (var message in db.SMSMessages.Collections)
				{
					message.Assemble(byteptr_t + offset, mw);
					offset += 0x14;
				}
			}
			return result;
		}
	}
}