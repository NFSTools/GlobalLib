namespace GlobalLib.Support.Shared.Class
{
    public partial class PresetRide : Reflection.Interface.IGetValue, Reflection.Interface.ISetValue
    {
        private string _model = "SUPRA";

        /// <summary>
        /// Represents model of the preset ride.
        /// </summary>
        public string MODEL
        {
            get => this._model;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new System.ArgumentNullException("This value cannot be left empty.");
                else
                    this._model = value;
            }
        }
    }
}