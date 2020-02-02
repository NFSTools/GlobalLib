namespace GlobalLib.Support.Shared.Class
{
    public partial class PresetRide : Reflection.Interface.IGetValue, Reflection.Interface.ISetValue
    {
        private string _pvehicle = "supra";

        /// <summary>
        /// Represents pvehicle name of the preset ride.
        /// </summary>
        public string Pvehicle
        {
            get => this._pvehicle;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new System.ArgumentNullException();
                this._pvehicle = value;
            }
        }
    }
}