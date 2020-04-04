using GlobalLib.Core;
using GlobalLib.Database.Collection;
using GlobalLib.Reflection.Abstract;
using GlobalLib.Reflection.Interface;
using GlobalLib.Support.Carbon.Class;



namespace GlobalLib.Database
{
    public partial class Carbon : BasicBase
    {
        /// <summary>
        /// Game to which the class belongs to.
        /// </summary>
        public override GameINT GameINT { get => GameINT.Carbon; }

        /// <summary>
        /// Game string to which the class belongs to.
        /// </summary>
        public override string GameSTR { get => GameINT.Carbon.ToString(); }

        public Root<Material> Materials { get; set; }
        public Root<CarTypeInfo> CarTypeInfos { get; set; }
        public Root<PresetRide> PresetRides { get; set; }
        public Root<PresetSkin> PresetSkins { get; set; }
        public Root<FNGroup> FNGroups { get; set; }
        public Root<TPKBlock> TPKBlocks { get; set; }
        public Root<STRBlock> STRBlocks { get; set; }
        public SlotType SlotTypes { get; set; }

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
