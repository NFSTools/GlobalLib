namespace GlobalLib.Database
{
	public partial class Carbon
	{
		private void Initialize()
		{
			this.CarTypeInfos = new Collection.Binary<CarTypeInfo>();
			this.Materials = new Collection.Binary<Material>();
			this.PresetRides = new Collection.Binary<PresetRide>();
			this.PresetSkins = new Collection.Binary<PresetSkin>();
			
			
			
			
			
			this.FNGroups = new List<FNGroup>();
			this.TPKBlocks = new List<TPKBlock>();
			this.SlotTypes = new SlotType();
			this.STRBlocks = new STRBlock();

		}
	}
}