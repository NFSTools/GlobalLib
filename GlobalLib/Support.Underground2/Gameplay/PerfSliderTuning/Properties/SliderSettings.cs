namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class PerfSliderTuning
	{
		[Reflection.Attributes.AccessModifiable()]
		public float MinSliderValueRatio { get; set; }
		
		[Reflection.Attributes.AccessModifiable()]
		public float MaxSliderValueRatio { get; set; }
		
		[Reflection.Attributes.AccessModifiable()]
		public float ValueSpread1 { get; set; }
		
		[Reflection.Attributes.AccessModifiable()]
		public float ValueSpread2 { get; set; }
	}
}