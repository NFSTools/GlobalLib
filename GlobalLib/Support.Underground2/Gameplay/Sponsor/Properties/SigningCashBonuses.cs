namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class Sponsor
	{
		[Reflection.Attributes.AccessModifiable()]
		public short CashValuePerWin { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		public short SignCashBonus { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		public short PotentialCashBonus { get; set; }
	}
}