using System.Collections.Generic;



namespace GlobalLib.Support.Carbon.Class
{
    public partial class TPKBlock : Shared.Class.TPKBlock
    {
        public List<Texture> Textures { get; set; } = new List<Texture>(); // Part4
        private List<uint> keys = new List<uint>(); // Part2
        private List<uint> compressions = new List<uint>(); // Part5

        public TPKBlock() { }

        public unsafe TPKBlock(byte* byteptr_t, int index)
        {
            this.Index = index;
            this.Disassemble(byteptr_t);
        }
    }
}