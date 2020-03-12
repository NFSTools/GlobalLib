namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class GCareerRace
	{
		[Reflection.Attributes.Expandable("Opponents")]
		public Parts.GameParts.Opponent OPPONENT1 { get; set; }

		[Reflection.Attributes.Expandable("Opponents")]
		public Parts.GameParts.Opponent OPPONENT2 { get; set; }

		[Reflection.Attributes.Expandable("Opponents")]
		public Parts.GameParts.Opponent OPPONENT3 { get; set; }

		[Reflection.Attributes.Expandable("Opponents")]
		public Parts.GameParts.Opponent OPPONENT4 { get; set; }

		[Reflection.Attributes.Expandable("Opponents")]
		public Parts.GameParts.Opponent OPPONENT5 { get; set; }
	}
}