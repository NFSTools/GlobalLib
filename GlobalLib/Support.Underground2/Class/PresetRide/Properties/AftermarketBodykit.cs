﻿using GlobalLib.Reflection;
using GlobalLib.Reflection.Attributes;
using System;

namespace GlobalLib.Support.Underground2.Class
{
	public partial class PresetRide
	{
        private sbyte _aftermarket_bodykit = 0;
        private byte _cv_misc_style = 0;

        /// <summary>
        /// Aftermarket bodykit value of the preset ride. Range: 0-4, NULL.
        /// </summary>
        [AccessModifiable()]
        [StaticModifiable()]
        public string AftermarketBodykit
        {
            get
            {
                if (this._aftermarket_bodykit == -1)
                    return BaseArguments.NULL;
                else
                    return this._aftermarket_bodykit.ToString();
            }
            set
            {
                if (value == BaseArguments.NULL)
                    this._aftermarket_bodykit = -1;
                else
                {
                    if (!byte.TryParse(value, out byte result) || result > 4)
                        throw new ArgumentOutOfRangeException("This value should be in range 0 to 4, or NULL.");
                    else
                        this._aftermarket_bodykit = (sbyte)result;
                }
                this.Modified = true;
            }
        }

        [AccessModifiable()]
        [StaticModifiable()]
        public byte CVMiscStyle
        {
            get => this._cv_misc_style;
            set
            {
                if (value > 5)
                    throw new ArgumentOutOfRangeException("This value should be in range 0 to 4.");
                this._cv_misc_style = value;
                this.Modified = true;
            }
        }
    }
}