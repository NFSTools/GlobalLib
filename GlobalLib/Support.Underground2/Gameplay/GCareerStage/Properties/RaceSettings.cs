namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class GCareerStage
	{
		private string _last_stage_event = Reflection.BaseArguments.NULL;

		[Reflection.Attributes.AccessModifiable()]
		public short OutrunCashValue { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		public string LastStageEvent
		{
			get => this._last_stage_event;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new System.ArgumentNullException("This value cannot be left empty.");
				this._last_stage_event = value;
			}
		}

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