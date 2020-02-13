namespace GlobalLib.Support.Shared.Class
{
    public partial class PresetSkin : Reflection.Interface.IGetValue, Reflection.Interface.ISetValue
    {
        private float _paintbrightness = 0;

        /// <summary>
        /// Brightness value of the paint of the preset skin. Range: (float)0-1.
        /// </summary>
        public float PaintBrightness
        {
            get => this._paintbrightness;
            set
            {
                if (value > 1 || value < 0)
                    throw new System.ArgumentOutOfRangeException("Value passed should be in range 0 to 1.");
                else
                    this._paintbrightness = value;
            }
        }
    }
}