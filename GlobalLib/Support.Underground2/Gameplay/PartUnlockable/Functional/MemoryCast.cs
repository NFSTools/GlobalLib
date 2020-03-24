namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class PartUnlockable
	{
		public override Reflection.Abstract.Collectable MemoryCast(string CName)
		{
			var result = new PartUnlockable(CName, this.Database);
			result._unlock_method_level1 = this._unlock_method_level1;
			result._unlock_method_level2 = this._unlock_method_level2;
			result._unlock_method_level3 = this._unlock_method_level3;
			result._unlock_shop1 = this._unlock_shop1;
			result._unlock_shop2 = this._unlock_shop2;
			result._unlock_shop3 = this._unlock_shop3;
			result.BelongsToStage_Level1 = this.BelongsToStage_Level1;
			result.BelongsToStage_Level2 = this.BelongsToStage_Level2;
			result.BelongsToStage_Level3 = this.BelongsToStage_Level3;
			result.PartPrice_Level1 = this.PartPrice_Level1;
			result.PartPrice_Level2 = this.PartPrice_Level2;
			result.PartPrice_Level3 = this.PartPrice_Level3;
			result.RequiredRacesWon_Level1 = this.RequiredRacesWon_Level1;
			result.RequiredRacesWon_Level2 = this.RequiredRacesWon_Level2;
			result.RequiredRacesWon_Level3 = this.RequiredRacesWon_Level3;
			result.VisualRating_Level1 = this.VisualRating_Level1;
			result.VisualRating_Level2 = this.VisualRating_Level2;
			result.VisualRating_Level3 = this.VisualRating_Level3;
			return result;
		}
	}
}