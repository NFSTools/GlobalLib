namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class PartPerformance
	{
		public unsafe void Assemble(byte* byteptr_t, int index = -1)
		{
			*(int*)byteptr_t = index;
			*(uint*)(byteptr_t + 0x04) = this.BinKey;
			*(int*)(byteptr_t + 0x08) = this.PerfPartCost;
			*(int*)(byteptr_t + 0x0C) = this.NumberOfBrands;

			*(uint*)(byteptr_t + 0x10) = Utils.Bin.SmartHash(this._perf_brand_1);
			*(uint*)(byteptr_t + 0x14) = Utils.Bin.SmartHash(this._perf_brand_2);
			*(uint*)(byteptr_t + 0x18) = Utils.Bin.SmartHash(this._perf_brand_3);
			*(uint*)(byteptr_t + 0x1C) = Utils.Bin.SmartHash(this._perf_brand_4);
			*(uint*)(byteptr_t + 0x20) = Utils.Bin.SmartHash(this._perf_brand_5);
			*(uint*)(byteptr_t + 0x24) = Utils.Bin.SmartHash(this._perf_brand_6);
			*(uint*)(byteptr_t + 0x28) = Utils.Bin.SmartHash(this._perf_brand_7);
			*(uint*)(byteptr_t + 0x2C) = Utils.Bin.SmartHash(this._perf_brand_8);

			*(float*)(byteptr_t + 0x30) = this.PerfPartAmplifierFraction;
			*(float*)(byteptr_t + 0x34) = this.PerfPartRangeX;
			*(float*)(byteptr_t + 0x38) = this.PerfPartRangeY;
			*(float*)(byteptr_t + 0x3C) = this.PerfPartRangeZ;

			*(int*)(byteptr_t + 0x40) = this.BeingReplacedByIndex1;
			*(int*)(byteptr_t + 0x44) = this.BeingReplacedByIndex2;
			*(int*)(byteptr_t + 0x48) = -1;
			*(int*)(byteptr_t + 0x4C) = -1;
			*(int*)(byteptr_t + 0x50) = -1;
			*(int*)(byteptr_t + 0x54) = -1;
			*(int*)(byteptr_t + 0x58) = -1;
		}
	}
}