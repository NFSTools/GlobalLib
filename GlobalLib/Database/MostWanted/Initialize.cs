using System.Collections.Generic;
using GlobalLib.Database.Collection;
using GlobalLib.Support.MostWanted.Class;



namespace GlobalLib.Database
{
	public partial class MostWanted
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
				true
			);

			this.CarTypeInfos = new Binary<CarTypeInfo>
			(
				"CarTypeInfos",
				CarTypeInfo.MaxCNameLength,
				CarTypeInfo.CNameOffsetAt,
				CarTypeInfo.BaseClassSize,
				true,
				true
			);

			this.PresetRides = new Binary<PresetRide>
			(
				"PresetRides",
				PresetRide.MaxCNameLength,
				PresetRide.CNameOffsetAt,
				PresetRide.BaseClassSize,
				true,
				true
			);

			this.FNGroups = new List<FNGroup>();
			this.TPKBlocks = new List<TPKBlock>();
			this.SlotTypes = new SlotType();
			this.STRBlocks = new STRBlock();
		}
	}
}