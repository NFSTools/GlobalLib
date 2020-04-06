using GlobalLib.Reflection.Attributes;

namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class Sponsor
	{
		[AccessModifiable()]
		[StaticModifiable()]
		public short CashValuePerWin { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public short SignCashBonus { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public short PotentialCashBonus { get; set; }
	}
}