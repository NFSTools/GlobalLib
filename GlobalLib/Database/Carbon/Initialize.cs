using System.Collections.Generic;
using GlobalLib.Database.Collection;
using GlobalLib.Support.Carbon.Class;



namespace GlobalLib.Database
{
	public partial class Carbon
	{
		private void Initialize()
		{
			this.Materials = new Binary<Material>
			(
				"Materials",
				Material.MaxCNameLength,
				Material.CNameOffsetAt,
				Material.BaseClassSize,
				true,
				true,
				this
			);

			this.CarTypeInfos = new Binary<CarTypeInfo>
			(
				"CarTypeInfos",
				CarTypeInfo.MaxCNameLength,
				CarTypeInfo.CNameOffsetAt,
				CarTypeInfo.BaseClassSize,
				true,
				true,
				this
			);

			this.PresetRides = new Binary<PresetRide>
			(
				"PresetRides",
				PresetRide.MaxCNameLength,
				PresetRide.CNameOffsetAt,
				PresetRide.BaseClassSize,
				true,
				true,
				this
			);

			this.PresetSkins = new Binary<PresetSkin>
			(
				"PresetSkins",
				PresetSkin.MaxCNameLength,
				PresetSkin.CNameOffsetAt,
				PresetSkin.BaseClassSize,
				true,
				true,
				this
			);
			
			this.FNGroups = new List<FNGroup>();
			this.TPKBlocks = new List<TPKBlock>();
			this.SlotTypes = new SlotType();
			this.STRBlocks = new STRBlock();
		}
	}
}