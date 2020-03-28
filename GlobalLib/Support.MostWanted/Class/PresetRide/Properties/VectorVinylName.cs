namespace GlobalLib.Support.MostWanted.Class
{
    public partial class PresetRide
    {
        private string _vinylname = Reflection.BaseArguments.NULL;

        /// <summary>
        /// Vinyl name value of the preset ride.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        [Reflection.Attributes.StaticModifiable()]
        public string VinylName
        {
            get => this._vinylname;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new System.ArgumentNullException("This value cannot be left empty.");
                this._vinylname = value;
                this.Modified = true;
            }
        }
    }
}