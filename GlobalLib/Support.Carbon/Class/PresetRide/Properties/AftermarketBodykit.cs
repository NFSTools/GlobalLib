using GlobalLib.Reflection;
using GlobalLib.Reflection.Attributes;
using System;

namespace GlobalLib.Support.Carbon.Class
{
    public partial class PresetRide
    {
        private sbyte _aftermarket_bodykit = 0;

        /// <summary>
        /// Aftermarket bodykit value of the preset ride. Range: 0-5, NULL.
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
                    if (!byte.TryParse(value, out byte result) || result > 5)
                        throw new ArgumentOutOfRangeException("This value should be in range 0 to 5, or NULL.");
                    else
                    {
                        this._aftermarket_bodykit = (sbyte)result;
                    }
                    this.Modified = true;
                }
            }
        }
    }
}