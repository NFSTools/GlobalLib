namespace GlobalLib.Support.Carbon.Class
{
    public partial class PresetRide : Shared.Class.PresetRide, Reflection.Interface.ICastable<PresetRide>
    {
        private string _specific_vinyl = Reflection.BaseArguments.NULL;
        private string _generic_vinyl = Reflection.BaseArguments.NULL;

        /// <summary>
        /// Specific vinyl value of the preset ride.
        /// </summary>
        public string SpecificVinyl
        {
            get => this._specific_vinyl;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new System.ArgumentNullException();
                this._specific_vinyl = value;
                this.Modified = true;
            }
        }

        /// <summary>
        /// Generic vinyl value of the preset car.
        /// </summary>
        public string GenericVinyl
        {
            get => this._generic_vinyl;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new System.ArgumentNullException();
                this._generic_vinyl = value;
                this.Modified = true;
            }
        }
    }
}