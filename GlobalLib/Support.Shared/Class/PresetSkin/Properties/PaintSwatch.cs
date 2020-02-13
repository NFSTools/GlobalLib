namespace GlobalLib.Support.Shared.Class
{
    public partial class PresetSkin : Reflection.Interface.IGetValue, Reflection.Interface.ISetValue
    {
        private byte _paintswatch = 1;

        /// <summary>
        /// Gradient color value of the paint of the preset skin. Range: 0-90.
        /// </summary>
        public byte PaintSwatch
        {
            get => this._paintswatch;
            set
            {
                if (value > 90)
                    throw new System.ArgumentOutOfRangeException("Value passed should be in range 0 to 90.");
                else
                    this._paintswatch = value;
            }
        }
    }
}