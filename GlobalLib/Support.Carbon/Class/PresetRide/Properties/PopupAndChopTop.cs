namespace GlobalLib.Support.Carbon.Class
{
    public partial class PresetRide
    {
        private Reflection.Enum.eBoolean _popup_headlights_exist = Reflection.Enum.eBoolean.False;
        private Reflection.Enum.eBoolean _popup_heaglights_on = Reflection.Enum.eBoolean.False;
        private Reflection.Enum.eBoolean _choptop_is_on = Reflection.Enum.eBoolean.False;
        private byte _choptop_size = 0;

        /// <summary>
        /// True if popup headlights of the preset ride model exist, false otherwise.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        public Reflection.Enum.eBoolean PopupHeadlightsExist
        {
            get => this._popup_headlights_exist;
            set
            {
                if (System.Enum.IsDefined(typeof(Reflection.Enum.eBoolean), value))
                {
                    this._popup_headlights_exist = value;
                    this.Modified = true;
                }
                else
                    throw new System.ArgumentOutOfRangeException("Value passed is not of boolean type.");
            }
        }

        /// <summary>
        /// True if preset ride's popup headlights are on, false otherwise.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        public Reflection.Enum.eBoolean PopupHeadlightsOn
        {
            get => this._popup_heaglights_on;
            set
            {
                if (System.Enum.IsDefined(typeof(Reflection.Enum.eBoolean), value))
                {
                    this._popup_heaglights_on = value;
                    this.Modified = true;
                }
                else
                    throw new System.ArgumentOutOfRangeException("Value passed is not of boolean type.");
            }
        }

        /// <summary>
        /// True if preset ride's roof is a chop top, false otherwise.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        public Reflection.Enum.eBoolean ChopTopIsOn
        {
            get => this._choptop_is_on;
            set
            {
                if (System.Enum.IsDefined(typeof(Reflection.Enum.eBoolean), value))
                {
                    this._choptop_is_on = value;
                    this.Modified = true;
                }
                else
                    throw new System.ArgumentOutOfRangeException("Value passed is not of boolean type.");
            }
        }

        /// <summary>
        /// Choptop size value of the preset car. Range: 0-100.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        public byte ChopTopSize
        {
            get => this._choptop_size;
            set
            {
                if (value > 100)
                    throw new System.ArgumentOutOfRangeException("This value should be in range 0 to 100.");
                else
                    this._choptop_size = value;
                this.Modified = true;
            }
        }
    }
}