namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class PerfSliderTuning
	{
		public unsafe byte[] Assemble()
		{
			var result = new byte[0x18];
			fixed (byte* byteptr_t = &result[0])
			{
				// Since CollectionName is of type 0x{1}{2}{3}{4}, use SAT GetColors functions
				int i1 = Utils.EA.SAT.GetAlpha(this._collection_name);
				var i2 = Utils.EA.SAT.GetRed(this._collection_name);
				var i3 = Utils.EA.SAT.GetGreen(this._collection_name);
				var i4 = Utils.EA.SAT.GetBlue(this._collection_name);
				*(int*)byteptr_t = i1;
				*(byteptr_t + 0x04) = i2;
				*(byteptr_t + 0x05) = i3;
				*(byteptr_t + 0x06) = i4;
				*(float*)(byteptr_t + 0x08) = this.MinSliderValueRatio;
				*(float*)(byteptr_t + 0x0C) = this.MaxSliderValueRatio;
				*(float*)(byteptr_t + 0x10) = this.ValueSpread1;
				*(float*)(byteptr_t + 0x14) = this.ValueSpread2;
			}
			return result;
		}
	}
}