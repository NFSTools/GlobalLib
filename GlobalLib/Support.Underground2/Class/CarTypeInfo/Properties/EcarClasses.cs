namespace GlobalLib.Support.Underground2.Class
{
	public partial class CarTypeInfo
	{
		/* General */
		[Reflection.Attributes.Expandable("ECAR")]
		public Parts.InfoParts.Ecar ECAR { get; set; }

		[Reflection.Attributes.Expandable("PVEHICLE")]
		public Parts.InfoParts.Pvehicle PVEHICLE { get; set; }


		/* 0x0120 - 0x0144 */
		[Reflection.Attributes.Expandable("WHEEL_FRONT_LEFT")]
		public Parts.InfoParts.CarInfoWheel WHEEL_FRONT_LEFT { get; set; }
		
		/* 0x0150 - 0x0174 */
		[Reflection.Attributes.Expandable("WHEEL_FRONT_RIGHT")]
		
		public Parts.InfoParts.CarInfoWheel WHEEL_FRONT_RIGHT { get; set; }
		/* 0x0180 - 0x01A4 */
		
		[Reflection.Attributes.Expandable("WHEEL_REAR_RIGHT")]
		public Parts.InfoParts.CarInfoWheel WHEEL_REAR_RIGHT { get; set; }
		
		/* 0x01B0 - 0x01D4 */
		[Reflection.Attributes.Expandable("WHEEL_REAR_LEFT")]
		public Parts.InfoParts.CarInfoWheel WHEEL_REAR_LEFT { get; set; }


		/* 0x0730 - 0x0740 */
		[Reflection.Attributes.Expandable("PLAYER_CAMERA_FAR")]
		public Parts.InfoParts.Camera PLAYER_CAMERA_FAR { get; set; }
		
		/* 0x0740 - 0x0750 */
		[Reflection.Attributes.Expandable("PLAYER_CAMERA_CLOSE")]
		public Parts.InfoParts.Camera PLAYER_CAMERA_CLOSE { get; set; }
		
		/* 0x0750 - 0x0760 */
		[Reflection.Attributes.Expandable("PLAYER_CAMERA_BUMPER")]
		public Parts.InfoParts.Camera PLAYER_CAMERA_BUMPER { get; set; }
		
		/* 0x0760 - 0x0770 */
		[Reflection.Attributes.Expandable("PLAYER_CAMERA_DRIVER")]
		public Parts.InfoParts.Camera PLAYER_CAMERA_DRIVER { get; set; }
		
		/* 0x0770 - 0x0780 */
		[Reflection.Attributes.Expandable("PLAYER_CAMERA_HOOD")]
		public Parts.InfoParts.Camera PLAYER_CAMERA_HOOD { get; set; }
		
		/* 0x0780 - 0x0790 */
		[Reflection.Attributes.Expandable("PLAYER_CAMERA_DRIFT")]
		public Parts.InfoParts.Camera PLAYER_CAMERA_DRIFT { get; set; }


		/* 0x0790 - 0x07A0 */
		[Reflection.Attributes.Expandable("AI_CAMERA_FAR")]
		public Parts.InfoParts.Camera AI_CAMERA_FAR { get; set; }
		
		/* 0x07A0 - 0x07B0 */
		[Reflection.Attributes.Expandable("AI_CAMERA_CLOSE")]
		public Parts.InfoParts.Camera AI_CAMERA_CLOSE { get; set; }
		
		/* 0x07B0 - 0x07C0 */
		[Reflection.Attributes.Expandable("AI_CAMERA_BUMPER")]
		public Parts.InfoParts.Camera AI_CAMERA_BUMPER { get; set; }
		
		/* 0x07C0 - 0x07D0 */
		[Reflection.Attributes.Expandable("AI_CAMERA_DRIVER")]
		public Parts.InfoParts.Camera AI_CAMERA_DRIVER { get; set; }
		
		/* 0x07D0 - 0x07E0 */
		[Reflection.Attributes.Expandable("AI_CAMERA_HOOD")]
		public Parts.InfoParts.Camera AI_CAMERA_HOOD { get; set; }
		
		/* 0x07E0 - 0x07F0 */
		[Reflection.Attributes.Expandable("AI_CAMERA_DRIFT")]
		public Parts.InfoParts.Camera AI_CAMERA_DRIFT { get; set; }
	}
}