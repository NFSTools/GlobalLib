using GlobalLib.Core;
using GlobalLib.Utils;
using System;

namespace GlobalLib.Support.Carbon.Class
{
    public partial class PresetSkin : Shared.Class.PresetSkin
    {
        // Default constructor
        public PresetSkin() { }

        // Default constructor: create new skin
        public PresetSkin(string CName, Database.Carbon db)
        {
            this.Database = db;
            this.CollectionName = CName;
            Map.BinKeys[Bin.Hash(CName)] = CName;
        }

        // Default constructor: disassemble skin
        public unsafe PresetSkin(IntPtr byteptr_t, string CName, Database.Carbon db)
        {
            this.Database = db;
            this._collection_name = CName;
            this.Disassemble((byte*)byteptr_t);
        }

        // Default destructor
        ~PresetSkin() { }
    }
}