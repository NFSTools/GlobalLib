namespace GlobalLib.Support.Underground2.Class
{
    public partial class CarTypeInfo : Shared.Class.CarTypeInfo, Reflection.Interface.ICastable<CarTypeInfo>
    {
        // Default constructor
        public CarTypeInfo() { }

        // Default constructor: create new cartypeinfo
        public CarTypeInfo(string CName, Database.Underground2 db)
        {
            this.Database = db;
            this.CollectionName = CName;
            this.ManufacturerName = "GENERIC";
            this.Deletable = true;
            this.Modified = true;
            this.WhatGame = 1;
            this.WheelOuterRadius = 26;
            this.WheelOuterRadiusMin = 17;
            this.WheelInnerRadiusMax = 20;
            this.DefaultSkinNumber = 1;
            //this.CollisionExternalName = CollectionName;
            this.CollisionInternalName = "CARRERAGT";
            uint a1 = Utils.Bin.Hash(CName);
            Core.Map.BinKeys[this.BinKey] = CName;
        }

        // Default constructor: disassemble cartypeinfo
        public unsafe CarTypeInfo(byte* byteptr_t, string CName, Database.Underground2 db)
        {
            this.Database = db;
            this.CollectionName = CName;
            this.OriginalName = CName;
            //this.Disassemble(byteptr_t);
            //if (this.Index <= Reflection.Enum.CarTypeInfo.BoundValues.MinInfoMostWanted)
            //    this.Deletable = false;
            this.Modified = false;
        }

        ~CarTypeInfo() { }
    }
}