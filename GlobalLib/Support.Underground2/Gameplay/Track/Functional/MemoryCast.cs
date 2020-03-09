namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class Track : Reflection.Interface.ICastable<Track>, Reflection.Interface.IGetValue,
		Reflection.Interface.ISetValue
	{
		public Track MemoryCast(string CName)
		{
			return new Track();
		}
	}
}