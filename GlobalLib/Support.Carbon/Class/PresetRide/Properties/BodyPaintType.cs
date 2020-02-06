namespace GlobalLib.Support.Carbon.Class
{
    public partial class PresetRide : Shared.Class.PresetRide, Reflection.Interface.ICastable<PresetRide>
    {
        private string _painttype = Reflection.BaseArguments.PPAINT;

        /// <summary>
        /// Paint type value of the preset ride.
        /// </summary>
        public string PaintType
        {
            get => this._painttype;
            set
            {
                if (Core.Map.BinKeys.ContainsValue(value))
                    this._painttype = value;
                else
                    throw new Reflection.Exception.MappingFailException();
                this.Modified = true;
            }
        }
    }
}