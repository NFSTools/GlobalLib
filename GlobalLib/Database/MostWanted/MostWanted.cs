using System.Collections.Generic;
using GlobalLib.Support.MostWanted.Class;



namespace GlobalLib.Database
{
    public partial class MostWanted : Reflection.Interface.IGetIndex, Reflection.Interface.IOperative
    {
        public byte[] GlobalABUN;
        public byte[] GlobalBLZC;
        public byte[] LngGlobal;
        public byte[] LngLabels;
        public Collection.ClassCollection<Material> Materials { get; set; }
        public Collection.ClassCollection<CarTypeInfo> CarTypeInfos { get; set; }
        public Collection.ClassCollection<PresetRide> PresetRides { get; set; }
        public List<FNGroup> FNGroups { get; set; }
        public List<TPKBlock> TPKBlocks { get; set; }
        public SlotType SlotTypes { get; set; }
        public STRBlock STRBlocks { get; set; }

        public MostWanted()
        {
            this.CarTypeInfos = new Collection.ClassCollection<CarTypeInfo>();
            this.FNGroups = new List<FNGroup>();
            this.Materials = new Collection.ClassCollection<Material>();
            this.PresetRides = new Collection.ClassCollection<PresetRide>();
            this.TPKBlocks = new List<TPKBlock>();
            this.SlotTypes = new SlotType();
            this.STRBlocks = new STRBlock();
        }

        ~MostWanted()
        {
            this.GlobalABUN = null;
            this.GlobalBLZC = null;
            this.LngGlobal = null;
            this.LngLabels = null;
            this.CarTypeInfos = null;
            this.FNGroups = null;
            this.Materials = null;
            this.PresetRides = null;
            this.TPKBlocks = null;
            this.SlotTypes = null;
            this.STRBlocks = null;
            System.GC.Collect();
        }
    }
}