using System.Collections.Generic;
using GlobalLib.Database.Collection;
using GlobalLib.Support.Underground2.Class;
using GlobalLib.Support.Underground2.Gameplay;



namespace GlobalLib.Database
{
	public partial class Underground2
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

			this.Tracks = new Root<Track>
			(
				"Tracks",
				Track.MaxCNameLength,
				Track.CNameOffsetAt,
				Track.BaseClassSize,
				true,
				false,
				this
			);

			this.GCareerRaces = new Root<GCareerRace>
			(
				"GCareerRaces",
				-1,
				-1,
				-1,
				true,
				false,
				this
			);

			this.WorldShops = new Root<WorldShop>
			(
				"WorldShops",
				0x1F,
				-1,
				-1,
				true,
				false,
				this
			);

			this.GCareerBrands = new Root<GCareerBrand>
			(
				"GCareerBrands",
				0x1F,
				-1,
				-1,
				true,
				false,
				this
			);


			this.PartPerformances = new Root<PartPerformance>
			(
				"PartPerformances",
				-1,
				-1,
				-1,
				true,
				false,
				this
			);

			this.GShowcases = new Root<GShowcase>
			(
				"GShowcases",
				0x1F,
				-1,
				-1,
				true,
				false,
				this
			);

			this.SMSMessages = new Root<SMSMessage>
			(
				"SMSMessages",
				-1,
				-1,
				-1,
				false,
				false,
				this
			);

			this.Sponsors = new Root<Sponsor>
			(
				"Sponsors",
				-1,
				-1,
				-1,
				true,
				false,
				this
			);

			this.GCareerStages = new Root<GCareerStage>
			(
				"GCareerStages",
				-1,
				-1,
				-1,
				false,
				false,
				this
			);

			this.PerfSliderTunings = new Root<PerfSliderTuning>
			(
				"PerfSliderTunings",
				-1,
				-1,
				-1,
				false,
				false,
				this
			);

			this.WorldChallenges = new Root<WorldChallenge>
			(
				"WorldChallenges",
				-1,
				-1,
				-1,
				true,
				false,
				this
			);

			this.PartUnlockables = new Root<PartUnlockable>
			(
				"PartUnlockables",
				-1,
				-1,
				-1,
				false,
				false,
				this
			);

			this.BankTriggers = new Root<BankTrigger>
			(
				"BankTriggers",
				-1,
				-1,
				-1,
				true,
				true,
				this
			);

			this.GCarUnlocks = new Root<GCarUnlock>
			(
				"GCarUnlocks",
				-1,
				-1,
				-1,
				true,
				false,
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