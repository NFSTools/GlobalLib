using GlobalLib.Reflection.Attributes;
using GlobalLib.Reflection.Enum;
using GlobalLib.Reflection.Exception;
using System;

namespace GlobalLib.Support.MostWanted.Class
{
    public partial class PresetRide
    {
        private byte _spoiler_style = 0;
        private eSTypes _spoiler_type = eSTypes.STOCK;
        private eBoolean _is_carbonfibre_spoiler = eBoolean.False;

        /// <summary>
        /// Spoiler style of the preset ride. Range: 0-44.
        /// </summary>
        [AccessModifiable()]
        [StaticModifiable()]
        public byte SpoilerStyle
        {
            get => this._spoiler_style;
            set
            {
                if (value > 44)
                    throw new ArgumentOutOfRangeException("This value should be in range 0 to 44.");
                else
                    this._spoiler_style = value;
                this.Modified = true;
            }
        }

        /// <summary>
        /// Spoiler type of the preset ride. Range: STOCK, BASE, _HATCH, _PORSCHES, _CARRERA, NULL.
        /// </summary>
        [AccessModifiable()]
        [StaticModifiable()]
        public eSTypes SpoilerType
        {
            get => this._spoiler_type;
            set
            {
                if (Enum.IsDefined(typeof(eSTypes), value))
                {
                    this._spoiler_type = value;
                    this.Modified = true;
                }
                else
                    throw new MappingFailException();
            }
        }

        /// <summary>
        /// True if spoiler is carbonfibre, false otherwise.
        /// </summary>
        [AccessModifiable()]
        [StaticModifiable()]
        public eBoolean IsCarbonfibreSpoiler
        {
            get => this._is_carbonfibre_spoiler;
            set
            {
                if (Enum.IsDefined(typeof(eBoolean), value))
                {
                    this._is_carbonfibre_spoiler = value;
                    this.Modified = true;
                }
                else
                    throw new ArgumentOutOfRangeException("Value passed is not of boolean type.");
            }
        }
    }
}