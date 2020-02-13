namespace GlobalLib.Support.Carbon.Class
{
    public partial class PresetRide : Shared.Class.PresetRide, Reflection.Interface.ICastable<PresetRide>
    {
        private bool _popup_headlights_exist = false;
        private bool _popup_heaglights_on = false;
        private bool _choptop_is_on = false;
        private byte _choptop_size = 0;

        /// <summary>
        /// True if popup headlights of the preset ride model exist, false otherwise.
        /// </summary>
        public bool PopupHeadlightsExist
        {
            get => this._popup_headlights_exist;
            set
            {
                this._popup_headlights_exist = value;
                this.Modified = true;
            }
        }

        /// <summary>
        /// True if preset ride's popup headlights are on, false otherwise.
        /// </summary>
        public bool PopupHeadlightsOn
        {
            get => this._popup_heaglights_on;
            set
            {
                this._popup_heaglights_on = value;
                this.Modified = true;
            }
        }

        /// <summary>
        /// True if preset ride's roof is a chop top, false otherwise.
        /// </summary>
        public bool ChopTopIsOn
        {
            get => this._choptop_is_on;
            set
            {
                this._choptop_is_on = value;
                this.Modified = true;
            }
        }

        /// <summary>
        /// Choptop size value of the preset car. Range: 0-100.
        /// </summary>
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