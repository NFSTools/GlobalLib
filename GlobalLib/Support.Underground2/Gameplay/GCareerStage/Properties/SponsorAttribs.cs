using GlobalLib.Reflection.Attributes;

namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class GCareerStage
	{
		[AccessModifiable()]
		[StaticModifiable()]
		public byte NumberOfSponsorsToChoose { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public short AttribSponsor1 { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public short AttribSponsor2 { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public short AttribSponsor3 { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public short AttribSponsor4 { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public short AttribSponsor5 { get; set; }
	}
}