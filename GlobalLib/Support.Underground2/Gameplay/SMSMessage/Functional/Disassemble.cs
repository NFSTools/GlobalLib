using GlobalLib.Core;
using GlobalLib.Utils;

namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class SMSMessage
	{
		private unsafe void Disassemble(byte* ptr_header, byte* ptr_string)
		{
			// CollectionName
			ushort pointer = *(ushort*)ptr_header;
			this._collection_name = ScriptX.NullTerminatedString(ptr_string + pointer);

			// Unknown Yet Values
			this.b0x02 = *(ptr_header + 0x02);
			this.b0x03 = *(ptr_header + 0x03);
			this.b0x04 = *(ptr_header + 0x04);
			this.b0x05 = *(ptr_header + 0x05);
			this.b0x06 = *(ptr_header + 0x06);
			this.b0x07 = *(ptr_header + 0x07);
			this.b0x08 = *(ptr_header + 0x08);
			this.b0x09 = *(ptr_header + 0x09);
			this.b0x0A = *(ptr_header + 0x0A);
			this.b0x0B = *(ptr_header + 0x0B);

			// Cash and Sender
			this.CashValue = *(int*)(ptr_header + 0x0C);
			uint key = *(uint*)(ptr_header + 0x10);
			this.MessageSenderLabel = Map.Lookup(key, true) ?? $"0x{key:X8}";
		}
	}
}