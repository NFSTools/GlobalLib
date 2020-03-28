namespace GlobalLib.Support.Carbon.Class
{
    public partial class PresetRide
    {
        private byte _paint_swatch = 1;

        /// <summary>
        /// Gradient color value of the paint of the preset ride. Range: 0-90.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        [Reflection.Attributes.StaticModifiable()]
        public byte PaintSwatch
        {
            get => this._paint_swatch;
            set
            {
                if (value < 0 || value > 90)
                    throw new System.ArgumentOutOfRangeException("This value should be in range 0 to 90.");
                else
                    this._paint_swatch = value;
                this.Modified = true;
            }
        }
    }
}