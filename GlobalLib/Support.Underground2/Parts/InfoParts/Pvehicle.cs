namespace GlobalLib.Support.Underground2.Parts.InfoParts
{
	public class Pvehicle : Reflection.Abstract.SubPart, Reflection.Interface.ICopyable<Pvehicle>
	{
		public float Massx1000Multiplier { get; set; } = 1;
        public float TensorScaleX { get; set; } = 4;
        public float TensorScaleY { get; set; } = 3;
        public float TensorScaleZ { get; set; } = 2;
        public float TensorScaleW { get; set; } = 1;
        public float InitialHandlingRating { get; set; }
        public float TopSpeedUnderflow { get; set; }
        public float StockTopSpeedLimiter { get; set; }

        public Pvehicle() { }

        /// <summary>
        /// Creates a plane copy of the objects that contains same values.
        /// </summary>
        /// <returns>Exact plain copy of the object.</returns>
        public Pvehicle PlainCopy()
        {
            var result = new Pvehicle();
            var ThisType = this.GetType();
            var ResultType = result.GetType();
            foreach (var ThisProperty in ThisType.GetProperties())
            {
                var ResultField = ResultType.GetProperty(ThisProperty.Name);
                ResultField.SetValue(result, ThisProperty.GetValue(this));
            }
            return result;
        }
    }
}
