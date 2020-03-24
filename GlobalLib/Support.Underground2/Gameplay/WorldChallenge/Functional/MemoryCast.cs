namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class WorldChallenge
	{
		public override Reflection.Abstract.Collectable MemoryCast(string CName)
		{
			var result = new WorldChallenge(CName, this.Database);
			result._world_trigger = this._world_trigger;
			result._use_outruns = this._use_outruns;
			result._sms_label = this._sms_label;
			result._padding0 = this._padding0;
			result._chal_type = this._chal_type;
			result._chal_parent = this._chal_parent;
			result.UnlockablePart1_Index = this.UnlockablePart1_Index;
			result.UnlockablePart2_Index = this.UnlockablePart2_Index;
			result.UnlockablePart3_Index = this.UnlockablePart3_Index;
			result.TimeLimit = this.TimeLimit;
			result.RequiredRacesWon = this.RequiredRacesWon;
			result.BelongsToStage = this.BelongsToStage;
			return result;
		}
	}
}