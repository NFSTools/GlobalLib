namespace GlobalLib.Support.MostWanted.Class
{
    public partial class PresetRide
    {
        private byte _vinylcolor3 = 0;

        /// <summary>
        /// Third vinyl color of the preset ride. Range: 0-80.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        [Reflection.Attributes.StaticModifiable()]
        public byte VinylColor3
        {
            get => this._vinylcolor3;
            set
            {
                if (value > 80)
                    throw new System.ArgumentOutOfRangeException("This value should be in range 0 to 80.");
                else
                    this._vinylcolor3 = value;
                this.Modified = true;
            }
        }
    }
}