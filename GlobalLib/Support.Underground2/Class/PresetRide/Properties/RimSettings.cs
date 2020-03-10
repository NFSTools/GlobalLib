namespace GlobalLib.Support.Underground2.Class
{
	public partial class PresetRide
	{
        private string _rim_brand = Reflection.BaseArguments.STOCK;
        private byte _rim_style = 0;
        private byte _rim_size = 18;
        private byte _rim_outer_max = 24;
        private Reflection.Enum.eBoolean _is_spinning_rim = Reflection.Enum.eBoolean.False;

        /// <summary>
        /// Rim brand value of the preset ride.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        public string RimBrand
        {
            get => this._rim_brand;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new System.ArgumentNullException("This value cannot be left empty.");
                switch (value)
                {
                    case Reflection.BaseArguments.NULL:
                    case Reflection.BaseArguments.STOCK:
                        this._rim_brand = value;
                        break;
                    default:
                        if (this.IsValidRimBrand(value))
                        {
                            this._rim_brand = value;
                            this.SetValidRimStyle();
                            this.SetValidRimSize();
                            this.SetValidRimOuterMax();
                            this.SetValidSpinning();
                            break;
                        }
                        else
                            throw new Reflection.Exception.MappingFailException();
                }
                this.Modified = true;
            }
        }

        /// <summary>
        /// Rim style value of the preset ride. Range varies for different brands.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        public byte RimStyle
        {
            get => this._rim_style;
            set
            {
                if (!this.IsValidRimStyle(value))
                    throw new System.ArgumentOutOfRangeException("This value is outside of range of valid values.");
                else
                {
                    this._rim_style = value;
                    this.SetValidRimSize();
                    this.SetValidRimOuterMax();
                    this.SetValidSpinning();
                    this.Modified = true;
                }
            }
        }

        /// <summary>
        /// Rim size value of the preset ride. Range varies for different brands and styles.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        public byte RimSize
        {
            get => this._rim_size;
            set
            {
                if (!this.IsValidRimSize(value))
                    throw new System.ArgumentOutOfRangeException("This value is outside of range of valid values.");
                else
                {
                    this._rim_size = value;
                    this.SetValidRimOuterMax();
                    this.SetValidSpinning();
                    this.Modified = true;
                }
            }
        }

        /// <summary>
        /// Rim outer max value of the preset ride. Range varies for different brands, styles, and sizes.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        public byte RimOuterMax
        {
            get => this._rim_outer_max;
            set
            {
                if (!this.IsValidRimOuterMax(value))
                    throw new System.ArgumentOutOfRangeException("This value is outside of range of valid values.");
                else
                {
                    this._rim_outer_max = value;
                    this.SetValidSpinning();
                    this.Modified = true;
                }
            }
        }

        /// <summary>
        /// If set to true, rim is a spinner type, otherwise a regular rim.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        public Reflection.Enum.eBoolean IsSpinningRim
        {
            get => this._is_spinning_rim;
            set
            {
                if (value == Reflection.Enum.eBoolean.True)
                {
                    if (this.ValidateSpinning())
                        this._is_spinning_rim = value;
                    else
                        throw new System.Exception("Spinner with the brand, style, size and outer max specified " +
                            "does not exist.");
                }
                else
                {
                    this._is_spinning_rim = value;
                    this.Modified = true;
                }
            }
        }
    }
}