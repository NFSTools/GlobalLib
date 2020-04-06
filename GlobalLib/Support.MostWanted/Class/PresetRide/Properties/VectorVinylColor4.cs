using GlobalLib.Reflection.Attributes;
using System;

namespace GlobalLib.Support.MostWanted.Class
{
    public partial class PresetRide
    {
        private byte _vinylcolor4 = 0;

        /// <summary>
        /// Fourth vinyl color of the preset ride. Range: 0-80.
        /// </summary>
        [AccessModifiable()]
        [StaticModifiable()]
        public byte VinylColor4
        {
            get => this._vinylcolor4;
            set
            {
                if (value > 80)
                    throw new ArgumentOutOfRangeException("This value should be in range 0 to 80.");
                else
                    this._vinylcolor4 = value;
                this.Modified = true;
            }
        }
    }
}