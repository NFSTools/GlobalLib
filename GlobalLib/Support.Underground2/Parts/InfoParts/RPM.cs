namespace GlobalLib.Support.Underground2.Parts.InfoParts
{
	public class RPM : VirtualBase, Reflection.Interface.ICopyable<RPM>
	{
		public float IdleRPM { get; set; }
		public float RedLineRPM { get; set; }
		public float MAXRPM { get; set; }

		public RPM() { }

		/// <summary>
		/// Creates a plane copy of the objects that contains same values.
		/// </summary>
		/// <returns>Exact plain copy of the object.</returns>
		public RPM PlainCopy()
		{
			var result = new RPM();
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
