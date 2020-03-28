namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class PerfSliderTuning
	{
		public override Reflection.Abstract.Collectable MemoryCast(string CName)
		{
			var result = new PerfSliderTuning(CName, this.Database);
			uint maxkey = 0;
			foreach (var slider in this.Database.PerfSliderTunings.Collections)
				if (slider.BinKey > maxkey) maxkey = slider.BinKey;
			result._collection_name = (maxkey + 1).ToString();
			result.MaxSliderValueRatio = this.MaxSliderValueRatio;
			result.MinSliderValueRatio = this.MinSliderValueRatio;
			result.ValueSpread1 = this.ValueSpread1;
			result.ValueSpread2 = this.ValueSpread2;
			return result;
		}
	}
}