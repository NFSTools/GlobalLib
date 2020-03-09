namespace GlobalLib.Support.Underground2.Parts.InfoParts
{
	public class Camera : Framework.VirtualPart, Reflection.Interface.ICopyable<Camera>
	{
		public float CameraAngle { get; set; }
		public float CameraLag { get; set; }
		public float CameraHeight { get; set; }
		public float CameraLatOffset { get; set; }

		public Camera() { }

		/// <summary>
		/// Creates a plane copy of the objects that contains same values.
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

	public enum CameraType : short
	{
		FAR,
		CLOSE,
		BUMPER,
		DRIVER,
		HOOD,
		DRIFT
	}
}