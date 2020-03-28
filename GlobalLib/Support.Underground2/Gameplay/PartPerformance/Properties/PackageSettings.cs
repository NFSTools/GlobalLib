namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class PartPerformance
	{
		[Reflection.Attributes.AccessModifiable()]
		[Reflection.Attributes.StaticModifiable()]
		public int PerfPartCost { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		[Reflection.Attributes.StaticModifiable()]
		public float PerfPartAmplifierFraction { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		[Reflection.Attributes.StaticModifiable()]
		public float PerfPartRangeX { get; set; } = -1;

		[Reflection.Attributes.AccessModifiable()]
		[Reflection.Attributes.StaticModifiable()]
		public float PerfPartRangeY { get; set; } = -1;

		[Reflection.Attributes.AccessModifiable()]
		[Reflection.Attributes.StaticModifiable()]
		public float PerfPartRangeZ { get; set; } = -1;

		[Reflection.Attributes.AccessModifiable()]
		public int BeingReplacedByIndex1 { get; set; } = -1;

		[Reflection.Attributes.AccessModifiable()]
		public int BeingReplacedByIndex2 { get; set; } = -1;
	}
}