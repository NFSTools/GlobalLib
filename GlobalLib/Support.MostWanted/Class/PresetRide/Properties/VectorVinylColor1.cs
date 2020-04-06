using GlobalLib.Reflection.Attributes;
using System;

namespace GlobalLib.Support.MostWanted.Class
{
    public partial class PresetRide
    {
        private byte _vinylcolor1 = 0;

        /// <summary>
        /// First vinyl color of the preset ride. Range: 0-80.
        /// </summary>
        [AccessModifiable()]
        [StaticModifiable()]
        public byte VinylColor1
        {
            get => this._vinylcolor1;
            set
            {
                if (value > 80)
                    throw new ArgumentOutOfRangeException("This value should be in range 0 to 80.");
                else
                    this._vinylcolor1 = value;
                this.Modified = true;
            }
        }
    }
}