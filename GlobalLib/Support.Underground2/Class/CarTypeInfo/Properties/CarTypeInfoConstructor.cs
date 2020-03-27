namespace GlobalLib.Support.Underground2.Class
{
    public partial class CarTypeInfo : Shared.Class.CarTypeInfo
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
            this.WhatGame = 2;
            this.WheelOuterRadius = 26;
            this.WheelOuterRadiusMin = 17;
            this.WheelInnerRadiusMax = 20;
            this.DefaultSkinNumber = 1;
            Core.Map.BinKeys[this.BinKey] = CName;
            this.Initialize();
        }

        // Default constructor: disassemble cartypeinfo
        public unsafe CarTypeInfo(System.IntPtr byteptr_t, string CName, Database.Underground2 db)
        {
            this.Database = db;
            this._collection_name = CName;
            this.OriginalName = CName;
            this.Initialize();
            this.Disassemble((byte*)byteptr_t);
            if (this.Index <= (int)Reflection.Enum.eBoundValues.MIN_INFO_UNDERGROUND2)
                this.Deletable = false;
            this.Modified = false;
        }

        ~CarTypeInfo() { }
    }
}