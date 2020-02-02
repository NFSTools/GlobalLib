namespace GlobalLib.Support.MostWanted.Class
{
    public partial class PresetRide : Shared.Class.PresetRide, Reflection.Interface.ICastable<PresetRide>
    {
        private byte _vinylcolor4 = 0;

        /// <summary>
        /// Fourth vinyl color of the preset ride. Range: 0-80.
        /// </summary>
        public byte VinylColor4
        {
            get => this._vinylcolor4;
            set
            {
                if (value > 80)
                    throw new System.ArgumentOutOfRangeException();
                else
                    this._vinylcolor4 = value;
                this.Modified = true;
            }
        }
    }
}