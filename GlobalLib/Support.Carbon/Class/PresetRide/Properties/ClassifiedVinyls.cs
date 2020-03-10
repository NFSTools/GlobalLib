namespace GlobalLib.Support.Carbon.Class
{
    public partial class PresetRide
    {
        private string _specific_vinyl = Reflection.BaseArguments.NULL;
        private string _generic_vinyl = Reflection.BaseArguments.NULL;

        /// <summary>
        /// Specific vinyl value of the preset ride.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        public string SpecificVinyl
        {
            get => this._specific_vinyl;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new System.ArgumentNullException("This value cannot be left empty.");
                this._specific_vinyl = value;
                this.Modified = true;
            }
        }

        /// <summary>
        /// Generic vinyl value of the preset car.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        public string GenericVinyl
        {
            get => this._generic_vinyl;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new System.ArgumentNullException("This value cannot be left empty.");
                this._generic_vinyl = value;
                this.Modified = true;
            }
        }
    }
}