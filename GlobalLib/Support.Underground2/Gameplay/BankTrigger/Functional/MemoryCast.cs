using GlobalLib.Reflection.Abstract;

namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class BankTrigger
	{
		public override Collectable MemoryCast(string CName)
		{
			var result = new BankTrigger(CName, this.Database);
			result._initially_unlocked = this._initially_unlocked;
			result.CashValue = this.CashValue;
			result.RequiredStagesCompleted = this.RequiredStagesCompleted;
			return result;
		}
	}
}
