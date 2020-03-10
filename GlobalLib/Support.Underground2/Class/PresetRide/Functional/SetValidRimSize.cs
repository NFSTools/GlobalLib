namespace GlobalLib.Support.Underground2.Class
{
	public partial class PresetRide
	{
        /// <summary>
        /// Sets first valid rim outer max radius based on current brand and style.
        /// </summary>
        private void SetValidRimSize()
        {
            string rim = $"{this._rim_brand}_STYLE{this._rim_style:00}";
            foreach (var str in Core.Map.RimBrands)
            {
                if (str.StartsWith(rim))
                {
                    if (Utils.FormatX.GetByte(str, rim + "_{X}_##", out byte radius))
                        this._rim_size = radius;
                }
            }
        }
    }
}