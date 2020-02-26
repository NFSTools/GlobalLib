namespace GlobalLib.Support.Underground2.Class
{
	public partial class PresetRide : Shared.Class.PresetRide, Reflection.Interface.ICastable<PresetRide>
	{
        private byte _roofscoop_style = 0;
        private bool _is_offset_roofscoop = false;
        private bool _is_dual_roofscoop = false;
        private bool _is_carbonfibre_roofscoop = false;

        /// <summary>
        /// RoofScoop style value of the preset ride. Range: 0-17.
        /// </summary>
        public byte RoofScoopStyle
        {
            get => this._roofscoop_style;
            set
            {
                if (value > 17)
                    throw new System.ArgumentOutOfRangeException("This value should be in range 0 to 18.");
                else
                    this._roofscoop_style = value;
                this.Modified = true;
            }
        }

        /// <summary>
        /// True if roof scoop is offset, false otherwise.
        /// </summary>
        public bool IsOffsetRoofScoop
        {
            get => this._is_offset_roofscoop;
            set
            {
                this._is_offset_roofscoop = value;
                this.Modified = true;
            }
        }

        /// <summary>
        /// True if roof scoop is dual, false otherwise.
        /// </summary>
        public bool IsDualRoofScoop
        {
            get => this._is_dual_roofscoop;
            set
            {
                this._is_dual_roofscoop = value;
                this.Modified = true;
            }
        }

        /// <summary>
        /// True if roof scoop is carbonfibre, false otherwise.
        /// </summary>
        public bool IsCarbonfibreRoofScoop
        {
            get => this._is_carbonfibre_roofscoop;
            set
            {
                this._is_carbonfibre_roofscoop = value;
                this.Modified = true;
            }
        }
    }
}