using System.Collections.Generic;
using GlobalLib.Database.Collection;
using GlobalLib.Reflection.Abstract;
using GlobalLib.Reflection.Interface;
using GlobalLib.Support.Carbon.Class;



namespace GlobalLib.Database
{
    public partial class Carbon : BasicBase, IGetIndex
    {
        public Root<Material> Materials { get; set; }
        public Root<CarTypeInfo> CarTypeInfos { get; set; }
        public Root<PresetRide> PresetRides { get; set; }
        public Root<PresetSkin> PresetSkins { get; set; }
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
        }
    }
}
