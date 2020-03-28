namespace GlobalLib.Support.Carbon.Class
{
    public partial class PresetRide
    {
        private float _saturation = 0;

        /// <summary>
        /// Saturation value of the paint of the preset ride. Range: (float)0-1.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        [Reflection.Attributes.StaticModifiable()]
        public float PaintSaturation
        {
            get => this._saturation;
            set
            {
                if (value > 1 || value < 0)
                    throw new System.ArgumentOutOfRangeException("This value should be in range 0 to 1.");
                else
                    this._saturation = value;
                this.Modified = true;
            }
        }
    }
}