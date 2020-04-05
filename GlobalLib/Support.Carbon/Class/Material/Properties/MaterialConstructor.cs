using GlobalLib.Core;
using GlobalLib.Utils;
using System;

namespace GlobalLib.Support.Carbon.Class
{
    public partial class Material : Shared.Class.Material
    {
        // Default constructor
        public Material() { }

        // Default constructor: create new material
        public Material(string CName, Database.Carbon db)
        {
            this.Database = db;
            this.CollectionName = CName;
            Map.BinKeys[Bin.Hash(CName)] = CName;
        }

        // Default constructor: disassemble material
        public unsafe Material(IntPtr byteptr_t, string CName, Database.Carbon db)
        {
            this.Database = db;
            this.CollectionName = CName;
            this.Disassemble((byte*)byteptr_t);
        }

        ~Material() { }
    }
}