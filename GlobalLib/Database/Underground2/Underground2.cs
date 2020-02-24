﻿using System.Collections.Generic;
using GlobalLib.Support.Underground2.Class;



namespace GlobalLib.Database
{
    public partial class Underground2 : Reflection.Interface.IGetIndex//, Reflection.Interface.IOperative
    {
        //public List<Material> Materials { get; set; }
        public List<CarTypeInfo> CarTypeInfos { get; set; }
        //public List<PresetRide> PresetRides { get; set; }
        public List<FNGroup> FNGroups { get; set; }
        public List<TPKBlock> TPKBlocks { get; set; }
        public SlotType SlotTypes { get; set; }
        public STRBlock STRBlocks { get; set; }

        public Underground2()
        {
            this.CarTypeInfos = new List<CarTypeInfo>();
            this.FNGroups = new List<FNGroup>();
            //this.Materials = new List<Material>();
            //this.PresetRides = new List<PresetRide>();
            this.TPKBlocks = new List<TPKBlock>();
            this.SlotTypes = new SlotType();
            this.STRBlocks = new STRBlock();
        }
    }
}