namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class GCareerRace
	{
		private string _required_spec_race_won = Reflection.BaseArguments.NULL;

		[Reflection.Attributes.AccessModifiable()]
		[Reflection.Attributes.StaticModifiable()]
		public string RequiredSpecificRaceWon
		{
			get => this._required_spec_race_won;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new System.ArgumentNullException("This value cannot be left empty.");
				this._required_spec_race_won = value;
			}
		}

		[Reflection.Attributes.AccessModifiable()]
		[Reflection.Attributes.StaticModifiable()]
		public byte RequiredSpecificURLWon { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		[Reflection.Attributes.StaticModifiable()]
		public byte SponsorChosenToUnlock { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		[Reflection.Attributes.StaticModifiable()]
		public byte RequiredRacesWon { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		[Reflection.Attributes.StaticModifiable()]
		public byte RequiredURLWon { get; set; }
	}
}