namespace GlobalLib.Support.Carbon.Class
{
    public partial class PresetRide
    {
        private Reflection.Enum.eCarbonPaint _painttype = Reflection.Enum.eCarbonPaint.GLOSS;

        /// <summary>
        /// Paint type value of the preset ride.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        public Reflection.Enum.eCarbonPaint PaintType
        {
            get => this._painttype;
            set
            {
                if (System.Enum.IsDefined(typeof(Reflection.Enum.eCarbonPaint), value))
                {
                    this._painttype = value;
                    this.Modified = true;
                }
                else
                    throw new Reflection.Exception.MappingFailException();
            }
        }
    }
}