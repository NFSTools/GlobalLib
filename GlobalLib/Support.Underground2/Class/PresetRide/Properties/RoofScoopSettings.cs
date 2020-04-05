using GlobalLib.Reflection.Attributes;
using GlobalLib.Reflection.Enum;
using System;

namespace GlobalLib.Support.Underground2.Class
{
	public partial class PresetRide
	{
        private byte _roofscoop_style = 0;
        private eBoolean _is_offset_roofscoop = eBoolean.False;
        private eBoolean _is_dual_roofscoop = eBoolean.False;
        private eBoolean _is_carbonfibre_roofscoop = eBoolean.False;

        /// <summary>
        /// RoofScoop style value of the preset ride. Range: 0-17.
        /// </summary>
        [AccessModifiable()]
        [StaticModifiable()]
        public byte RoofScoopStyle
        {
            get => this._roofscoop_style;
            set
            {
                if (value > 17)
                    throw new ArgumentOutOfRangeException("This value should be in range 0 to 18.");
                else
                    this._roofscoop_style = value;
                this.Modified = true;
            }
        }

        /// <summary>
        /// True if roof scoop is offset, false otherwise.
        /// </summary>
        [AccessModifiable()]
        [StaticModifiable()]
        public eBoolean IsOffsetRoofScoop
        {
            get => this._is_offset_roofscoop;
            set
            {
                if (Enum.IsDefined(typeof(eBoolean), value))
                {
                    this._is_offset_roofscoop = value;
                    this.Modified = true;
                }
                else
                    throw new ArgumentOutOfRangeException("Value passed is not of boolean type.");
            }
        }

        /// <summary>
        /// True if roof scoop is dual, false otherwise.
        /// </summary>
        [AccessModifiable()]
        [StaticModifiable()]
        public eBoolean IsDualRoofScoop
        {
            get => this._is_dual_roofscoop;
            set
            {
                if (Enum.IsDefined(typeof(eBoolean), value))
                {
                    this._is_dual_roofscoop = value;
                    this.Modified = true;
                }
                else
                    throw new ArgumentOutOfRangeException("Value passed is not of boolean type.");
            }
        }

        /// <summary>
        /// True if roof scoop is carbonfibre, false otherwise.
        /// </summary>
        [AccessModifiable()]
        [StaticModifiable()]
        public eBoolean IsCarbonfibreRoofScoop
        {
            get => this._is_carbonfibre_roofscoop;
            set
            {
                if (Enum.IsDefined(typeof(eBoolean), value))
                {
                    this._is_carbonfibre_roofscoop = value;
                    this.Modified = true;
                }
                else
                    throw new ArgumentOutOfRangeException("Value passed is not of boolean type.");
            }
        }
    }
}