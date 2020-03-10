namespace GlobalLib.Support.Underground2.Class
{
	public partial class PresetRide
	{
        /// <summary>
        /// Checks if a value passed is a valid outer max radius in terms of current 
        /// brand, style and size.
        /// </summary>
        /// <param name="value">Outer max radius value to check.</param>
        /// <returns>True if value passed is valid, false otherwise.</returns>
        private bool IsValidRimOuterMax(byte value)
        {
            string rim = $"{this._rim_brand}_STYLE{this._rim_style:00}_{this._rim_size}_";
            foreach (var str in Core.Map.RimBrands)
            {
                if (str.StartsWith(rim))
                {
                    if (!Utils.FormatX.GetByte(str, rim + "{X}", out byte radius))
                        continue;
                    if (value == radius)
                        return true;
                }
            }
            return false;
        }
    }
}