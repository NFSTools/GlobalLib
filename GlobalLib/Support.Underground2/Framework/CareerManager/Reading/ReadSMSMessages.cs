namespace GlobalLib.Support.Underground2.Framework
{
	public static partial class CareerManager
	{
		private static unsafe void ReadSMSMessages(byte* byteptr_t, int[] PartOffsets, Database.Underground2 db)
		{
			if (PartOffsets[6] == -1) return; // if sms message block does not exist
			if (*(uint*)(byteptr_t + PartOffsets[6]) != Reflection.ID.CareerInfo.SMS_MESSAGE_BLOCK)
				return; // check message block block ID

			int size = *(int*)(byteptr_t + PartOffsets[6] + 4) / 0x14;

			for (int a1 = 0; a1 < size; ++a1)
			{
				int ptr_string = PartOffsets[0] + 8;
				int ptr_header = PartOffsets[6] + a1 * 0x14 + 8;
				var Class = new Gameplay.SMSMessage(byteptr_t + ptr_header, byteptr_t + ptr_string, db);
				db.SMSMessages.Collections.Add(Class);
			}
		}
	}
}