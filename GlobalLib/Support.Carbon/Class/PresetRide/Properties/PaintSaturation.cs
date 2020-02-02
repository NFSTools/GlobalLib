namespace GlobalLib.Support.Carbon.Class
{
    public partial class PresetRide : Shared.Class.PresetRide, Reflection.Interface.ICastable<PresetRide>
    {
        private float _saturation = 0;

        /// <summary>
        /// Saturation value of the paint of the preset ride. Range: (float)0-1.
        /// </summary>
        public float PaintSaturation
        {
            get => this._saturation;
            set
            {
                if (value > 1 || value < 0)
                    throw new System.ArgumentOutOfRangeException();
                else
                    this._saturation = value;
                this.Modified = true;
            }
        }
    }
}