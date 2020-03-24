namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class Sponsor
	{
		public override Reflection.Abstract.Collectable MemoryCast(string CName)
		{
			var result = new Sponsor(CName, this.Database);
			result.CashValuePerWin = this.CashValuePerWin;
			result.SignCashBonus = this.SignCashBonus;
			result.PotentialCashBonus = this.PotentialCashBonus;
			result.ReqSponsorRace1 = this.ReqSponsorRace1;
			result.ReqSponsorRace2 = this.ReqSponsorRace2;
			result.ReqSponsorRace3 = this.ReqSponsorRace3;
			return result;
		}
	}
}