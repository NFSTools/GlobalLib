using GlobalLib.Reflection.Attributes;

namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class PerfSliderTuning
	{
		[AccessModifiable()]
		[StaticModifiable()]
		public float MinSliderValueRatio { get; set; }
		
		[AccessModifiable()]
		[StaticModifiable()]
		public float MaxSliderValueRatio { get; set; }
		
		[AccessModifiable()]
		[StaticModifiable()]
		public float ValueSpread1 { get; set; }
		
		[AccessModifiable()]
		[StaticModifiable()]
		public float ValueSpread2 { get; set; }
	}
}