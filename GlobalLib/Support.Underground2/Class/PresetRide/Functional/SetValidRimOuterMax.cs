namespace GlobalLib.Support.Underground2.Class
{
	public partial class PresetRide : Shared.Class.PresetRide, Reflection.Interface.ICastable<PresetRide>
	{
        /// <summary>
        /// Sets first valid rim outer max radius based on current brand, style and size.
        /// </summary>
        private void SetValidRimOuterMax()
        {
            string rim = $"{this._rim_brand}_STYLE";
            rim += (this._rim_style < 10) ? "0" + this._rim_style.ToString() : this._rim_style.ToString();
            rim += $"_{this._rim_size.ToString()}_";
            foreach (var str in Core.Map.RimBrands)
            {
                if (str.StartsWith(rim))
                {
                    if (Utils.FormatX.GetByte(str, rim + "{X}", out byte radius))
                    {
                        this._rim_outer_max = radius;
                        return;
                    }
                }
            }
        }
    }
}