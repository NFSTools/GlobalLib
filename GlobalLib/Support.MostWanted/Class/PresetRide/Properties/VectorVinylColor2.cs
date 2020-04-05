using GlobalLib.Reflection.Attributes;
using System;

namespace GlobalLib.Support.MostWanted.Class
{
    public partial class PresetRide
    {
        private byte _vinylcolor2 = 0;

        /// <summary>
        /// Second vinyl color of the preset ride. Range: 0-80.
        /// </summary>
        [AccessModifiable()]
        [StaticModifiable()]
        public byte VinylColor2
        {
            get => this._vinylcolor2;
            set
            {
                if (value > 80)
                    throw new ArgumentOutOfRangeException("This value should be in range 0 to 80.");
                else
                    this._vinylcolor2 = value;
                this.Modified = true;
            }
        }
    }
}