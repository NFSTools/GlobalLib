using GlobalLib.Reflection.Attributes;
using GlobalLib.Reflection.Enum;
using System;

namespace GlobalLib.Support.Carbon.Class
{
    public partial class PresetRide
    {
        private eBoolean _popup_headlights_exist = eBoolean.False;
        private eBoolean _popup_heaglights_on = eBoolean.False;
        private eBoolean _choptop_is_on = eBoolean.False;
        private byte _choptop_size = 0;

        /// <summary>
        /// True if popup headlights of the preset ride model exist, false otherwise.
        /// </summary>
        [AccessModifiable()]
        [StaticModifiable()]
        public eBoolean PopupHeadlightsExist
        {
            get => this._popup_headlights_exist;
            set
            {
                if (Enum.IsDefined(typeof(eBoolean), value))
                {
                    this._popup_headlights_exist = value;
                    this.Modified = true;
                }
                else
                    throw new ArgumentOutOfRangeException("Value passed is not of boolean type.");
            }
        }

        /// <summary>
        /// True if preset ride's popup headlights are on, false otherwise.
        /// </summary>
        [AccessModifiable()]
        [StaticModifiable()]
        public eBoolean PopupHeadlightsOn
        {
            get => this._popup_heaglights_on;
            set
            {
                if (Enum.IsDefined(typeof(eBoolean), value))
                {
                    this._popup_heaglights_on = value;
                    this.Modified = true;
                }
                else
                    throw new ArgumentOutOfRangeException("Value passed is not of boolean type.");
            }
        }

        /// <summary>
        /// True if preset ride's roof is a chop top, false otherwise.
        /// </summary>
        [AccessModifiable()]
        [StaticModifiable()]
        public eBoolean ChopTopIsOn
        {
            get => this._choptop_is_on;
            set
            {
                if (Enum.IsDefined(typeof(eBoolean), value))
                {
                    this._choptop_is_on = value;
                    this.Modified = true;
                }
                else
                    throw new ArgumentOutOfRangeException("Value passed is not of boolean type.");
            }
        }

        /// <summary>
        /// Choptop size value of the preset car. Range: 0-100.
        /// </summary>
        [AccessModifiable()]
        [StaticModifiable()]
        public byte ChopTopSize
        {
            get => this._choptop_size;
            set
            {
                if (value > 100)
                    throw new ArgumentOutOfRangeException("This value should be in range 0 to 100.");
                else
                    this._choptop_size = value;
                this.Modified = true;
            }
        }
    }
}