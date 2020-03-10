namespace GlobalLib.Support.Underground2.Class
{
	public partial class PresetRide
	{
		private byte _front_brake_style = 0;
        private byte _rear_brake_style = 0;

        /// <summary>
        /// Front brake style value of the preset ride. Range: 0-3.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        public byte FrontBrakeStyle
        {
            get => this._front_brake_style;
            set
            {
                if (value > 3)
                    throw new System.ArgumentOutOfRangeException("This value should be in range 0 to 3.");
                else
                    this._front_brake_style = value;
                this.Modified = true;
            }
        }

        /// <summary>
        /// Rear brake style value of the preset ride. Range: 0-3.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        public byte RearBrakeStyle
        {
            get => this._rear_brake_style;
            set
            {
                if (value > 3)
                    throw new System.ArgumentOutOfRangeException("This value should be in range 0 to 3.");
                else
                    this._rear_brake_style = value;
                this.Modified = true;
            }
        }
    }
}