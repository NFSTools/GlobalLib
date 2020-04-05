using GlobalLib.Utils;

namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class PartPerformance
	{
		public unsafe void Assemble(byte* byteptr_t)
		{
			*(int*)byteptr_t = this._part_index;
			*(uint*)(byteptr_t + 0x04) = this.BinKey;
			*(int*)(byteptr_t + 0x08) = this.PerfPartCost;
			*(int*)(byteptr_t + 0x0C) = this.NumberOfBrands;

			uint negative = 0xFFFFFFFF;
			uint perfkey1 = Bin.SmartHash(this._perf_brand_1);
			uint perfkey2 = Bin.SmartHash(this._perf_brand_2);
			uint perfkey3 = Bin.SmartHash(this._perf_brand_3);
			uint perfkey4 = Bin.SmartHash(this._perf_brand_4);
			uint perfkey5 = Bin.SmartHash(this._perf_brand_5);
			uint perfkey6 = Bin.SmartHash(this._perf_brand_6);
			uint perfkey7 = Bin.SmartHash(this._perf_brand_7);
			uint perfkey8 = Bin.SmartHash(this._perf_brand_8);

			*(uint*)(byteptr_t + 0x10) = (perfkey1 == 0) ? negative : perfkey1;
			*(uint*)(byteptr_t + 0x14) = (perfkey2 == 0) ? negative : perfkey2;
			*(uint*)(byteptr_t + 0x18) = (perfkey3 == 0) ? negative : perfkey3;
			*(uint*)(byteptr_t + 0x1C) = (perfkey4 == 0) ? negative : perfkey4;
			*(uint*)(byteptr_t + 0x20) = (perfkey5 == 0) ? negative : perfkey5;
			*(uint*)(byteptr_t + 0x24) = (perfkey6 == 0) ? negative : perfkey6;
			*(uint*)(byteptr_t + 0x28) = (perfkey7 == 0) ? negative : perfkey7;
			*(uint*)(byteptr_t + 0x2C) = (perfkey8 == 0) ? negative : perfkey8;

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