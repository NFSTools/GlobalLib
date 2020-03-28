namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class SMSMessage
	{
		private string _message_label = Reflection.BaseArguments.NULL;

		[Reflection.Attributes.AccessModifiable()]
		[Reflection.Attributes.StaticModifiable()]
		public int CashValue { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		public string MessageSenderLabel
		{
			get => this._message_label;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new System.ArgumentNullException("This value cannot be left empty.");
				this._message_label = value;
			}
		}

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