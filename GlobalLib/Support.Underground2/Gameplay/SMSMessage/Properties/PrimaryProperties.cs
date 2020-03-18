namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class SMSMessage
	{
		[Reflection.Attributes.AccessModifiable()]
		public int CashValue { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		public string MessageSenderLabel { get; set; }

		private byte b0x02;
		private byte b0x03;
		private byte b0x04;
		private byte b0x05;
		private byte b0x06;
		private byte b0x07;
		private byte b0x08;
		private byte b0x09;
		private byte b0x0A;
		private byte b0x0B;
	}
}