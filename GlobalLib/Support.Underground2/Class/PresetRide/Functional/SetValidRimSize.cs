namespace GlobalLib.Support.Underground2.Class
{
	public partial class PresetRide : Shared.Class.PresetRide, Reflection.Interface.ICastable<PresetRide>
	{
        /// <summary>
        /// Sets first valid rim outer max radius based on current brand and style.
        /// </summary>
        private void SetValidRimSize()
        {
            string rim = $"{this._rim_brand}_STYLE";
            rim += (this._rim_style < 10) ? "0" + this._rim_style.ToString() : this._rim_style.ToString();
            foreach (var str in GlobalLib.Core.Map.RimBrands)
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