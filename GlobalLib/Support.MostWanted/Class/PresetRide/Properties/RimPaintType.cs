namespace GlobalLib.Support.MostWanted.Class
{
    public partial class PresetRide
    {
        private string _rim_paint = Reflection.BaseArguments.NULL;

        /// <summary>
        /// Rim paint value of the preset ride.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        [Reflection.Attributes.StaticModifiable()]
        public string RimPaint
        {
            get => this._rim_paint;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new System.ArgumentNullException("This value cannot be left empty.");
                if (value == Reflection.BaseArguments.NULL || Core.Map.BinKeys.ContainsValue(value))
                    this._rim_paint = value;
                else
                    throw new Reflection.Exception.MappingFailException();
                this.Modified = true;
            }
        }
    }
}