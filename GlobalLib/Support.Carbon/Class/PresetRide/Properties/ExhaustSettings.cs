namespace GlobalLib.Support.Carbon.Class
{
    public partial class PresetRide
    {
        private sbyte _exhaust_style = 0;
        private byte _exhaust_size = 0;
        private Reflection.Enum.eBoolean _is_center_exhaust = Reflection.Enum.eBoolean.False;


        /// <summary>
        /// Exhaust style value of the preset ride. Possible values: 0-17, NULL.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        public string ExhaustStyle
        {
            get
            {
                if (this._exhaust_style == -1)
                    return Reflection.BaseArguments.NULL;
                else
                    return this._exhaust_style.ToString();
            }
            set
            {
                if (value == Reflection.BaseArguments.NULL)
                    this._exhaust_style = -1;
                else
                {
                    if (!byte.TryParse(value, out byte result) || result > 17)
                        throw new System.ArgumentOutOfRangeException("This value should be in range 0 to 17, or NULL.");
                    else
                        this._exhaust_style = (sbyte)result;
                }
                this.Modified = true;
            }
        }

        /// <summary>
        /// Exhaust size value of the preset ride. Range: 0-100.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        public byte ExhaustSize
        {
            get => this._exhaust_size;
            set
            {
                if (value > 100)
                    throw new System.ArgumentOutOfRangeException();
                else
                    this._exhaust_size = value;
                this.Modified = true;
            }
        }

        /// <summary>
        /// True if exhaust is centered, false otherwise.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        public Reflection.Enum.eBoolean IsCenterExhaust
        {
            get => this._is_center_exhaust;
            set
            {
                if (System.Enum.IsDefined(typeof(Reflection.Enum.eBoolean), value))
                {
                    this._is_center_exhaust = value;
                    this.Modified = true;
                }
                else
                    throw new System.ArgumentOutOfRangeException("Value passed is not of boolean type.");
            }
        }
    }
}