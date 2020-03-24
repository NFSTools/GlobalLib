using System.Collections.Generic;
using GlobalLib.Support.Carbon.Class;



namespace GlobalLib.Database
{
    public partial class Carbon : Reflection.Abstract.BasicBase, Reflection.Interface.IGetIndex, Reflection.Interface.IOperative
    {
        public Collection.Binary<Material> Materials { get; set; }
        public Collection.Binary<CarTypeInfo> CarTypeInfos { get; set; }
        public Collection.Binary<PresetRide> PresetRides { get; set; }
        public Collection.Binary<PresetSkin> PresetSkins { get; set; }
        public List<FNGroup> FNGroups { get; set; }
        public List<TPKBlock> TPKBlocks { get; set; }
        public SlotType SlotTypes { get; set; }
        public STRBlock STRBlocks { get; set; }

        public Carbon()
        {
            this.CarTypeInfos = new Collection.Binary<CarTypeInfo>();
            this.Materials = new Collection.Binary<Material>();
            this.PresetRides = new Collection.Binary<PresetRide>();
            this.PresetSkins = new Collection.Binary<PresetSkin>();
            this.FNGroups = new List<FNGroup>();
            this.TPKBlocks = new List<TPKBlock>();
            this.SlotTypes = new SlotType();
            this.STRBlocks = new STRBlock();
        }

        ~Carbon()
        {
            this._GlobalABUN = null;
            this._GlobalBLZC = null;
            this._LngGlobal = null;
            this._LngLabels = null;
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
