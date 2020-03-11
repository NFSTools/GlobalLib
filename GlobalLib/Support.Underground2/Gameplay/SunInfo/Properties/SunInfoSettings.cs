﻿namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class SunInfo
	{
		/* 0x0038 - 0x005C */
		[Reflection.Attributes.Expandable("SunLayers")]
		public Parts.GameParts.SunLayer SUNLAYER1 { get; set; }

		/* 0x005C - 0x0080 */
		[Reflection.Attributes.Expandable("SunLayers")]
		public Parts.GameParts.SunLayer SUNLAYER2 { get; set; }
		
		/* 0x0080 - 0x00A4 */
		[Reflection.Attributes.Expandable("SunLayers")]
		public Parts.GameParts.SunLayer SUNLAYER3 { get; set; }
		
		/* 0x00A4 - 0x00C8 */
		[Reflection.Attributes.Expandable("SunLayers")]
		public Parts.GameParts.SunLayer SUNLAYER4 { get; set; }
		
		/* 0x00C8 - 0x00EC */
		[Reflection.Attributes.Expandable("SunLayers")]
		public Parts.GameParts.SunLayer SUNLAYER5 { get; set; }
		
		/* 0x00EC - 0x0110 */
		[Reflection.Attributes.Expandable("SunLayers")]
		public Parts.GameParts.SunLayer SUNLAYER6 { get; set; }
	}
}