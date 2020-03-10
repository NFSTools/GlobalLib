namespace GlobalLib.Support.Underground2.Class
{
	public partial class PresetRide
	{
        /// <summary>
        /// Sets first valid rim style based on current brand.
        /// </summary>
        private void SetValidRimStyle()
        {
            string rim = $"{this._rim_brand}_STYLE";
            foreach (var str in Core.Map.RimBrands)
            {
                if (str.StartsWith(rim))
                {
                    if (Utils.FormatX.GetByte(str, rim + "{X}_##_##", out byte radius))
                        this._rim_style = radius;
                }
            }
        }
    }
}