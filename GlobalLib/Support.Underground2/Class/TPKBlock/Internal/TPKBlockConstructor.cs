﻿using System.Collections.Generic;
using GlobalLib.Support.Shared.Parts.TPKParts;



namespace GlobalLib.Support.Underground2.Class
{
    public partial class TPKBlock : Shared.Class.TPKBlock
    {
        public List<Texture> Textures { get; set; } = new List<Texture>(); // Part4
        private List<uint> keys = new List<uint>(); // Part2
        private List<CompSlot> compressions = new List<CompSlot>(); // Part5

        public TPKBlock() { }

        public unsafe TPKBlock(byte* byteptr_t, int index, Database.MostWanted db)
        {
            this.Database = db;
            this.Index = index;
            this.Disassemble(byteptr_t);
        }
    }
}