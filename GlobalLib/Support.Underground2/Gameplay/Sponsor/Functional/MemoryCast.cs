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
			result._sponsor_race1 = this._sponsor_race1;
			result._sponsor_race2 = this._sponsor_race2;
			result._sponsor_race3 = this._sponsor_race3;
			return result;
		}
	}
}