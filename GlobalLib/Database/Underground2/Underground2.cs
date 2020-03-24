using System.Collections.Generic;
using GlobalLib.Support.Underground2.Class;
using GlobalLib.Support.Underground2.Gameplay;


namespace GlobalLib.Database
{
    public partial class Underground2 : Reflection.Abstract.BasicBase, Reflection.Interface.IGetIndex//, Reflection.Interface.IOperative
    {
        public Collection.Binary<Material> Materials { get; set; }
        public Collection.Binary<CarTypeInfo> CarTypeInfos { get; set; }
        public Collection.Binary<PresetRide> PresetRides { get; set; }
        public Collection.Binary<SunInfo> SunInfos { get; set; }
        public Collection.Binary<Track> Tracks { get; set; }
        public Collection.Binary<GCareerRace> GCareerRaces { get; set; }
        public Collection.Binary<WorldShop> WorldShops { get; set; }
        public Collection.Binary<GCareerBrand> GCareerBrands { get; set; }
        public Collection.Binary<PartPerformance> PartPerformances { get; set; }
        public Collection.Binary<GShowcase> GShowcases { get; set; }
        public Collection.Binary<SMSMessage> SMSMessages { get; set; }
        public Collection.Binary<Sponsor> Sponsors { get; set; }
        public Collection.Binary<GCareerStage> GCareerStages { get; set; }
        public Collection.Binary<PerfSliderTuning> PerfSliderTunings { get; set; }
        public Collection.Binary<WorldChallenge> WorldChallenges { get; set; }
        public Collection.Binary<PartUnlockable> PartUnlockables { get; set; }
        public Collection.Binary<BankTrigger> BankTriggers { get; set; }
        public Collection.Binary<GCarUnlock> GCarUnlocks { get; set; }
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