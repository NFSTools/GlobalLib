namespace GlobalLib.Support.Shared.Class
{
    public partial class PresetSkin
    {
        private float _paintsaturation = 0;

        /// <summary>
        /// Saturation value of the paint of the preset skin. Range: (float)0-1.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        public float PaintSaturation
        {
            get => this._paintsaturation;
            set
            {
                if (value > 1 || value < 0)
                    throw new System.ArgumentOutOfRangeException("Value passed should be in range 0 to 1.");
                else
                    this._paintsaturation = value;
            }
        }
    }
}