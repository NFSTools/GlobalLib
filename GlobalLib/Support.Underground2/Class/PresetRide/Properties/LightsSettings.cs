﻿using GlobalLib.Reflection.Attributes;
using System;

namespace GlobalLib.Support.Underground2.Class
{
	public partial class PresetRide
	{
		private byte _headlight_style = 0;
		private byte _brakelight_style = 0;

        /// <summary>
        /// Headlight style value of the preset ride. Range: 0-14.
        /// </summary>
        [AccessModifiable()]
        [StaticModifiable()]
        public byte HeadlightStyle
        {
            get => this._headlight_style;
            set
            {
                if (value > 14)
                    throw new ArgumentOutOfRangeException("This value should be in range 0 to 14.");
                else
                    this._headlight_style = value;
                this.Modified = true;
            }
        }

        /// <summary>
        /// RoofScoop style value of the preset ride. Range: 0-14.
        /// </summary>
        [AccessModifiable()]
        [StaticModifiable()]
        public byte BrakelightStyle
        {
            get => this._brakelight_style;
            set
            {
                if (value > 14)
                    throw new ArgumentOutOfRangeException("This value should be in range 0 to 14.");
                else
                    this._brakelight_style = value;
                this.Modified = true;
            }
        }
    }
}