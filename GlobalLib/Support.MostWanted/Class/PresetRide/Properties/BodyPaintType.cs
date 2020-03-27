namespace GlobalLib.Support.MostWanted.Class
{
    public partial class PresetRide
    {
        private string _body_paint = Reflection.BaseArguments.BPAINT;

        /// <summary>
        /// Body paint value of the preset ride.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        public string BodyPaint
        {
            get => this._body_paint;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new System.ArgumentNullException("This value cannot be left empty.");
                if (Core.Map.BinKeys.ContainsValue(value))
                    this._body_paint = value;
                else
                    throw new Reflection.Exception.MappingFailException();
                this.Modified = true;
            }
        }
    }
}