﻿namespace GlobalLib.Support.MostWanted.Class
{
    public partial class PresetRide : Shared.Class.PresetRide, Reflection.Interface.ICastable<PresetRide>
    {
        private byte _vinylcolor2 = 0;

        /// <summary>
        /// Second vinyl color of the preset ride. Range: 0-80.
        /// </summary>
        public byte VinylColor2
        {
            get => this._vinylcolor2;
            set
            {
                if (value > 80)
                    throw new System.ArgumentOutOfRangeException();
                else
                    this._vinylcolor2 = value;
                this.Modified = true;
            }
        }
    }
}