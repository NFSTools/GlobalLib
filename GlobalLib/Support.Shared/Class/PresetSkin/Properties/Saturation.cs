namespace GlobalLib.Support.Shared.Class
{
    public partial class PresetSkin : Reflection.Interface.IGetValue, Reflection.Interface.ISetValue
    {
        private float _paintsaturation = 0;

        /// <summary>
        /// Saturation value of the paint of the preset skin. Range: (float)0-1.
        /// </summary>
        public float PaintSaturation
        {
            get => this._paintsaturation;
            set
            {
                if (value > 1 || value < 0)
                    throw new System.ArgumentOutOfRangeException();
                else
                    this._paintsaturation = value;
            }
        }
    }
}