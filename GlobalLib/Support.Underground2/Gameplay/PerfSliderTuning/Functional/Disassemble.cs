namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class PerfSliderTuning
	{
		private unsafe void Disassemble(byte* byteptr_t)
		{
			int index = (byte)*(int*)byteptr_t;
			int level = *(byteptr_t + 0x04);
			int slide = *(byteptr_t + 0x05);
			int slamp = *(byteptr_t + 0x06);

			// CollectionName
			this._collection_name = $"0x{index:X2}{level:X2}{slide:X2}{slamp:X2}";

			// Slider Settings
			this.MinSliderValueRatio = *(float*)(byteptr_t + 0x08);
			this.MaxSliderValueRatio = *(float*)(byteptr_t + 0x0C);
			this.ValueSpread1 = *(float*)(byteptr_t + 0x10);
			this.ValueSpread2 = *(float*)(byteptr_t + 0x14);
		}
	}
}