namespace GlobalLib.Support.MostWanted.Class
{
    public partial class PresetRide
    {
        private string _rimpaint = Reflection.BaseArguments.NULL;

        /// <summary>
        /// Rim paint value of the preset ride.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        public string RimPaint
        {
            get => this._rimpaint;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new System.ArgumentNullException("This value cannot be left empty.");
                if (value == Reflection.BaseArguments.NULL || Core.Map.BinKeys.ContainsValue(value))
                    this._rimpaint = value;
                else
                    throw new Reflection.Exception.MappingFailException();
                this.Modified = true;
            }
        }
    }
}