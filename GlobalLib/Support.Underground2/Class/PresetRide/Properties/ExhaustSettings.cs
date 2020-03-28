namespace GlobalLib.Support.Underground2.Class
{
	public partial class PresetRide
	{
        private byte _exhaust_style = 0;

        /// <summary>
        /// Exhaust style value of the preset ride. Range: 0-10.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        [Reflection.Attributes.StaticModifiable()]
        public byte ExhaustStyle
        {
            get => this._exhaust_style;
            set
            {
                if (value > 10)
                    throw new System.ArgumentOutOfRangeException("This value should be in range 0 to 10.");
                else
                    this._exhaust_style = value;
                this.Modified = true;
            }
        }
    }
}