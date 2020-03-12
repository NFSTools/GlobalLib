namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class GCareerRace
	{
		[Reflection.Attributes.AccessModifiable()]
		public string RequiredSpecificRaceWon { get; set; } = string.Empty;

		[Reflection.Attributes.AccessModifiable()]
		public byte RequiredSpecificURLWon { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		public byte SponsorChosenToUnlock { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		public byte RequiredRacesWon { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		public byte RequiredURLWon { get; set; }
	}
}