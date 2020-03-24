namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class PartPerformance
	{
		public override Reflection.Abstract.Collectable MemoryCast(string CName)
		{
			var result = new PartPerformance(CName, this.Database);
			result._part_perf_type = this._part_perf_type;
			result._perf_brand_1 = this._perf_brand_1;
			result._perf_brand_2 = this._perf_brand_2;
			result._perf_brand_3 = this._perf_brand_3;
			result._perf_brand_4 = this._perf_brand_4;
			result._perf_brand_5 = this._perf_brand_5;
			result._perf_brand_6 = this._perf_brand_6;
			result._perf_brand_7 = this._perf_brand_7;
			result._perf_brand_8 = this._perf_brand_8;
			result.BeingReplacedByIndex1 = this.BeingReplacedByIndex1;
			result.BeingReplacedByIndex2 = this.BeingReplacedByIndex2;
			result.NumberOfBrands = this.NumberOfBrands;
			result.PerfPartAmplifierFraction = this.PerfPartAmplifierFraction;
			result.PerfPartCost = this.PerfPartCost;
			result.PerfPartRangeX = this.PerfPartRangeX;
			result.PerfPartRangeY = this.PerfPartRangeY;
			result.PerfPartRangeZ = this.PerfPartRangeZ;
			return result;
		}
	}
}