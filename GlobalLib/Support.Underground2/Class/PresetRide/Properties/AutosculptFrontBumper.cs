using GlobalLib.Reflection;
using GlobalLib.Reflection.Attributes;
using System;

namespace GlobalLib.Support.Underground2.Class
{
	public partial class PresetRide
	{
        private sbyte _autosculpt_frontbumper = 0;

        /// <summary>
        /// Autosculpt front bumper value of the preset ride. Range: 0-30, NULL.
        /// </summary>
        [AccessModifiable()]
        [StaticModifiable()]
        public string AutosculptFrontBumper
        {
            get
            {
                if (this._autosculpt_frontbumper == -1)
                    return BaseArguments.NULL;
                else
                    return this._autosculpt_frontbumper.ToString();
            }
            set
            {
                if (value == BaseArguments.NULL)
                    this._autosculpt_frontbumper = -1;
                else
                {
                    if (!byte.TryParse(value, out byte result) || result > 30)
                        throw new ArgumentOutOfRangeException("This value should be in range 0 to 30, or NULL.");
                    else
                        this._autosculpt_frontbumper = (sbyte)result;
                }
                this.Modified = true;
            }
        }
    }
}