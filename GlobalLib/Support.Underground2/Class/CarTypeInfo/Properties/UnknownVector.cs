namespace GlobalLib.Support.Underground2.Class
{
	public partial class CarTypeInfo : Shared.Class.CarTypeInfo, Reflection.Interface.ICastable<CarTypeInfo>
	{
		[Reflection.Attributes.AccessModifiable()]
		/* 0x0110 */ public float UnknownVectorValX { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		/* 0x0114 */ public float UnknownVectorValY { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		/* 0x0118 */ public float UnknownVectorValZ { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		/* 0x011C */ public float UnknownVectorValW { get; set; }
	}
}