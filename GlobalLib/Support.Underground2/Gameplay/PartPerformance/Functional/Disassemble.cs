namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class PartPerformance
	{
		private unsafe void Disassemble(byte* byteptr_t)
		{
			uint key = 0;

			// CollectionName and stuff
			this._part_index = *(int*)byteptr_t;
			this._collection_name = $"0x{*(uint*)(byteptr_t + 4):X8}";
			this.PerfPartCost = *(int*)(byteptr_t + 8);
			this.NumberOfBrands = *(int*)(byteptr_t + 0xC);

			// Resolve all brands (use non-reflective for speed)
			if (this.NumberOfBrands < 1) goto LABEL_SKIP;
			key = *(uint*)(byteptr_t + 0x10);
			this._perf_brand_1 = Core.Map.Lookup(key) ?? $"0x{key:X8}";

			if (this.NumberOfBrands < 2) goto LABEL_SKIP;
			key = *(uint*)(byteptr_t + 0x14);
			this._perf_brand_2 = Core.Map.Lookup(key) ?? $"0x{key:X8}";

			if (this.NumberOfBrands < 3) goto LABEL_SKIP;
			key = *(uint*)(byteptr_t + 0x18);
			this._perf_brand_3 = Core.Map.Lookup(key) ?? $"0x{key:X8}";

			if (this.NumberOfBrands < 4) goto LABEL_SKIP;
			key = *(uint*)(byteptr_t + 0x1C);
			this._perf_brand_4 = Core.Map.Lookup(key) ?? $"0x{key:X8}";

			if (this.NumberOfBrands < 5) goto LABEL_SKIP;
			key = *(uint*)(byteptr_t + 0x20);
			this._perf_brand_5 = Core.Map.Lookup(key) ?? $"0x{key:X8}";

			if (this.NumberOfBrands < 6) goto LABEL_SKIP;
			key = *(uint*)(byteptr_t + 0x24);
			this._perf_brand_6 = Core.Map.Lookup(key) ?? $"0x{key:X8}";

			if (this.NumberOfBrands < 7) goto LABEL_SKIP;
			key = *(uint*)(byteptr_t + 0x28);
			this._perf_brand_7 = Core.Map.Lookup(key) ?? $"0x{key:X8}";

			if (this.NumberOfBrands < 8) goto LABEL_SKIP;
			key = *(uint*)(byteptr_t + 0x2C);
			this._perf_brand_8 = Core.Map.Lookup(key) ?? $"0x{key:X8}";

			// Do the rest of the values
		LABEL_SKIP:
			this.PerfPartAmplifierFraction = *(float*)(byteptr_t + 0x30);
			this.PerfPartRangeX = *(float*)(byteptr_t + 0x34);
			this.PerfPartRangeY = *(float*)(byteptr_t + 0x38);
			this.PerfPartRangeZ = *(float*)(byteptr_t + 0x3C);
			this.BeingReplacedByIndex1 = *(int*)(byteptr_t + 0x40);
			this.BeingReplacedByIndex2 = *(int*)(byteptr_t + 0x44);
		}
	}
}