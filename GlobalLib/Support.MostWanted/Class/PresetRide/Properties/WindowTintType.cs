namespace GlobalLib.Support.MostWanted.Class
{
    public partial class PresetRide : Shared.Class.PresetRide, Reflection.Interface.ICastable<PresetRide>
    {
        private string _window_tint_type = Reflection.BaseArguments.STOCK;

        /// <summary>
        /// Window tint type value of the preset ride.
        /// </summary>
        public string WindowTintType
        {
            get => this._window_tint_type;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new System.ArgumentNullException("This value cannot be left empty.");
                if (value == Reflection.BaseArguments.STOCK || Core.Map.WindowTintMap.Contains(value))
                    this._window_tint_type = value;
                else
                    throw new Reflection.Exception.MappingFailException("This value should be either a valid windshield type, or STOCK.");
                this.Modified = true;
            }
        }
    }
}