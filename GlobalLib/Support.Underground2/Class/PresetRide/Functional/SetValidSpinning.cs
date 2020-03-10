namespace GlobalLib.Support.Underground2.Class
{
	public partial class PresetRide
	{
        /// <summary>
        /// If spinning was set before and rim was changed, checks if spinner still exists.
        /// </summary>
        private void SetValidSpinning()
        {
            if (this._is_spinning_rim == Reflection.Enum.eBoolean.False) return;
            string rim = $"{this._rim_brand}_STYLE{this._rim_style:00}_{this._rim_size}_{this._rim_outer_max}_SPI";
            if (Core.Map.RimBrands.Contains(rim)) return;
            this._is_spinning_rim = Reflection.Enum.eBoolean.False;
        }
    }
}