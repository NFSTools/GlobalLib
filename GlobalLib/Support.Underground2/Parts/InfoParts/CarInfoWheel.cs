namespace GlobalLib.Support.Underground2.Parts.InfoParts
{
	public class CarInfoWheel : Framework.VirtualPart, Reflection.Interface.ICopyable<CarInfoWheel>
	{
		public float XValue { get; set; }
		public float Springs { get; set; }
		public float RideHeight { get; set; }
		public float UnknownVal { get; set; }
		public float Diameter { get; set; }
		public float TireSkidWidth { get; set; }
		public int WheelID { get; set; }
		public float YValue { get; set; }
		public float WideBodyYValue { get; set; }

		public CarInfoWheel() { }

		public CarInfoWheel(int ID)
		{
			this.WheelID = ID;
		}

        /// <summary>
        /// Creates a plane copy of the objects that contains same values.
        /// </summary>
        /// <returns>Exact plain copy of the object.</returns>
        public CarInfoWheel PlainCopy()
        {
            var result = new CarInfoWheel();
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