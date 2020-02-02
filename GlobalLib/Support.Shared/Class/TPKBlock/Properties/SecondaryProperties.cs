namespace GlobalLib.Support.Shared.Class
{
    public partial class TPKBlock
    {
        protected int Version                 { get; set; } = 8; // usually 0x8
        protected string filename             { get; set; }      // 0x40 bytes max
        protected uint FilenameHash           { get; set; }      // Utils.Bin.Hash(this.filename)
        protected uint PermBlockByteOffset    { get; set; } = 0; // usually 0
        protected uint PermBlockByteSize      { get; set; } = 0; // usually 0
        protected int EndianSwapped           { get; set; } = 0; // usually 0
        protected int TexturePack             { get; set; } = 0; // usually 0
        protected int TextureIndexEntryTable  { get; set; } = 0; // usually 0
        protected int TextureStreamEntryTable { get; set; } = 0; // usually 0
    }
}