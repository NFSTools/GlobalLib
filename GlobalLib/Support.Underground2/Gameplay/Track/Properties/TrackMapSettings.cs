namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class Track
	{
		[Reflection.Attributes.AccessModifiable()]
		public float TrackMapCalibrationOffsetX { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		public float TrackMapCalibrationOffsetY { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		public float TrackMapCalibrationWidth { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		public float TrackMapCalibrationRotation { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		public float TrackMapCalibrationZoomIn { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		public float TrackMapStartgridAngle { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		public float TrackMapFinishlineAngle { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		public float MenuMapZoomOffsetX { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		public float MenuMapZoomOffsetY { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		public float MenuMapZoomWidth { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		public int MenuMapStartZoomed { get; set; }
	}
}