namespace GlobalLib.Support.Carbon.Class
{
    public partial class PresetRide : Shared.Class.PresetRide, Reflection.Interface.ICastable<PresetRide>
    {
        private float _brightness = 0;

        /// <summary>
        /// Brightness value of the paint of the preset ride. Range: (float)0-1.
        /// </summary>
        public float PaintBrightness
        {
            get => this._brightness;
            set
            {
                if (value > 1 || value < 0)
                    throw new System.ArgumentOutOfRangeException();
                else
                    this._brightness = value;
                this.Modified = true;
            }
        }
    }
}