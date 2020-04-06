using GlobalLib.Core;
using GlobalLib.Utils;
using System;

namespace GlobalLib.Support.Underground2.Class
{
	public partial class PresetRide : Shared.Class.PresetRide
	{
        // Default constructor
        public PresetRide() { }

        // Default constructor: create new preset
        public PresetRide(string CName, Database.Underground2 db)
        {
            this.Database = db;
            this.CollectionName = CName;
            this.Initialize();
            this.data = new byte[0x338];
            this.MODEL = "SUPRA";
            Map.BinKeys[Bin.Hash(CName)] = CName;
            this.Modified = true;
        }

        // Default constructor: disassemble preset
        public unsafe PresetRide(IntPtr byteptr_t, string CName, Database.Underground2 db)
        {
            this.Database = db;
            this._collection_name = CName;
            this.Initialize();
            this.data = new byte[0x338];
            this.Exists = true;
            this.Disassemble((byte*)byteptr_t);
            this.Modified = false;
        }

        // Default destructor
        ~PresetRide() { }
    }
}