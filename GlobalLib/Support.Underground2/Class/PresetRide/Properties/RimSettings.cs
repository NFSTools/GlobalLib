namespace GlobalLib.Support.Underground2.Class
{
	public partial class PresetRide : Shared.Class.PresetRide, Reflection.Interface.ICastable<PresetRide>
	{
        private string _rim_brand = Reflection.BaseArguments.STOCK;
        private byte _rim_style = 0;
        private byte _rim_size = 18;
        private byte _rim_outer_max = 24;

        /// <summary>
        /// Rim brand value of the preset ride.
        /// </summary>
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
                    this.Modified = true;
                }
            }
        }

        /// <summary>
        /// Rim size value of the preset ride. Range varies for different brands and styles.
        /// </summary>
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
                    this.Modified = true;
                }
            }
        }

        /// <summary>
        /// Rim outer max value of the preset ride. Range varies for different brands, styles, and sizes.
        /// </summary>
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
                    this.Modified = true;
                }
            }
        }
    }
}