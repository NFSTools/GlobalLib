namespace GlobalLib.Support.Carbon.Class
{
    public partial class PresetRide
    {
        private float _brightness = 0;

        /// <summary>
        /// Brightness value of the paint of the preset ride. Range: (float)0-1.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        [Reflection.Attributes.StaticModifiable()]
        public float PaintBrightness
        {
            get => this._brightness;
            set
            {
                if (value > 1 || value < 0)
                    throw new System.ArgumentOutOfRangeException("This value should be in range 0 to 1.");
                else
                    this._brightness = value;
                this.Modified = true;
            }
        }
    }
}