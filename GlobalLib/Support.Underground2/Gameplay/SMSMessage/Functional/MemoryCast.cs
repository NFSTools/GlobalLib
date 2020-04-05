using GlobalLib.Reflection.Abstract;

namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class SMSMessage
	{
		public override Collectable MemoryCast(string CName)
		{
			var result = new SMSMessage(CName, this.Database);
			result.b0x02 = this.b0x02;
			result.b0x03 = this.b0x03;
			result.b0x04 = this.b0x04;
			result.b0x05 = this.b0x05;
			result.b0x06 = this.b0x06;
			result.b0x07 = this.b0x07;
			result.b0x08 = this.b0x08;
			result.b0x09 = this.b0x09;
			result.b0x0A = this.b0x0A;
			result.b0x0B = this.b0x0B;
			result.CashValue = this.CashValue;
			result._message_label = this._message_label;
			return result;
		}
	}
}