using GlobalLib.Reflection.Attributes;

namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class PartPerformance
	{
		[AccessModifiable()]
		[StaticModifiable()]
		public int PerfPartCost { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public float PerfPartAmplifierFraction { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public float PerfPartRangeX { get; set; } = -1;

		[AccessModifiable()]
		[StaticModifiable()]
		public float PerfPartRangeY { get; set; } = -1;

		[AccessModifiable()]
		[StaticModifiable()]
		public float PerfPartRangeZ { get; set; } = -1;

		[AccessModifiable()]
		public int BeingReplacedByIndex1 { get; set; } = -1;

		[AccessModifiable()]
		public int BeingReplacedByIndex2 { get; set; } = -1;
	}
}