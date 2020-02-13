namespace GlobalLib.Support.Carbon.Class
{
    public partial class PresetRide : Shared.Class.PresetRide, Reflection.Interface.ICastable<PresetRide>
    {
        private byte _paintswatch = 1;

        /// <summary>
        /// Gradient color value of the paint of the preset ride. Range: 0-90.
        /// </summary>
        public byte PaintSwatch
        {
            get => this._paintswatch;
            set
            {
                if (value < 0 || value > 90)
                    throw new System.ArgumentOutOfRangeException("This value should be in range 0 to 90.");
                else
                    this._paintswatch = value;
                this.Modified = true;
            }
        }
    }
}