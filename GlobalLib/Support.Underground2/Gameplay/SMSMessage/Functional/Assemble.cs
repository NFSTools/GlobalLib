namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class SMSMessage
	{
		public unsafe void Assemble(byte* byteptr_t, Utils.MemoryWriter mw)
		{
			ushort pointer = (ushort)mw.Position;
			mw.WriteNullTerminated(this._collection_name);
			*(ushort*)byteptr_t = pointer;

			*(byteptr_t + 0x02) = this.b0x02;
			*(byteptr_t + 0x03) = this.b0x03;
			*(byteptr_t + 0x04) = this.b0x04;
			*(byteptr_t + 0x05) = this.b0x05;
			*(byteptr_t + 0x06) = this.b0x06;
			*(byteptr_t + 0x07) = this.b0x07;
			*(byteptr_t + 0x08) = this.b0x08;
			*(byteptr_t + 0x09) = this.b0x09;
			*(byteptr_t + 0x0A) = this.b0x0A;
			*(byteptr_t + 0x0B) = this.b0x0B;

			*(int*)(byteptr_t + 0x0C) = this.CashValue;
			*(uint*)(byteptr_t + 0x10) = Utils.Bin.SmartHash(this.MessageSenderLabel);
		}
	}
}