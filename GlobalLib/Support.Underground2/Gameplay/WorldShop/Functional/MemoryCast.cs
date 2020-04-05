using GlobalLib.Reflection.Abstract;

namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class WorldShop
	{
		public override Collectable MemoryCast(string CName)
		{
			var result = new WorldShop(CName, this.Database);
			result._event_to_complete = this._event_to_complete;
			result._initially_hidden = this._initially_hidden;
			result._intro_movie = this._intro_movie;
			result._shop_filename = this._shop_filename;
			result._shop_trigger = this._shop_trigger;
			result._shop_type = this._shop_type;
			result._unlocked_by_event = this._unlocked_by_event;
			result.BelongsToStage = this.BelongsToStage;
			return result;
		}
	}
}