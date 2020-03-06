namespace GlobalLib.Support.Underground2.Parts.InfoParts
{
	public class Brakes : VirtualBase, Reflection.Interface.ICopyable<Brakes>
	{
		public float FrontDownForce { get; set; }
		public float RearDownForce { get; set; } 
		public float BumpJumpForce { get; set; }
		public float SteeringRatio { get; set; }
		public float BrakeStrength { get; set; }
        public float HandBrakeStrength { get; set; }
        public float BrakeBias { get; set; }

        public Brakes() { }

        /// <summary>
        /// Creates a plane copy of the objects that contains same values.
        /// </summary>
        /// <returns>Exact plain copy of the object.</returns>
        public Brakes PlainCopy()
        {
            var result = new Brakes();
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