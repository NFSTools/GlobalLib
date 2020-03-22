namespace GlobalLib.Support.Underground2.Class
{
	public partial class PresetRide
	{
        private byte _hood_style = 0;
        private Reflection.Enum.eBoolean _is_carbonfibre_hood = Reflection.Enum.eBoolean.False;
        private byte _under_hood_style = 0;

        /// <summary>
        /// Hood style value of the preset ride. Range: 0-28.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        public byte HoodStyle
        {
            get => this._hood_style;
            set
            {
                if (value > 28)
                    throw new System.ArgumentOutOfRangeException("This value should be in range 0 to 28.");
                else
                    this._hood_style = value;
                this.Modified = true;
            }
        }

        /// <summary>
        /// True if hood is carbonfibre, false otherwise.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        public Reflection.Enum.eBoolean IsCarbonfibreHood
        {
            get => this._is_carbonfibre_hood;
            set
            {
                if (System.Enum.IsDefined(typeof(Reflection.Enum.eBoolean), value))
                {
                    this._is_carbonfibre_hood = value;
                    this.Modified = true;
                }
                else
                    throw new System.ArgumentOutOfRangeException("Value passed is not of boolean type.");
            }
        }

        /// <summary>
        /// Under hood style value of the preset ride. Range: 0-30.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        public byte UnderHoodStyle
        {
            get => this._under_hood_style;
            set
            {
                if (value != 0 && value < 21 && value > 25)
                    throw new System.ArgumentOutOfRangeException("This value should be in range 21 to 25 or 0.");
                else
                    this._hood_style = value;
                this.Modified = true;
            }
        }
    }
}