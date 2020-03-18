namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class GCareerInfo
	{
		private unsafe void ReadSMSMessages(byte* byteptr_t, int[] PartOffsets)
		{
			if (PartOffsets[6] == -1) return; // if sms message block does not exist
			if (*(uint*)(byteptr_t + PartOffsets[6]) != Reflection.ID.GCareerInfo.SMS_MESSAGE_BLOCK)
				return; // check message block block ID

			int size = *(int*)(byteptr_t + PartOffsets[6] + 4) / 0x14;

			for (int a1 = 0; a1 < size; ++a1)
			{
				int ptr_string = PartOffsets[0] + 8;
				int ptr_header = PartOffsets[6] + a1 * 0x14 + 8;
				var Class = new SMSMessage(byteptr_t + ptr_header, byteptr_t + ptr_string, this.Database);
				this.Database.SMSMessages.Classes.Add(Class);
			}
		}
	}
}