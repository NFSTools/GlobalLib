namespace GlobalLib.Support.Underground2.Gameplay
{
    public partial class Track
    {
        private string _sun_info_name = Reflection.BaseArguments.NULL;

        /// <summary>
        /// Represents sun type during race.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        public string SunInfoName
        {
            get => this._sun_info_name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new System.ArgumentNullException("This value cannot be left empty.");
                this._sun_info_name = value;
            }
        }
    }
}