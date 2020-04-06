using GlobalLib.Reflection;
using GlobalLib.Reflection.Attributes;
using System;

namespace GlobalLib.Support.Carbon.Class
{
    public partial class PresetRide
    {
        private sbyte _autosculpt_skirt = 0;

        /// <summary>
        /// Autosculpt skirt value of the preset ride. Range: 0-10, NULL.
        /// </summary>
        [AccessModifiable()]
        [StaticModifiable()]
        public string AutosculptSkirt
        {
            get
            {
                if (this._autosculpt_skirt == -1)
                    return BaseArguments.NULL;
                if (this._autosculpt_skirt == -2)
                    return "CAPPED";
                else
                    return this._autosculpt_skirt.ToString();
            }
            set
            {
                if (value == BaseArguments.NULL)
                    this._autosculpt_skirt = -1;
                else if (value == "CAPPED")
                    this._autosculpt_skirt = -2;
                else
                {
                    if (!byte.TryParse(value, out byte result) || result > 14)
                        throw new ArgumentOutOfRangeException("This value should be in range 0 to 14, or NULL, or CAPPED.");
                    else
                        this._autosculpt_skirt = (sbyte)result;
                }
                this.Modified = true;
            }
        }
    }
}