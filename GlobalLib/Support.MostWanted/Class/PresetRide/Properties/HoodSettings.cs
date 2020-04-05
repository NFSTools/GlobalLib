using GlobalLib.Reflection.Attributes;
using GlobalLib.Reflection.Enum;
using System;

namespace GlobalLib.Support.MostWanted.Class
{
    public partial class PresetRide
    {
        private byte _hood_style = 0;
        private eBoolean _is_carbonfibre_hood = eBoolean.False;

        /// <summary>
        /// Hood style value of the preset ride. Range: 0-32.
        /// </summary>
        [AccessModifiable()]
        [StaticModifiable()]
        public byte HoodStyle
        {
            get => this._hood_style;
            set
            {
                if (value > 32)
                    throw new ArgumentOutOfRangeException("This value should be in range 0 to 32.");
                else
                    this._hood_style = value;
                this.Modified = true;
            }
        }

        /// <summary>
        /// True if hood is carbonfibre, false otherwise.
        /// </summary>
        [AccessModifiable()]
        [StaticModifiable()]
        public eBoolean IsCarbonfibreHood
        {
            get => this._is_carbonfibre_hood;
            set
            {
                if (Enum.IsDefined(typeof(eBoolean), value))
                {
                    this._is_carbonfibre_hood = value;
                    this.Modified = true;
                }
                else
                    throw new ArgumentOutOfRangeException("Value passed is not of boolean type.");
            }
        }
    }
}