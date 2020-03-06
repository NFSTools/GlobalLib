namespace GlobalLib.Support.Underground2.Parts.InfoParts
{
	public class Camera : VirtualBase, Reflection.Interface.ICopyable<Camera>
	{
		private CameraType CameraType;
		public short CameraAngle;
		public float CameraLag;
		public float CameraHeight;
		public float CameraLatOffset;

		public Camera() { }

		public Camera(CameraType type)
		{
			this.PlayerCamera_Type = type;
		}

		public Camera(int type)
		{
			this.PlayerCamera_Type = (CameraType)type;
		}

		public short GetCameraType()
		{
			return (short)this.CameraType;
		}

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
		DRIVER,
		BUMPER,
		HOOD,
		DRIFT
	}
}