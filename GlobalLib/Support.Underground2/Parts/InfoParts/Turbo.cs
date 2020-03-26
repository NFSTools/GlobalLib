namespace GlobalLib.Support.Underground2.Parts.InfoParts
{
	public class Turbo : Reflection.Abstract.SubPart, Reflection.Interface.ICopyable<Turbo>
	{
		public float TurboBraking { get; set; }
		public float TurboVacuum { get; set; }
		public float TurboHeatHigh { get; set; }
		public float TurboHeatLow { get; set; }
		public float TurboHighBoost { get; set; }
		public float TurboLowBoost { get; set; }
		public float TurboSpool { get; set; }
		public float TurboSpoolTimeDown { get; set; }
		public float TurboSpoolTimeUp { get; set; }

		public Turbo() { }

		/// <summary>
		/// Creates a plane copy of the objects that contains same values.
		/// </summary>
		/// <returns>Exact plain copy of the object.</returns>
		public Turbo PlainCopy()
		{
			var result = new Turbo();
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
