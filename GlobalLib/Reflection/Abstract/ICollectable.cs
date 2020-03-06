namespace GlobalLib.Reflection.Abstract
{
	public abstract class ICollectable
	{
		public abstract string ThisPath { get; set; }
		public abstract string GetChildPath();
	}
}