namespace GlobalLib.Support.Carbon.Class
{
    public partial class PresetRide
    {
        private byte _hood_style = 0;
        private Reflection.Enum.eBoolean _is_autosculpt_hood = Reflection.Enum.eBoolean.False;
        private Reflection.Enum.eBoolean _is_carbonfibre_hood = Reflection.Enum.eBoolean.False;

        /// <summary>
        /// Hood style value of the preset ride. Range: 0-8.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        public byte HoodStyle
        {
            get => this._hood_style;
            set
            {
                if (value > 8)
                    throw new System.ArgumentOutOfRangeException("This value should be in range 0 to 8.");
                else
                    this._hood_style = value;
                this.Modified = true;
            }
        }

        /// <summary>
        /// True if hood is autosculpt, false otherwise.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        public Reflection.Enum.eBoolean IsAutosculptHood
        {
            get => this._is_autosculpt_hood;
            set
            {
                if (System.Enum.IsDefined(typeof(Reflection.Enum.eBoolean), value))
                {
                    this._is_autosculpt_hood = value;
                    this.Modified = true;
                }
                else
                    throw new System.ArgumentOutOfRangeException("Value passed is not of boolean type.");
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
    }
}