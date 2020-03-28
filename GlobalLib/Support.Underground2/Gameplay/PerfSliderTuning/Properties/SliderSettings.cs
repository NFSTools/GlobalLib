namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class PerfSliderTuning
	{
		[Reflection.Attributes.AccessModifiable()]
		[Reflection.Attributes.StaticModifiable()]
		public float MinSliderValueRatio { get; set; }
		
		[Reflection.Attributes.AccessModifiable()]
		[Reflection.Attributes.StaticModifiable()]
		public float MaxSliderValueRatio { get; set; }
		
		[Reflection.Attributes.AccessModifiable()]
		[Reflection.Attributes.StaticModifiable()]
		public float ValueSpread1 { get; set; }
		
		[Reflection.Attributes.AccessModifiable()]
		[Reflection.Attributes.StaticModifiable()]
		public float ValueSpread2 { get; set; }
	}
}