﻿namespace GlobalLib.Support.MostWanted.Class
{
    public partial class PresetRide : Shared.Class.PresetRide, Reflection.Interface.ICastable<PresetRide>
    {
        private string _vinylname = Reflection.BaseArguments.NULL;

        /// <summary>
        /// Vinyl name value of the preset ride.
        /// </summary>
        public string VinylName
        {
            get => this._vinylname;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new System.ArgumentNullException();
                this._vinylname = value;
                this.Modified = true;
            }
        }
    }
}