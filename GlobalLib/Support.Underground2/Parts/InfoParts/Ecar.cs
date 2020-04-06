using GlobalLib.Reflection.Abstract;
using GlobalLib.Reflection.Interface;

namespace GlobalLib.Support.Underground2.Parts.InfoParts
{
	public class Ecar : SubPart, ICopyable<Ecar>
	{
		public float EcarUnknown1 { get; set; } = 2F;
		public float EcarUnknown2 { get; set; } = 3F;
		public float HandlingBuffer { get; set; }
		public float TopSuspFrontHeightReduce { get; set; }
		public float TopSuspRearHeightReduce { get; set; }
		public int NumPlayerCameras { get; set; } = 6;
		public int NumAICameras { get; set; } = 6;
        public int Cost { get; set; }

		public Ecar() { }

        /// <summary>
        /// Creates a plain copy of the objects that contains same values.
        /// </summary>
        /// <returns>Exact plain copy of the object.</returns>
        public Ecar PlainCopy()
        {
            var result = new Ecar();
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
