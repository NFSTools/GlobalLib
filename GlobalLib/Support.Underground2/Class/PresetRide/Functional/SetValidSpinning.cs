namespace GlobalLib.Support.Underground2.Class
{
	public partial class PresetRide : Shared.Class.PresetRide, Reflection.Interface.ICastable<PresetRide>
	{
        /// <summary>
        /// If spinning was set before and rim was changed, checks if spinner still exists.
        /// </summary>
        private void SetValidSpinning()
        {
            if (!this._is_spinning_rim) return;
            string rim = $"{this._rim_brand}_STYLE";
            rim += (this._rim_style < 10) ? "0" + this._rim_style.ToString() : this._rim_style.ToString();
            rim += $"_{this._rim_size.ToString()}_{this._rim_outer_max.ToString()}_SPI";
            foreach (var str in Core.Map.RimBrands)
            {
                if (rim == str)
                {
                    return;
                }
            }
            this._is_spinning_rim = false;
        }
    }
}