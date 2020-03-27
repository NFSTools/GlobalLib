namespace GlobalLib.Support.Carbon.Class
{
    public partial class PresetRide
    {
        private Reflection.Enum.eCarbonPaint _paint_type = Reflection.Enum.eCarbonPaint.GLOSS;

        /// <summary>
        /// Paint type value of the preset ride.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        public Reflection.Enum.eCarbonPaint PaintType
        {
            get => this._paint_type;
            set
            {
                if (System.Enum.IsDefined(typeof(Reflection.Enum.eCarbonPaint), value))
                {
                    this._paint_type = value;
                    this.Modified = true;
                }
                else
                    throw new Reflection.Exception.MappingFailException();
            }
        }
    }
}