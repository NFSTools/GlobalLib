using GlobalLib.Reflection;
using GlobalLib.Reflection.Attributes;
using GlobalLib.Reflection.Enum;
using System;

namespace GlobalLib.Support.Carbon.Class
{
    public partial class PresetRide
    {
        private sbyte _exhaust_style = 0;
        private byte _exhaust_size = 0;
        private eBoolean _is_center_exhaust = eBoolean.False;


        /// <summary>
        /// Exhaust style value of the preset ride. Possible values: 0-17, NULL.
        /// </summary>
        [AccessModifiable()]
        [StaticModifiable()]
        public string ExhaustStyle
        {
            get
            {
                if (this._exhaust_style == -1)
                    return BaseArguments.NULL;
                else
                    return this._exhaust_style.ToString();
            }
            set
            {
                if (value == BaseArguments.NULL)
                    this._exhaust_style = -1;
                else
                {
                    if (!byte.TryParse(value, out byte result) || result > 17)
                        throw new ArgumentOutOfRangeException("This value should be in range 0 to 17, or NULL.");
                    else
                        this._exhaust_style = (sbyte)result;
                }
                this.Modified = true;
            }
        }

        /// <summary>
        /// Exhaust size value of the preset ride. Range: 0-100.
        /// </summary>
        [AccessModifiable()]
        [StaticModifiable()]
        public byte ExhaustSize
        {
            get => this._exhaust_size;
            set
            {
                if (value > 100)
                    throw new ArgumentOutOfRangeException();
                else
                    this._exhaust_size = value;
                this.Modified = true;
            }
        }

        /// <summary>
        /// True if exhaust is centered, false otherwise.
        /// </summary>
        [AccessModifiable()]
        [StaticModifiable()]
        public eBoolean IsCenterExhaust
        {
            get => this._is_center_exhaust;
            set
            {
                if (Enum.IsDefined(typeof(eBoolean), value))
                {
                    this._is_center_exhaust = value;
                    this.Modified = true;
                }
                else
                    throw new ArgumentOutOfRangeException("Value passed is not of boolean type.");
            }
        }
    }
}