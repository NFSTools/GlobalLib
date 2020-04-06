using GlobalLib.Utils;

namespace GlobalLib.Support.Carbon.Class
{
    public partial class Texture : Shared.Class.Texture
    {
        public Texture() { }

        // Default constructor: create new texture for memory cast
        public Texture(string CName, string _TPK, Database.Carbon db)
        {
            this.Database = db;
            this._collection_name = CName;
            this._parent_TPK = _TPK;
            this.BinKey = Bin.Hash(CName);
            this.PaletteOffset = -1;
            this._padding = 0;
        }

        // Default constructor: create new texture from file.
        public Texture(string CName, string _TPK, string filename, Database.Carbon db)
        {
            this.Database = db;
            this._collection_name = CName;
            this._parent_TPK = _TPK;
            this.BinKey = Bin.Hash(CName);
            this.PaletteOffset = -1;
            this._padding = 0;
            this.Initialize(filename);
        }

        // Default constructor: disassemble texture
        public unsafe Texture(byte* byteptr_t, int offset, int size, string _TPK, Database.Carbon db)
        {
            this.Database = db;
            this._located_at = offset;
            this._size_of_block = size;
            this._parent_TPK = _TPK;
            this.PaletteOffset = -1;
            this._padding = 0;
            this.Disassemble(byteptr_t + this._located_at);
        }

        // Default constructor: disassemble texture
        public unsafe Texture(byte* byteptr_t, uint offset, uint size, string _TPK, Database.Carbon db)
        {
            this.Database = db;
            this._located_at = (int)offset;
            this._size_of_block = (int)size;
            this._parent_TPK = _TPK;
            this.PaletteOffset = -1;
            this._padding = 0;
            this.Disassemble(byteptr_t + this._located_at);
        }

        ~Texture() { }
    }
}