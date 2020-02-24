namespace GlobalLib.Support.Underground2.Class
{
	public partial class CarTypeInfo : Shared.Class.CarTypeInfo, Reflection.Interface.ICastable<CarTypeInfo>
	{
		public CarTypeInfo MemoryCast(string CName)
		{
			return new CarTypeInfo();
		}
	}
}