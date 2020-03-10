namespace GlobalLib.Support.Shared.Class
{
    public partial class PresetRide
    {
        private string _frontend = "supra";

        /// <summary>
        /// Represents frontend name of the preset ride.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        public virtual string Frontend
        {
            get => this._frontend;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new System.ArgumentNullException("This value cannot be left empty.");
                this._frontend = value;
            }
        }
    }
}