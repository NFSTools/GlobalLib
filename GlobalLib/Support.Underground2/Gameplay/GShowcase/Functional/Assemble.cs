using GlobalLib.Utils;

namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class GShowcase
	{
		public unsafe void Assemble(byte* byteptr_t, MemoryWriter mw)
		{
			mw.WriteNullTerminated(this._collection_name);
			for (int a1 = 0; a1 < this._collection_name.Length; ++a1)
				*(byteptr_t + a1) = (byte)this._collection_name[a1];

			*(uint*)(byteptr_t + 0x20) = this.BinKey;
			*(byteptr_t + 0x24) = (byte)this.TakePhotoMethod;
			*(byteptr_t + 0x25) = this.BelongsToStage;
			*(short*)(byteptr_t + 0x26) = this.CashValue;
			*(uint*)(byteptr_t + 0x28) = Bin.SmartHash(this.DescStringLabel);
			*(uint*)(byteptr_t + 0x2C) = Bin.SmartHash(this.DestinationPoint);
			*(byteptr_t + 0x34) = this.Unknown0x34;
			*(byteptr_t + 0x35) = this.Unknown0x35;
			*(uint*)(byteptr_t + 0x38) = Bin.SmartHash(this.DescAttrib);
			*(float*)(byteptr_t + 0x3C) = this.RequiredVisualRating;
		}
	}
}