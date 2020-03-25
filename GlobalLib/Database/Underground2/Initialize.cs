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

			this.SunInfos = new Binary<SunInfo>
			(
				"SunInfos",
				SunInfo.MaxCNameLength,
				SunInfo.CNameOffsetAt,
				SunInfo.BaseClassSize,
				true,
				false,
				this
			);

			this.Tracks = new Binary<Track>
			(
				"Tracks",
				Track.MaxCNameLength,
				Track.CNameOffsetAt,
				Track.BaseClassSize,
				true,
				false,
				this
			);

			this.GCareerRaces = new Binary<GCareerRace>
			(
				"GCareerRaces",
				-1,
				-1,
				-1,
				true,
				false,
				this
			);

			this.WorldShops = new Binary<WorldShop>
			(
				"WorldShops",
				-1,
				-1,
				-1,
				true,
				false,
				this
			);

			this.GCareerBrands = new Binary<GCareerBrand>
			(
				"GCareerBrands",
				-1,
				-1,
				-1,
				true,
				false,
				this
			);


			this.PartPerformances = new Binary<PartPerformance>
			(
				"PartPerformances",
				-1,
				-1,
				-1,
				true,
				false,
				this
			);

			this.GShowcases = new Binary<GShowcase>
			(
				"GShowcases",
				-1,
				-1,
				-1,
				true,
				false,
				this
			);

			this.SMSMessages = new Binary<SMSMessage>
			(
				"SMSMessages",
				-1,
				-1,
				-1,
				false,
				false,
				this
			);

			this.Sponsors = new Binary<Sponsor>
			(
				"Sponsors",
				-1,
				-1,
				-1,
				true,
				false,
				this
			);

			this.GCareerStages = new Binary<GCareerStage>
			(
				"GCareerStages",
				-1,
				-1,
				-1,
				false,
				false,
				this
			);

			this.PerfSliderTunings = new Binary<PerfSliderTuning>
			(
				"PerfSliderTunings",
				-1,
				-1,
				-1,
				false,
				false,
				this
			);

			this.WorldChallenges = new Binary<WorldChallenge>
			(
				"WorldChallenges",
				-1,
				-1,
				-1,
				true,
				false,
				this
			);

			this.PartUnlockables = new Binary<PartUnlockable>
			(
				"PartUnlockables",
				-1,
				-1,
				-1,
				false,
				false,
				this
			);

			this.BankTriggers = new Binary<BankTrigger>
			(
				"BankTriggers",
				-1,
				-1,
				-1,
				true,
				true,
				this
			);

			this.GCarUnlocks = new Binary<GCarUnlock>
			(
				"GCarUnlocks",
				-1,
				-1,
				-1,
				true,
				false,
				this
			);

			this.FNGroups = new List<FNGroup>();
			this.TPKBlocks = new List<TPKBlock>();
			this.SlotTypes = new SlotType();
			this.STRBlocks = new STRBlock();
		}
	}
}