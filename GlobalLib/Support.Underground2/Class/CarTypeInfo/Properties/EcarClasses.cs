using GlobalLib.Reflection.Attributes;
using GlobalLib.Support.Underground2.Parts.InfoParts;

namespace GlobalLib.Support.Underground2.Class
{
	public partial class CarTypeInfo
	{
		/* General */
		[Expandable("General")]
		public Ecar ECAR { get; set; }

		[Expandable("General")]
		public Pvehicle PVEHICLE { get; set; }


		/* 0x0120 - 0x0144 */
		[Expandable("Wheels")]
		public CarInfoWheel WHEEL_FRONT_LEFT { get; set; }

		/* 0x0150 - 0x0174 */
		[Expandable("Wheels")]
		public CarInfoWheel WHEEL_FRONT_RIGHT { get; set; }

		/* 0x0180 - 0x01A4 */
		[Expandable("Wheels")]
		public CarInfoWheel WHEEL_REAR_RIGHT { get; set; }

		/* 0x01B0 - 0x01D4 */
		[Expandable("Wheels")]
		public CarInfoWheel WHEEL_REAR_LEFT { get; set; }


		/* 0x0730 - 0x0740 */
		[Expandable("PlayerCamera")]
		public Camera PLAYER_CAMERA_FAR { get; set; }

		/* 0x0740 - 0x0750 */
		[Expandable("PlayerCamera")]
		public Camera PLAYER_CAMERA_CLOSE { get; set; }

		/* 0x0750 - 0x0760 */
		[Expandable("PlayerCamera")]
		public Camera PLAYER_CAMERA_BUMPER { get; set; }

		/* 0x0760 - 0x0770 */
		[Expandable("PlayerCamera")]
		public Camera PLAYER_CAMERA_DRIVER { get; set; }

		/* 0x0770 - 0x0780 */
		[Expandable("PlayerCamera")]
		public Camera PLAYER_CAMERA_HOOD { get; set; }

		/* 0x0780 - 0x0790 */
		[Expandable("PlayerCamera")]
		public Camera PLAYER_CAMERA_DRIFT { get; set; }


		/* 0x0790 - 0x07A0 */
		[Expandable("AICamera")]
		public Camera AI_CAMERA_FAR { get; set; }

		/* 0x07A0 - 0x07B0 */
		[Expandable("AICamera")]
		public Camera AI_CAMERA_CLOSE { get; set; }

		/* 0x07B0 - 0x07C0 */
		[Expandable("AICamera")]
		public Camera AI_CAMERA_BUMPER { get; set; }

		/* 0x07C0 - 0x07D0 */
		[Expandable("AICamera")]
		public Camera AI_CAMERA_DRIVER { get; set; }

		/* 0x07D0 - 0x07E0 */
		[Expandable("AICamera")]
		public Camera AI_CAMERA_HOOD { get; set; }

		/* 0x07E0 - 0x07F0 */
		[Expandable("AICamera")]
		public Camera AI_CAMERA_DRIFT { get; set; }
	}
}