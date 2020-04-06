using GlobalLib.Reflection;
using GlobalLib.Reflection.Attributes;
using System;

namespace GlobalLib.Support.Carbon.Class
{
    public partial class PresetRide
    {
        private sbyte _autosculpt_rearbumper = 0;

        /// <summary>
        /// Autosculpt rear bumper value of the preset ride. Range: 0-10, NULL.
        /// </summary>
        [AccessModifiable()]
        [StaticModifiable()]
        public string AutosculptRearBumper
        {
            get
            {
                if (this._autosculpt_rearbumper == -1)
                    return BaseArguments.NULL;
                else
                    return this._autosculpt_rearbumper.ToString();
            }
            set
            {
                if (value == BaseArguments.NULL)
                    this._autosculpt_rearbumper = -1;
                else
                {
                    if (!byte.TryParse(value, out byte result) || result > 10)
                        throw new ArgumentOutOfRangeException("This value should be in range 0 to 10, or NULL.");
                    else
                        this._autosculpt_rearbumper = (sbyte)result;
                }
                this.Modified = true;
            }
        }
    }
}