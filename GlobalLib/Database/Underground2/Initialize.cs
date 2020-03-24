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

			this.SunInfos = new Binary<SunInfo>
			(
				"SunInfos",
				SunInfo.MaxCNameLength,
				SunInfo.CNameOffsetAt,
				SunInfo.BaseClassSize,
				true,
				false
			);

			this.Tracks = new Binary<Track>
			(
				"Tracks",
				Track.MaxCNameLength,
				Track.CNameOffsetAt,
				Track.BaseClassSize,
				true,
				false
			);

			this.GCareerRaces = new Binary<GCareerRace>
			(
				"GCareerRaces",
				-1,
				-1,
				-1,
				true,
				false
			);

			this.WorldShops = new Binary<WorldShop>
			(
				"WorldShops",
				-1,
				-1,
				-1,
				true,
				false
			);

			this.GCareerBrands = new Binary<GCareerBrand>
			(
				"GCareerBrands",
				-1,
				-1,
				-1,
				true,
				false
			);


			this.PartPerformances = new Binary<PartPerformance>
			(
				"PartPerformances",
				-1,
				-1,
				-1,
				true,
				false
			);

			this.GShowcases = new Binary<GShowcase>
			(
				"GShowcases",
				-1,
				-1,
				-1,
				true,
				false
			);

			this.SMSMessages = new Binary<SMSMessage>
			(
				"SMSMessages",
				-1,
				-1,
				-1,
				false,
				false
			);

			this.Sponsors = new Binary<Sponsor>
			(
				"Sponsors",
				-1,
				-1,
				-1,
				true,
				false
			);

			this.GCareerStages = new Binary<GCareerStage>
			(
				"GCareerStages",
				-1,
				-1,
				-1,
				false,
				false
			);

			this.PerfSliderTunings = new Binary<PerfSliderTuning>
			(
				"PerfSliderTunings",
				-1,
				-1,
				-1,
				false,
				false
			);

			this.WorldChallenges = new Binary<WorldChallenge>
			(
				"WorldChallenges",
				-1,
				-1,
				-1,
				true,
				false
			);

			this.PartUnlockables = new Binary<PartUnlockable>
			(
				"PartUnlockables",
				-1,
				-1,
				-1,
				false,
				false
			);

			this.BankTriggers = new Binary<BankTrigger>
			(
				"BankTriggers",
				-1,
				-1,
				-1,
				true,
				true
			);

			this.GCarUnlocks = new Binary<GCarUnlock>
			(
				"GCarUnlocks",
				-1,
				-1,
				-1,
				true,
				false
			);

			this.FNGroups = new List<FNGroup>();
			this.TPKBlocks = new List<TPKBlock>();
			this.SlotTypes = new SlotType();
			this.STRBlocks = new STRBlock();
		}
	}
}