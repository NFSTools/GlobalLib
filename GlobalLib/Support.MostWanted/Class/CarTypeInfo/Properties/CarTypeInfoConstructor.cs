﻿namespace GlobalLib.Support.MostWanted.Class
{
    public partial class CarTypeInfo : Shared.Class.CarTypeInfo, Reflection.Interface.ICastable<CarTypeInfo>
    {
        // Default constructor
        public CarTypeInfo() { }

        // Default constructor: create new cartypeinfo
        public CarTypeInfo(string CName, Database.MostWanted db)
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
            this.CollisionExternalName = CollectionName;
            this.CollisionInternalName = "CARRERAGT";
            Core.Map.BinKeys[Utils.Bin.Hash(CName)] = CName;
        }

        // Default constructor: disassemble cartypeinfo
        public unsafe CarTypeInfo(byte* byteptr_t, string CName, Database.MostWanted db)
        {
            this.Database = db;
            this.CollectionName = CName;
            this.OriginalName = CName;
            this.Disassemble(byteptr_t);
            if (this.Index <= (int)Reflection.Enum.eBoundValues.MIN_INFO_MOSTWANTED)
                this.Deletable = false;
            this.Modified = false;
        }

        ~CarTypeInfo() { }
    }
}