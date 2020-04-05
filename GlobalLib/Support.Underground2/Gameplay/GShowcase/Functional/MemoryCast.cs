using GlobalLib.Reflection.Abstract;

namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class GShowcase
	{
		public override Collectable MemoryCast(string CName)
		{
			var result = new GShowcase(CName, this.Database);
			result._desc_attrib = this._desc_attrib;
			result._desc_string_label = this._desc_string_label;
			result._destination_point = this._destination_point;
			result._take_photo = this._take_photo;
			result.BelongsToStage = this.BelongsToStage;
			result.CashValue = this.CashValue;
			result.RequiredVisualRating = this.RequiredVisualRating;
			result.Unknown0x34 = this.Unknown0x34;
			result.Unknown0x35 = this.Unknown0x35;
			return result;
		}
	}
}