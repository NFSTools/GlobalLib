using GlobalLib.Core;
using GlobalLib.Database.Collection;
using GlobalLib.Reflection.Abstract;
using GlobalLib.Support.Underground2.Class;
using GlobalLib.Support.Underground2.Gameplay;


namespace GlobalLib.Database
{
    public partial class Underground2 : BasicBase
    {
        /// <summary>
        /// Game to which the class belongs to.
        /// </summary>
        public override GameINT GameINT { get => GameINT.Underground2; }

        /// <summary>
        /// Game string to which the class belongs to.
        /// </summary>
        public override string GameSTR { get => GameINT.Underground2.ToString(); }

        public Root<Material> Materials { get; set; }
        public Root<CarTypeInfo> CarTypeInfos { get; set; }
        public Root<PresetRide> PresetRides { get; set; }
        public Root<SunInfo> SunInfos { get; set; }
        public Root<Track> Tracks { get; set; }
        public Root<GCareerRace> GCareerRaces { get; set; }
        public Root<WorldShop> WorldShops { get; set; }
        public Root<GCareerBrand> GCareerBrands { get; set; }
        public Root<PartPerformance> PartPerformances { get; set; }
        public Root<GShowcase> GShowcases { get; set; }
        public Root<SMSMessage> SMSMessages { get; set; }
        public Root<Sponsor> Sponsors { get; set; }
        public Root<GCareerStage> GCareerStages { get; set; }
        public Root<PerfSliderTuning> PerfSliderTunings { get; set; }
        public Root<WorldChallenge> WorldChallenges { get; set; }
        public Root<PartUnlockable> PartUnlockables { get; set; }
        public Root<BankTrigger> BankTriggers { get; set; }
        public Root<GCarUnlock> GCarUnlocks { get; set; }
        public Root<FNGroup> FNGroups { get; set; }
        public Root<TPKBlock> TPKBlocks { get; set; }
        public Root<STRBlock> STRBlocks { get; set; }
        public SlotType SlotTypes { get; set; }

        public Underground2()
        {
            this.Initialize();
        }

        ~Underground2()
        {
            this._GlobalABUN = null;
            this._GlobalBLZC = null;
            this._LngGlobal = null;
            this._LngLabels = null;
            this.CarTypeInfos = null;
            this.FNGroups = null;
            this.Materials = null;
            this.PresetRides = null;
            this.SunInfos = null;
            this.Tracks = null;
            this.TPKBlocks = null;
            this.SlotTypes = null;
            this.STRBlocks = null;
            this.GCareerRaces = null;
            this.WorldShops = null;
            this.GCareerBrands = null;
            this.PartPerformances = null;
            this.GShowcases = null;
            this.SMSMessages = null;
            this.Sponsors = null;
            this.GCareerStages = null;
            this.PerfSliderTunings = null;
            this.WorldChallenges = null;
            this.PartUnlockables = null;
            this.BankTriggers = null;
            this.GCarUnlocks = null;
        }
    }
}