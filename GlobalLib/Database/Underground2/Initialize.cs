namespace GlobalLib.Database
{
	public partial class Underground2
	{
		private void Initialize()
		{
            this.CarTypeInfos = new Collection.Binary<CarTypeInfo>();
            this.FNGroups = new List<FNGroup>();
            this.Materials = new Collection.Binary<Material>();
            this.PresetRides = new Collection.Binary<PresetRide>();
            this.SunInfos = new Collection.Binary<SunInfo>();
            this.Tracks = new Collection.Binary<Track>();
            this.GCareerRaces = new Collection.Binary<GCareerRace>();
            this.WorldShops = new Collection.Binary<WorldShop>();
            this.GCareerBrands = new Collection.Binary<GCareerBrand>();
            this.PartPerformances = new Collection.Binary<PartPerformance>();
            this.GShowcases = new Collection.Binary<GShowcase>();
            this.SMSMessages = new Collection.Binary<SMSMessage>();
            this.Sponsors = new Collection.Binary<Sponsor>();
            this.GCareerStages = new Collection.Binary<GCareerStage>();
            this.PerfSliderTunings = new Collection.Binary<PerfSliderTuning>();
            this.WorldChallenges = new Collection.Binary<WorldChallenge>();
            this.PartUnlockables = new Collection.Binary<PartUnlockable>();
            this.BankTriggers = new Collection.Binary<BankTrigger>();
            this.GCarUnlocks = new Collection.Binary<GCarUnlock>();
            this.TPKBlocks = new List<TPKBlock>();
            this.SlotTypes = new SlotType();
            this.STRBlocks = new STRBlock();
        }
    }
}