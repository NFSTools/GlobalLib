using GlobalLib.Reflection.Abstract;
using GlobalLib.Reflection.Interface;

namespace GlobalLib.Support.Underground2.Parts.InfoParts
{
	public class Tires : SubPart, ICopyable<Tires>
	{
		public float StaticGripScale { get; set; }
		public float YawSpeedScale { get; set; } 
		public float SteeringAmplifier { get; set; }
		public float DynamicGripScale { get; set; }
		public float SteeringResponse { get; set; }
        public float DriftYawControl { get; set; }
        public float DriftCounterSteerBuildUp { get; set; }
        public float DriftCounterSteerReduction { get; set; }
        public float PowerSlideBreakThru1 { get; set; }
        public float PowerSlideBreakThru2 { get; set; }

        public Tires() { }

        /// <summary>
        /// Creates a plain copy of the objects that contains same values.
        /// </summary>
        /// <returns>Exact plain copy of the object.</returns>
        public Tires PlainCopy()
        {
            var result = new Tires();
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