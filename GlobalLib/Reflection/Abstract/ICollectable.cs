namespace GlobalLib.Reflection.Abstract
{
	public abstract class ICollectable
	{
		public abstract string ThisPath { get; set; }
		protected abstract string FormThisPath();
	}
}