namespace GlobalLib.Support.Carbon.Class
{
    public partial class PresetRide : Shared.Class.PresetRide, Reflection.Interface.ICastable<PresetRide>
    {
        private byte _number_of_vinyls = 0;

        /// <summary>
        /// Number of vinyls value of the preset ride. Range: 0-20.
        /// </summary>
        public byte NumberOfVinyls
        {
            get => this._number_of_vinyls;
            set
            {
                if (value > 20)
                    throw new System.ArgumentOutOfRangeException("This value should be in range 0 to 20.");
                else
                    this._number_of_vinyls = value;
                this.Modified = true;
            }
        }
    }
}