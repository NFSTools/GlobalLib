namespace GlobalLib.Database
{
	public partial class MostWanted
	{
		private void Initialize()
		{
			this.CarTypeInfos = new Collection.Binary<CarTypeInfo>();
			this.Materials = new Collection.Binary<Material>();
			this.PresetRides = new Collection.Binary<PresetRide>();
			this.FNGroups = new List<FNGroup>();
			this.TPKBlocks = new List<TPKBlock>();
			this.SlotTypes = new SlotType();
			this.STRBlocks = new STRBlock();
		}
	}
}