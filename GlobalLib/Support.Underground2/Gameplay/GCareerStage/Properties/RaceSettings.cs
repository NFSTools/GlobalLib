namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class GCareerStage
	{
		[Reflection.Attributes.AccessModifiable()]
		public short OutrunCashValue { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		public string LastStageEvent { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		public byte MaxCircuitsShownOnMap { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		public byte MaxDragsShownOnMap { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		public byte MaxStreetXShownOnMap { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		public byte MaxDriftsShownOnMap { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		public byte MaxSprintsShownOnMap { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		public byte MaxOutrunEvents { get; set; }
	}
}