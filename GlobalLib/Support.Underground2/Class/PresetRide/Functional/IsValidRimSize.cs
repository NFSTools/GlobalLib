namespace GlobalLib.Support.Underground2.Class
{
	public partial class PresetRide
	{
        /// <summary>
        /// Checks if a value passed is a valid rim size in terms of current 
        /// brand and style.
        /// </summary>
        /// <param name="value">Rim size value to check.</param>
        /// <returns>True if value passed is valid, false otherwise.</returns>
        private bool IsValidRimSize(byte value)
        {
            string rim = $"{this._rim_brand}_STYLE{this._rim_style:00}_";
            foreach (var str in Core.Map.RimBrands)
            {
                if (str.StartsWith(rim))
                {
                    if (!Utils.FormatX.GetByte(str, rim + "{X}_##", out byte radius))
                        continue;
                    if (value == radius)
                        return true;
                }
            }
            return false;
        }

    }
}