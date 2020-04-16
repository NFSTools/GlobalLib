using System.Collections.Generic;
using GlobalLib.Support.Shared.Parts.TPKParts;



namespace GlobalLib.Support.Underground2.Class
{
    public partial class TPKBlock : Shared.Class.TPKBlock
    {
        private bool _use_current_cname = false;
        public List<Texture> Textures { get; set; } = new List<Texture>(); // Part4
        private List<uint> keys = new List<uint>(); // Part2
        private List<CompSlot> compressions = new List<CompSlot>(); // Part5

        public TPKBlock() { this._use_current_cname = true; }

        public unsafe TPKBlock(byte* byteptr_t, int index, Database.Underground2 db)
        {
            if (index < 0) this._use_current_cname = true;
            this.Database = db;
            this.Index = index;
            this.Disassemble(byteptr_t);
        }
    }
}