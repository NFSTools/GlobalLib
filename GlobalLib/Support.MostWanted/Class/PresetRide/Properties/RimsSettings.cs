namespace GlobalLib.Support.MostWanted.Class
{
    public partial class PresetRide
    {
        private string _rim_brand = Reflection.BaseArguments.STOCK;
        private byte _rim_style = 0;
        private byte _rim_size = 17;

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
                        if (Core.Map.RimBrands.Contains(value))
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
        /// Rim style value of the preset ride. Range: 0-6.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        public byte RimStyle
        {
            get => this._rim_style;
            set
            {
                if (value < 7)
                    this._rim_style = value;
                else
                    throw new System.ArgumentOutOfRangeException("This value should be in range 0 to 6.");
                this.Modified = true;
            }
        }

        /// <summary>
        /// Rim size value of the preset ride. Range: 17-20.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        public byte RimSize
        {
            get => this._rim_size;
            set
            {
                if (value > 20 || value < 17)
                    throw new System.ArgumentOutOfRangeException("This value should be in range 17 to 20.");
                else
                    this._rim_size = value;
                this.Modified = true;
            }
        }
    }
}