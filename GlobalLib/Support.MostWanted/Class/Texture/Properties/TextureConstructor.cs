﻿namespace GlobalLib.Support.MostWanted.Class
{
    public partial class Texture : Shared.Class.Texture, Reflection.Interface.ICastable<Texture>
    {
        public Texture() { }

        // Default constructor: create new texture for memory cast
        public Texture(string CName)
        {
            this.CollectionName = CName;
            this.BinKey = Utils.Bin.Hash(CName);
            this.PaletteOffset = 0;
            this._padding = 1;
        }

        // Default constructor: create new texture from file.
        public Texture(string CName, string filename)
        {
            this._collection_name = CName;
            this.BinKey = Utils.Bin.Hash(CName);
            this.PaletteOffset = 0;
            this._padding = 1;
            this.Initialize(filename);
        }

        // Default constructor: disassemble texture
        public unsafe Texture(byte* byteptr_t, int offset, int size, string _TPK)
        {
            this._located_at = offset;
            this._size_of_block = size;
            this._parent_TPK = _TPK;
            this.PaletteOffset = 0;
            this._padding = 1;
            this.Disassemble(byteptr_t);
        }

        // Default constructor: disassemble texture
        public unsafe Texture(byte* byteptr_t, uint offset, uint size, string _TPK)
        {
            this._located_at = (int)offset;
            this._size_of_block = (int)size;
            this._parent_TPK = _TPK;
            this.PaletteOffset = 0;
            this._padding = 1;
            this.Disassemble(byteptr_t);
        }

        ~Texture() { }
    }
}