namespace GlobalLib.Support.Underground2.Parts.InfoParts
{
	public class Suspension : Reflection.Abstract.SubPart, Reflection.Interface.ICopyable<Suspension>
	{
		// Front values
		public float ShockStiffnessFront { get; set; }
		public float ShockExtStiffnessFront { get; set; }
		public float SpringProgressionFront { get; set; }
		public float ShockValvingFront { get; set; }
		public float SwayBarFront { get; set; }
		public float TrackWidthFront { get; set; }
		public float CounterBiasFront { get; set; }
		public float ShockDigressionFront { get; set; }

		// Read values
		public float ShockStiffnessRear { get; set; }
		public float ShockExtStiffnessRear { get; set; }
		public float SpringProgressionRear { get; set; }
		public float ShockValvingRear { get; set; }
		public float SwayBarRear { get; set; }
		public float TrackWidthRear { get; set; }
		public float CounterBiasRear { get; set; }
		public float ShockDigressionRear { get; set; }

        public Suspension() { }

        /// <summary>
        /// Creates a plane copy of the objects that contains same values.
        /// </summary>
        /// <returns>Exact plain copy of the object.</returns>
        public Suspension PlainCopy()
        {
            var result = new Suspension();
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
