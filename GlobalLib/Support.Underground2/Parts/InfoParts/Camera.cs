using GlobalLib.Reflection.Abstract;
using GlobalLib.Reflection.Interface;

namespace GlobalLib.Support.Underground2.Parts.InfoParts
{
	public class Camera : SubPart, ICopyable<Camera>
	{
		public float CameraAngle { get; set; }
		public float CameraLag { get; set; }
		public float CameraHeight { get; set; }
		public float CameraLatOffset { get; set; }

		public Camera() { }

		/// <summary>
		/// Creates a plain copy of the objects that contains same values.
		/// </summary>
		/// <returns>Exact plain copy of the object.</returns>
		public Camera PlainCopy()
		{
			var result = new Camera();
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