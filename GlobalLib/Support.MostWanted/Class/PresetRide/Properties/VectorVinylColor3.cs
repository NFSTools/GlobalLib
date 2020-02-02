namespace GlobalLib.Support.MostWanted.Class
{
    public partial class PresetRide : Shared.Class.PresetRide, Reflection.Interface.ICastable<PresetRide>
    {
        private byte _vinylcolor3 = 0;

        /// <summary>
        /// Third vinyl color of the preset ride. Range: 0-80.
        /// </summary>
        public byte VinylColor3
        {
            get => this._vinylcolor3;
            set
            {
                if (value > 80)
                    throw new System.ArgumentOutOfRangeException();
                else
                    this._vinylcolor3 = value;
                this.Modified = true;
            }
        }
    }
}