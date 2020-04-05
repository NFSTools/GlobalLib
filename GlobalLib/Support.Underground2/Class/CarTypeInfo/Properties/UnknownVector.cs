using GlobalLib.Reflection.Attributes;

namespace GlobalLib.Support.Underground2.Class
{
	public partial class CarTypeInfo
	{
		[AccessModifiable()]
        [StaticModifiable()]
		public float UnknownVectorValX { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public float UnknownVectorValY { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public float UnknownVectorValZ { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public float UnknownVectorValW { get; set; }
	}
}