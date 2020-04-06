using GlobalLib.Utils.EA;

namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class PerfSliderTuning
	{
		public unsafe void Assemble(byte* byteptr_t)
		{
			// Since CollectionName is of type 0x{1}{2}{3}{4}, use SAT GetColors functions
			int i1 = SAT.GetAlpha(this._collection_name);
			var i2 = SAT.GetRed(this._collection_name);
			var i3 = SAT.GetGreen(this._collection_name);
			var i4 = SAT.GetBlue(this._collection_name);
			*(int*)byteptr_t = i1;
			*(byteptr_t + 0x04) = i2;
			*(byteptr_t + 0x05) = i3;
			*(byteptr_t + 0x06) = i4;
			*(float*)(byteptr_t + 0x08) = this.MinSliderValueRatio;
			*(float*)(byteptr_t + 0x0C) = this.MaxSliderValueRatio;
			*(float*)(byteptr_t + 0x10) = this.ValueSpread1;
			*(float*)(byteptr_t + 0x14) = this.ValueSpread2;
		}
	}
}