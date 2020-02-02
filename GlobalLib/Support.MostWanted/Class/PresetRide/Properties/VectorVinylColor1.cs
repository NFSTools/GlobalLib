﻿namespace GlobalLib.Support.MostWanted.Class
{
    public partial class PresetRide : Shared.Class.PresetRide, Reflection.Interface.ICastable<PresetRide>
    {
        private byte _vinylcolor1 = 0;

        /// <summary>
        /// First vinyl color of the preset ride. Range: 0-80.
        /// </summary>
        public byte VinylColor1
        {
            get => this._vinylcolor1;
            set
            {
                if (value > 80)
                    throw new System.ArgumentOutOfRangeException();
                else
                    this._vinylcolor1 = value;
                this.Modified = true;
            }
        }
    }
}