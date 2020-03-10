namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class SunInfo
	{
		[Reflection.Attributes.AccessModifiable()]
		/* 0x0000 */ public int Version { get; set; } = 2;

		[Reflection.Attributes.AccessModifiable()]
		/* 0x0020 */ public float PositionX { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		/* 0x0024 */ public float PositionY { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		/* 0x0028 */ public float PositionZ { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		/* 0x002c */ public float CarShadowPositionX { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		/* 0x0030 */ public float CarShadowPositionY { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		/* 0x0034 */ public float CarShadowPositionZ { get; set; }
	}
}