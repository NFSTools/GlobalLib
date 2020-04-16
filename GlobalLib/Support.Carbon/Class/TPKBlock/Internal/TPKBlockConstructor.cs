using System.Collections.Generic;
using GlobalLib.Support.Shared.Parts.TPKParts;


namespace GlobalLib.Support.Carbon.Class
{
    public partial class TPKBlock : Shared.Class.TPKBlock
    {
        private bool _use_current_cname = false;
        private List<uint> keys = new List<uint>(); // Part2
        private List<OffSlot> offslots = new List<OffSlot>(); // Part3
        public List<Texture> Textures { get; set; } = new List<Texture>(); // Part4
        private List<uint> compressions = new List<uint>(); // Part5

        public TPKBlock() { this._use_current_cname = true; }

        public unsafe TPKBlock(byte* byteptr_t, int index, Database.Carbon db)
        {
            if (index < 0) this._use_current_cname = true;
            this.Database = db;
            this.Index = index;
            this.Disassemble(byteptr_t);
        }
    }
}