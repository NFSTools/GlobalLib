using GlobalLib.Reflection.Attributes;
using GlobalLib.Support.Underground1.Parts.GameParts;

namespace GlobalLib.Support.Underground1.Gameplay
{
	public partial class SunInfo
	{
		/* 0x0038 - 0x005C */
		[Expandable("SunLayers")]
		public SunLayer SUNLAYER1 { get; set; }

		/* 0x005C - 0x0080 */
		[Expandable("SunLayers")]
		public SunLayer SUNLAYER2 { get; set; }
		
		/* 0x0080 - 0x00A4 */
		[Expandable("SunLayers")]
		public SunLayer SUNLAYER3 { get; set; }
		
		/* 0x00A4 - 0x00C8 */
		[Expandable("SunLayers")]
		public SunLayer SUNLAYER4 { get; set; }
		
		/* 0x00C8 - 0x00EC */
		[Expandable("SunLayers")]
		public SunLayer SUNLAYER5 { get; set; }
		
		/* 0x00EC - 0x0110 */
		[Expandable("SunLayers")]
		public SunLayer SUNLAYER6 { get; set; }
	}
}