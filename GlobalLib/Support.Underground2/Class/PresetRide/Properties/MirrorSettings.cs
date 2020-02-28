namespace GlobalLib.Support.Underground2.Class
{
	public partial class PresetRide : Shared.Class.PresetRide, Reflection.Interface.ICastable<PresetRide>
	{
		private byte _wing_mirror_style = 0;

        /// <summary>
        /// Wing mirror style value of the preset ride. Range: 0-40.
        /// </summary>
        public byte WingMirrorStyle
        {
            get => this._wing_mirror_style;
            set
            {
                if (value > 40)
                    throw new System.ArgumentOutOfRangeException("This value should be in range 0 to 40.");
                else
                    this._wing_mirror_style = value;
                this.Modified = true;
            }
        }
    }
}