using GlobalLib.Reflection.Enum;
using GlobalLib.Utils;

namespace GlobalLib.Support.Underground2.Class
{
	public partial class PresetRide
	{
        /// <summary>
        /// Disperses all settings from the rim string passed.
        /// </summary>
        /// <param name="rim">Rim string to be dispersed.</param>
        /// <param name="brand">Brand of the rim.</param>
        /// <param name="style">Style of the rim brand.</param>
        /// <param name="size">Size of the rim brand.</param>
        /// <param name="max">Max outer size of the rim brand.</param>
        private void DisperseRimSettings(string rim)
        {
            bool potentialspi = false;
            if (rim.EndsWith("_SPI"))
            {
                potentialspi = true;
                rim = rim.Substring(0, rim.Length - 4);
            }
            this._rim_brand = FormatX.GetString(rim, "{X}_STYLE##_##_##");
            if (!FormatX.GetByte(rim, this._rim_brand + "_STYLE{X}_##_##", out byte thisstyle))
                thisstyle = 1;
            if (!FormatX.GetByte(rim, this._rim_brand + "_STYLE##_{X}_##", out byte thissize))
                thissize = 18;
            if (!FormatX.GetByte(rim, this._rim_brand + "_STYLE##_##_{X}", out byte thismax))
                thismax = 24;
            this._rim_style = thisstyle;
            this._rim_size = thissize;
            this._rim_outer_max = thismax;
            this._is_spinning_rim = potentialspi ? eBoolean.True : eBoolean.False;
        }
    }
}