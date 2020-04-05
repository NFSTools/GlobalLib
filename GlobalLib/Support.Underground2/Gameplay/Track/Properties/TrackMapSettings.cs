using GlobalLib.Reflection.Attributes;

namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class Track
	{
		[AccessModifiable()]
		[StaticModifiable()]
		public float TrackMapCalibrationOffsetX { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public float TrackMapCalibrationOffsetY { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public float TrackMapCalibrationWidth { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public float TrackMapCalibrationRotation { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public float TrackMapCalibrationZoomIn { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public float TrackMapStartgridAngle { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public float TrackMapFinishlineAngle { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public float MenuMapZoomOffsetX { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public float MenuMapZoomOffsetY { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public float MenuMapZoomWidth { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public int MenuMapStartZoomed { get; set; }
	}
}