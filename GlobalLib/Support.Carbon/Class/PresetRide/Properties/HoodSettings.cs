namespace GlobalLib.Support.Carbon.Class
{
    public partial class PresetRide : Shared.Class.PresetRide, Reflection.Interface.ICastable<PresetRide>
    {
        private byte _hood_style = 0;
        private bool _is_autosculpt_hood = false;
        private bool _is_carbonfibre_hood = false;

        /// <summary>
        /// Hood style value of the preset ride. Range: 0-8.
        /// </summary>
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
        public bool IsAutosculptHood
        {
            get => this._is_autosculpt_hood;
            set
            {
                this._is_autosculpt_hood = value;
                this.Modified = true;
            }
        }

        /// <summary>
        /// True if hood is carbonfibre, false otherwise.
        /// </summary>
        public bool IsCarbonfibreHood
        {
            get => this._is_carbonfibre_hood;
            set
            {
                this._is_carbonfibre_hood = value;
                this.Modified = true;
            }
        }
    }
}