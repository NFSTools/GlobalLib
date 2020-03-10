namespace GlobalLib.Support.Underground2.Class
{
	public partial class PresetRide
	{
		private bool ValidateSpinning()
		{
			string rim = $"{this._rim_brand}_STYLE{this._rim_style:00}_{this._rim_size}_{this._rim_outer_max}_SPI";
			if (Core.Map.RimBrands.Contains(rim))
				return true;
			else
				return false;
		}
	}
}