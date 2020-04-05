﻿using GlobalLib.Core;
using GlobalLib.Utils;
using System;

namespace GlobalLib.Support.MostWanted.Class
{
    public partial class PresetRide : Shared.Class.PresetRide
    {
        // Default constructor
        public PresetRide() { }

        // Default constructor: create new preset
        public PresetRide(string CName, Database.MostWanted db)
        {
            this.Database = db;
            this.CollectionName = CName;
            this.data = new byte[0x290];
            this.MODEL = "SUPRA";
            this.Frontend = "supra";
            this.Pvehicle = "supra";
            Map.BinKeys[Bin.Hash(CName)] = CName;
            this.Modified = true;
        }

        // Default constructor: disassemble preset
        public unsafe PresetRide(IntPtr byteptr_t, string CName, Database.MostWanted db)
        {
            this.Database = db;
            this.data = new byte[0x290];
            this._collection_name = CName;
            this.Exists = true;
            this.Disassemble((byte*)byteptr_t);
            this.Modified = false;
        }

        // Default destructor
        ~PresetRide() { }
    }
}