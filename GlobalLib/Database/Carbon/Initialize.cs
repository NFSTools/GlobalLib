using GlobalLib.Database.Collection;
using GlobalLib.Support.Carbon.Class;



namespace GlobalLib.Database
{
	public partial class Carbon
	{
		private void Initialize()
		{
			this.Materials = new Root<Material>
			(
				"Materials",
				Material.MaxCNameLength,
				Material.CNameOffsetAt,
				Material.BaseClassSize,
				true,
				true,
				this
			);

			this.CarTypeInfos = new Root<CarTypeInfo>
			(
				"CarTypeInfos",
				CarTypeInfo.MaxCNameLength,
				CarTypeInfo.CNameOffsetAt,
				CarTypeInfo.BaseClassSize,
				true,
				true,
				this
			);

			this.PresetRides = new Root<PresetRide>
			(
				"PresetRides",
				PresetRide.MaxCNameLength,
				PresetRide.CNameOffsetAt,
				PresetRide.BaseClassSize,
				true,
				true,
				this
			);

			this.PresetSkins = new Root<PresetSkin>
			(
				"PresetSkins",
				PresetSkin.MaxCNameLength,
				PresetSkin.CNameOffsetAt,
				PresetSkin.BaseClassSize,
				true,
				true,
				this
			);

			this.FNGroups = new Root<FNGroup>
			(
				"FNGroups",
				-1,
				-1,
				-1,
				false,
				false,
				this
			);

			this.TPKBlocks = new Root<TPKBlock>
			(
				"TPKBlocks",
				-1,
				-1,
				-1,
				false,
				false,
				this
			);

			this.STRBlocks = new Root<STRBlock>
			(
				"STRBlocks",
				-1,
				-1,
				-1,
				false,
				false,
				this
			);

			this.SlotTypes = new SlotType();
		}
	}
}