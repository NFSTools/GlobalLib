using System.Collections.Generic;
using GlobalLib.Support.Carbon.Class;



namespace GlobalLib.Database
{
    public partial class Carbon : Reflection.Interface.IGetIndex, Reflection.Interface.IOperative
    {
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
    }
}
