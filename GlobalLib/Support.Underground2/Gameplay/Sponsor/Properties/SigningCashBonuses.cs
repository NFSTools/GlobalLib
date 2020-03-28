namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class Sponsor
	{
		[Reflection.Attributes.AccessModifiable()]
		[Reflection.Attributes.StaticModifiable()]
		public short CashValuePerWin { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		[Reflection.Attributes.StaticModifiable()]
		public short SignCashBonus { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		[Reflection.Attributes.StaticModifiable()]
		public short PotentialCashBonus { get; set; }
	}
}