using System.Collections.Generic;
using GlobalLib.Support.Underground2.Class;
using GlobalLib.Support.Underground2.Gameplay;


namespace GlobalLib.Database
{
    public partial class Underground2 : Reflection.Abstract.BasicBase, Reflection.Interface.IGetIndex//, Reflection.Interface.IOperative
    {
        public Collection.Root<Material> Materials { get; set; }
        public Collection.Root<CarTypeInfo> CarTypeInfos { get; set; }
        public Collection.Root<PresetRide> PresetRides { get; set; }
        public Collection.Root<SunInfo> SunInfos { get; set; }
        public Collection.Root<Track> Tracks { get; set; }
        public Collection.Root<GCareerRace> GCareerRaces { get; set; }
        public Collection.Root<WorldShop> WorldShops { get; set; }
        public Collection.Root<GCareerBrand> GCareerBrands { get; set; }
        public Collection.Root<PartPerformance> PartPerformances { get; set; }
        public Collection.Root<GShowcase> GShowcases { get; set; }
        public Collection.Root<SMSMessage> SMSMessages { get; set; }
        public Collection.Root<Sponsor> Sponsors { get; set; }
        public Collection.Root<GCareerStage> GCareerStages { get; set; }
        public Collection.Root<PerfSliderTuning> PerfSliderTunings { get; set; }
        public Collection.Root<WorldChallenge> WorldChallenges { get; set; }
        public Collection.Root<PartUnlockable> PartUnlockables { get; set; }
        public Collection.Root<BankTrigger> BankTriggers { get; set; }
        public Collection.Root<GCarUnlock> GCarUnlocks { get; set; }
        public List<FNGroup> FNGroups { get; set; }
        public List<TPKBlock> TPKBlocks { get; set; }
        public SlotType SlotTypes { get; set; }
        public STRBlock STRBlocks { get; set; }

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
            System.GC.Collect();
        }
    }
}