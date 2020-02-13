namespace GlobalLib.Support.MostWanted.Class
{
    public partial class PresetRide : Shared.Class.PresetRide, Reflection.Interface.ICastable<PresetRide>
    {
        private string _bodypaint = Reflection.BaseArguments.BPAINT;

        /// <summary>
        /// Body paint value of the preset ride.
        /// </summary>
        public string BodyPaint
        {
            get => this._bodypaint;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new System.ArgumentNullException("This value cannot be left empty.");
                if (Core.Map.BinKeys.ContainsValue(value))
                    this._bodypaint = value;
                else
                    throw new Reflection.Exception.MappingFailException();
                this.Modified = true;
            }
        }
    }
}