namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class SunInfo
	{
		/* 0x0000 */ public int Version { get; set; } = 2;
		/* 0x0020 */ public float PositionX { get; set; }
		/* 0x0024 */ public float PositionY { get; set; }
		/* 0x0028 */ public float PositionZ { get; set; }
		/* 0x002c */ public float CarShadowPositionX { get; set; }
		/* 0x0030 */ public float CarShadowPositionY { get; set; }
		/* 0x0034 */ public float CarShadowPositionZ { get; set; }
	}
}