using System.Collections.Generic;
using GlobalLib.Support.Underground2.Class;
using GlobalLib.Support.Underground2.Gameplay;


namespace GlobalLib.Database
{
    public partial class Underground2 : Reflection.Interface.IGetIndex//, Reflection.Interface.IOperative
    {
        public byte[] GlobalABUN;
        public byte[] GlobalBLZC;
        public byte[] LngGlobal;
        public byte[] LngLabels;
        public Collection.ClassCollection<Material> Materials { get; set; }
        public Collection.ClassCollection<CarTypeInfo> CarTypeInfos { get; set; }
        //public Collection.ClassCollection<PresetRide> PresetRides { get; set; }
        public Collection.ClassCollection<SunInfo> SunInfos { get; set; }
        public Collection.ClassCollection<Track> Tracks { get; set; }
        public Collection.ClassCollection<GCareerRace> GCareerRaces { get; set; }
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
            this.TPKBlocks = new List<TPKBlock>();
            this.SlotTypes = new SlotType();
            this.STRBlocks = new STRBlock();
            this.GCareerInfos = new GCareerInfo();
        }

        ~Underground2()
        {
            this.GlobalABUN = null;
            this.GlobalBLZC = null;
            this.LngGlobal = null;
            this.LngLabels = null;
            this.CarTypeInfos = null;
            this.FNGroups = null;
            this.Materials = null;
            //this.PresetRides = null;
            this.SunInfos = null;
            this.Tracks = null;
            this.GCareerRaces = null;
            this.TPKBlocks = null;
            this.SlotTypes = null;
            this.STRBlocks = null;
            this.GCareerInfos = null;
            System.GC.Collect();
        }
    }
}