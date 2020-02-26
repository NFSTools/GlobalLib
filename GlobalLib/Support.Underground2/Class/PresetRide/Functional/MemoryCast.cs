namespace GlobalLib.Support.Underground2.Class
{
	public partial class PresetRide : Shared.Class.PresetRide, Reflection.Interface.ICastable<PresetRide>
	{
		public PresetRide MemoryCast(string CName)
		{
			return new PresetRide();
		}
	}
}