namespace GlobalLib.Support.Underground2.Parts.InfoParts
{
	public class Nitrous : Framework.VirtualPart, Reflection.Interface.ICopyable<Nitrous>
	{
		/* 0x0690 */ public float NOSCapacity { get; set; }
		/* 0x069C */ public float NOSTorqueBoost { get; set; }

		public Nitrous() { }

        /// <summary>
        /// Creates a plane copy of the objects that contains same values.
        /// </summary>
        /// <returns>Exact plain copy of the object.</returns>
        public Nitrous PlainCopy()
        {
            var result = new Nitrous();
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
