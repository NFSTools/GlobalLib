using GlobalLib.Core;
using GlobalLib.Utils;
using System;

namespace GlobalLib.Support.Underground2.Class
{
    public partial class XenonEffect : Shared.Class.XenonEffect
    {
        // Default constructor
        public XenonEffect() { }

        // Default constructor: create new material
        public XenonEffect(string CName, Database.Underground2 db)
        {
            this.Database = db;
            this.CollectionName = CName;
            Map.BinKeys[Bin.Hash(CName)] = CName;
        }

        // Default constructor: disassemble material
        public unsafe XenonEffect(IntPtr byteptr_t, string CName, Database.Underground2 db)
        {
            this.Database = db;
            this._collection_name = CName;
            this.Disassemble((byte*)byteptr_t);
        }

        ~XenonEffect() { }
    }
}