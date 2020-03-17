using System.Collections.Generic;
using GlobalLib.Support.MostWanted.Class;



namespace GlobalLib.Database
{
    public partial class MostWanted : Reflection.Interface.IGetIndex, Reflection.Interface.IOperative
    {
        public byte[] _GlobalABUN;
        public byte[] _GlobalBLZC;
        public byte[] _LngGlobal;
        public byte[] _LngLabels;
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
            this.Materials = new Collection.ClassCollection<Material>();
            this.PresetRides = new Collection.ClassCollection<PresetRide>();
            this.FNGroups = new List<FNGroup>();
            this.TPKBlocks = new List<TPKBlock>();
            this.SlotTypes = new SlotType();
            this.STRBlocks = new STRBlock();
        }

        ~MostWanted()
        {
            this._GlobalABUN = null;
            this._GlobalBLZC = null;
            this._LngGlobal = null;
            this._LngLabels = null;
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