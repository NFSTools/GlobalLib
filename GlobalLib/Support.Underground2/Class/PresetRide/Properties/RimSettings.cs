using GlobalLib.Reflection;
using GlobalLib.Reflection.Attributes;
using GlobalLib.Reflection.Enum;
using GlobalLib.Reflection.Exception;
using System;

namespace GlobalLib.Support.Underground2.Class
{
	public partial class PresetRide
	{
        private string _rim_brand = BaseArguments.STOCK;
        private byte _rim_style = 0;
        private byte _rim_size = 18;
        private byte _rim_outer_max = 24;
        private eBoolean _is_spinning_rim = eBoolean.False;

        /// <summary>
        /// Rim brand value of the preset ride.
        /// </summary>
        [AccessModifiable()]
        [StaticModifiable()]
        public string RimBrand
        {
            get => this._rim_brand;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("This value cannot be left empty.");
                switch (value)
                {
                    case BaseArguments.NULL:
                    case BaseArguments.STOCK:
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
                            throw new MappingFailException();
                }
                this.Modified = true;
            }
        }

        /// <summary>
        /// Rim style value of the preset ride. Range varies for different brands.
        /// </summary>
        [AccessModifiable()]
        [StaticModifiable()]
        public byte RimStyle
        {
            get => this._rim_style;
            set
            {
                if (!this.IsValidRimStyle(value))
                    throw new ArgumentOutOfRangeException("This value is outside of range of valid values.");
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
        [AccessModifiable()]
        [StaticModifiable()]
        public byte RimSize
        {
            get => this._rim_size;
            set
            {
                if (!this.IsValidRimSize(value))
                    throw new ArgumentOutOfRangeException("This value is outside of range of valid values.");
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
        [AccessModifiable()]
        [StaticModifiable()]
        public byte RimOuterMax
        {
            get => this._rim_outer_max;
            set
            {
                if (!this.IsValidRimOuterMax(value))
                    throw new ArgumentOutOfRangeException("This value is outside of range of valid values.");
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
        [AccessModifiable()]
        [StaticModifiable()]
        public eBoolean IsSpinningRim
        {
            get => this._is_spinning_rim;
            set
            {
                if (value == eBoolean.True)
                {
                    if (this.ValidateSpinning())
                        this._is_spinning_rim = value;
                    else
                        throw new Exception("Spinner with the brand, style, size and outer max specified " +
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