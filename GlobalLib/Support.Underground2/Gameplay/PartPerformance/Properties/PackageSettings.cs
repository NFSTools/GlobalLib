namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class PartPerformance
	{
		[Reflection.Attributes.AccessModifiable()]
		public int PerfPartCost { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		public float PerfPartAmplifierFraction { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		public float PerfPartRangeX { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		public float PerfPartRangeY { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		public float PerfPartRangeZ { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		public int BeingReplacedByIndex1 { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		public int BeingReplacedByIndex2 { get; set; }
	}
}