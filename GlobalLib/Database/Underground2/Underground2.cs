using System.Collections.Generic;
using GlobalLib.Support.Underground2.Class;
using GlobalLib.Support.Underground2.Gameplay;


namespace GlobalLib.Database
{
    public partial class Underground2 : Reflection.Interface.IGetIndex//, Reflection.Interface.IOperative
    {
        public byte[] _GlobalABUN;
        public byte[] _GlobalBLZC;
        public byte[] _LngGlobal;
        public byte[] _LngLabels;
        public Collection.ClassCollection<Material> Materials { get; set; }
        public Collection.ClassCollection<CarTypeInfo> CarTypeInfos { get; set; }
        //public Collection.ClassCollection<PresetRide> PresetRides { get; set; }
        public Collection.ClassCollection<SunInfo> SunInfos { get; set; }
        public Collection.ClassCollection<Track> Tracks { get; set; }
        public Collection.ClassCollection<GCareerRace> GCareerRaces { get; set; }
        public Collection.ClassCollection<WorldShop> WorldShops { get; set; }
        public Collection.ClassCollection<GCareerBrand> GCareerBrands { get; set; }
        public Collection.ClassCollection<PartPerformance> PartPerformances { get; set; }
        public Collection.ClassCollection<WorldChallenge> WorldChallenges { get; set; }
        public Collection.ClassCollection<PartUnlockable> PartUnlockables { get; set; }
        public Collection.ClassCollection<BankTrigger> BankTriggers { get; set; }
        public List<FNGroup> FNGroups { get; set; }
        public List<TPKBlock> TPKBlocks { get; set; }
        public SlotType SlotTypes { get; set; }
        public STRBlock STRBlocks { get; set; }
        public GCareerInfo GCareerInfos { get; set; }

        public Underground2()
        {
            this.CarTypeInfos = new Collection.ClassCollection<CarTypeInfo>();
            this.FNGroups = new List<FNGroup>();
            this.Materials = new Collection.ClassCollection<Material>();
            //this.PresetRides = new Collection.ClassCollection<PresetRide>();
            this.SunInfos = new Collection.ClassCollection<SunInfo>();
            this.Tracks = new Collection.ClassCollection<Track>();
            this.GCareerRaces = new Collection.ClassCollection<GCareerRace>();
            this.WorldShops = new Collection.ClassCollection<WorldShop>();
            this.GCareerBrands = new Collection.ClassCollection<GCareerBrand>();
            this.PartPerformances = new Collection.ClassCollection<PartPerformance>();
            this.WorldChallenges = new Collection.ClassCollection<WorldChallenge>();
            this.PartUnlockables = new Collection.ClassCollection<PartUnlockable>();
            this.BankTriggers = new Collection.ClassCollection<BankTrigger>();
            this.TPKBlocks = new List<TPKBlock>();
            this.SlotTypes = new SlotType();
            this.STRBlocks = new STRBlock();
            this.GCareerInfos = new GCareerInfo();
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
            //this.PresetRides = null;
            this.SunInfos = null;
            this.Tracks = null;
            this.TPKBlocks = null;
            this.SlotTypes = null;
            this.STRBlocks = null;
            this.GCareerInfos = null;
            this.GCareerRaces = null;
            this.WorldShops = null;
            this.GCareerBrands = null;
            this.PartPerformances = null;
            this.WorldChallenges = null;
            this.PartUnlockables = null;
            this.BankTriggers = null;
            System.GC.Collect();
        }
    }
}