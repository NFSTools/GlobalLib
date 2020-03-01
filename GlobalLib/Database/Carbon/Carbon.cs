using System.Collections.Generic;
using GlobalLib.Support.Carbon.Class;



namespace GlobalLib.Database
{
    public partial class Carbon : Reflection.Interface.IGetIndex, Reflection.Interface.IOperative
    {
        public byte[] GlobalABUN;
        public byte[] GlobalBLZC;
        public byte[] LngGlobal;
        public byte[] LngLabels;
        public List<Material> Materials { get; set; }
        public List<CarTypeInfo> CarTypeInfos { get; set; }
        public List<PresetRide> PresetRides { get; set; }
        public List<PresetSkin> PresetSkins { get; set; }
        public List<FNGroup> FNGroups { get; set; }
        public List<TPKBlock> TPKBlocks { get; set; }
        public SlotType SlotTypes { get; set; }
        public STRBlock STRBlocks { get; set; }

        public Carbon()
        {
            this.CarTypeInfos = new List<CarTypeInfo>();
            this.FNGroups = new List<FNGroup>();
            this.Materials = new List<Material>();
            this.PresetRides = new List<PresetRide>();
            this.PresetSkins = new List<PresetSkin>();
            this.TPKBlocks = new List<TPKBlock>();
            this.SlotTypes = new SlotType();
            this.STRBlocks = new STRBlock();
        }

        ~Carbon()
        {
            this.GlobalABUN = null;
            this.GlobalBLZC = null;
            this.LngGlobal = null;
            this.LngLabels = null;
            this.CarTypeInfos = null;
            this.FNGroups = null;
            this.Materials = null;
            this.PresetRides = null;
            this.PresetSkins = null;
            this.TPKBlocks = null;
            this.SlotTypes = null;
            this.STRBlocks = null;
            System.GC.Collect();
        }
    }
}
