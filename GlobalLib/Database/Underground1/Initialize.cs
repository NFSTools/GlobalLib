using System.Collections.Generic;
using GlobalLib.Database.Collection;
using GlobalLib.Support.Underground1.Class;
using GlobalLib.Support.Underground1.Gameplay;



namespace GlobalLib.Database
{
	public partial class Underground1
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

			//this.CarTypeInfos = new Root<CarTypeInfo>
			//(
			//	"CarTypeInfos",
			//	CarTypeInfo.MaxCNameLength,
			//	CarTypeInfo.CNameOffsetAt,
			//	CarTypeInfo.BaseClassSize,
			//	true,
			//	true,
			//	this
			//);

			//this.PresetRides = new Root<PresetRide>
			//(
			//	"PresetRides",
			//	PresetRide.MaxCNameLength,
			//	PresetRide.CNameOffsetAt,
			//	PresetRide.BaseClassSize,
			//	true,
			//	true,
			//	this
			//);

			this.SunInfos = new Root<SunInfo>
			(
				"SunInfos",
				SunInfo.MaxCNameLength,
				SunInfo.CNameOffsetAt,
				SunInfo.BaseClassSize,
				true,
				false,
				this
			);

			//this.Tracks = new Root<Track>
			//(
			//	"Tracks",
			//	Track.MaxCNameLength,
			//	Track.CNameOffsetAt,
			//	Track.BaseClassSize,
			//	true,
			//	false,
			//	this
			//);

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

			//this.SlotTypes = new SlotType();
		}
	}
}