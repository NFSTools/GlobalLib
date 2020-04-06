using GlobalLib.Reflection.Attributes;

namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class Track
	{
		[AccessModifiable()]
		[StaticModifiable()]
		public byte MaxTrafficCars_0_0 { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public byte MaxTrafficCars_0_1 { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public byte MaxTrafficCars_1_0 { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public byte MaxTrafficCars_1_1 { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public byte MaxTrafficCars_2_0 { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public byte MaxTrafficCars_2_1 { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public byte MaxTrafficCars_3_0 { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public byte MaxTrafficCars_3_1 { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public byte TrafAllowedNearStartgrid { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public byte TrafAllowedNearFinishline { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public float TrafMinInitDistFromStart { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public float TrafMinInitDistFromFinish { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public float TrafMinInitDistInbetweenA { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public float TrafMinInitDistInbetweenB { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public float TrafOncomingFraction1 { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public float TrafOncomingFraction2 { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public float TrafOncomingFraction3 { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public float TrafOncomingFraction4 { get; set; }
	}
}