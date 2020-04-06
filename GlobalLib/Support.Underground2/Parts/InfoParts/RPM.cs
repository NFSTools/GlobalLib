using GlobalLib.Reflection.Abstract;
using GlobalLib.Reflection.Interface;

namespace GlobalLib.Support.Underground2.Parts.InfoParts
{
	public class RPM : SubPart, ICopyable<RPM>
	{
		public float IdleRPMAdd { get; set; }
		public float RedLineRPMAdd { get; set; }
		public float MaxRPMAdd { get; set; }

		public RPM() { }

		/// <summary>
		/// Creates a plain copy of the objects that contains same values.
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
