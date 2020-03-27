using System.Collections.Generic;
using GlobalLib.Support.Carbon.Class;



namespace GlobalLib.Database
{
    public partial class Carbon : Reflection.Abstract.BasicBase, Reflection.Interface.IGetIndex
    {
        public Collection.Root<Material> Materials { get; set; }
        public Collection.Root<CarTypeInfo> CarTypeInfos { get; set; }
        public Collection.Root<PresetRide> PresetRides { get; set; }
        public Collection.Root<PresetSkin> PresetSkins { get; set; }
        public List<FNGroup> FNGroups { get; set; }
        public List<TPKBlock> TPKBlocks { get; set; }
        public SlotType SlotTypes { get; set; }
        public STRBlock STRBlocks { get; set; }

        public Carbon()
        {
            this.Initialize();
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
