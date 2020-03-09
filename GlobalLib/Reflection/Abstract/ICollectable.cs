namespace GlobalLib.Reflection.Abstract
{
	public abstract class ICollectable
	{
		public abstract string CollectionName { get; set; }
		public abstract string[] GetAccessibles();
		public abstract bool OfEnumerableType(string property);
		public abstract string[] GetPropertyEnumerableTypes(string property);
	}
}