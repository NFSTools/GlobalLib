namespace GlobalLib.Support.Underground2.Parts.InfoParts
{
	public class WeightReduction : Reflection.Abstract.SubPart, Reflection.Interface.ICopyable<WeightReduction>
	{
        public float WeightReductionMassMultiplier { get; set; }
        public float WeightReductionGripAddon { get; set; }
        public float WeightReductionHandlingRating { get; set; }

		public WeightReduction() { }

        /// <summary>
        /// Creates a plain copy of the objects that contains same values.
        /// </summary>
        /// <returns>Exact plain copy of the object.</returns>
        public WeightReduction PlainCopy()
        {
            var result = new WeightReduction();
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
