namespace GlobalLib.Support.Underground2.Class
{
	public partial class PresetRide
	{
		private string GetValidRimString()
		{
			if (this._rim_brand == Reflection.BaseArguments.NULL || this._rim_brand == Reflection.BaseArguments.STOCK)
				return $"{this.MODEL}_KIT00_FRONT_WHEEL";
			string result = $"{this._rim_brand}_STYLE{this._rim_style:00}_{this._rim_size:00}_{this._rim_outer_max:00}";
			return (this._is_spinning_rim == Reflection.Enum.eBoolean.True) ? result + "_SPI" : result;
		}
	}
}