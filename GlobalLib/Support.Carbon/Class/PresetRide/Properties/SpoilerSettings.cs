namespace GlobalLib.Support.Carbon.Class
{
    public partial class PresetRide
    {
        private byte _spoiler_style = 0;
        private Reflection.Enum.eSTypes _spoiler_type = Reflection.Enum.eSTypes.STOCK;
        private Reflection.Enum.eBoolean _is_autosculpt_spoiler = Reflection.Enum.eBoolean.False;
        private Reflection.Enum.eBoolean _is_carbonfibre_spoiler = Reflection.Enum.eBoolean.False;

        /// <summary>
        /// Spoiler style of the preset ride. Range: 0-29.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        [Reflection.Attributes.StaticModifiable()]
        public byte SpoilerStyle
        {
            get => this._spoiler_style;
            set
            {
                if (value > 29)
                    throw new System.ArgumentOutOfRangeException("This value should be in range 0 to 29.");
                else
                    this._spoiler_style = value;
                this.Modified = true;
            }
        }

        /// <summary>
        /// Spoiler type of the preset ride. Range: STOCK, BASE, _HATCH, _PORSCHES, _CARRERA, NULL.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        [Reflection.Attributes.StaticModifiable()]
        public Reflection.Enum.eSTypes SpoilerType
        {
            get => this._spoiler_type;
            set
            {
                if (System.Enum.IsDefined(typeof(Reflection.Enum.eSTypes), value))
                {
                    this._spoiler_type = value;
                    this.Modified = true;
                }
                else
                    throw new Reflection.Exception.MappingFailException();
            }
        }

        /// <summary>
        /// True if spoiler is autosculpt, false otherwise.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        [Reflection.Attributes.StaticModifiable()]
        public Reflection.Enum.eBoolean IsAutosculptSpoiler
        {
            get => this._is_autosculpt_spoiler;
            set
            {
                if (System.Enum.IsDefined(typeof(Reflection.Enum.eBoolean), value))
                {
                    this._is_autosculpt_spoiler = value;
                    this.Modified = true;
                }
                else
                    throw new System.ArgumentOutOfRangeException("Value passed is not of boolean type.");
            }
        }

        /// <summary>
        /// True if spoiler is carbonfibre, false otherwise.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        [Reflection.Attributes.StaticModifiable()]
        public Reflection.Enum.eBoolean IsCarbonfibreSpoiler
        {
            get => this._is_carbonfibre_spoiler;
            set
            {
                if (System.Enum.IsDefined(typeof(Reflection.Enum.eBoolean), value))
                {
                    this._is_carbonfibre_spoiler = value;
                    this.Modified = true;
                }
                else
                    throw new System.ArgumentOutOfRangeException("Value passed is not of boolean type.");
            }
        }
    }
}