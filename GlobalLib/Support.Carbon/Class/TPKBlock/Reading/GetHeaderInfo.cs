namespace GlobalLib.Support.Carbon.Class
{
    public partial class TPKBlock : Shared.Class.TPKBlock
    {
        /// <summary>
        /// Gets tpk header information.
        /// </summary>
        /// <param name="byteptr_t">Pointer to the tpk block array.</param>
        /// <param name="offset">Partial 1 part1 offset in the tpk block array.</param>
        protected override unsafe void GetHeaderInfo(byte* byteptr_t, int offset)
        {
            if (*(uint*)(byteptr_t + offset) != Reflection.ID.TPK.INFO_PART1_BLOCKID)
                return; // check Part1 ID
            if (*(uint*)(byteptr_t + offset + 4) != 0x7C)
                return; // check header size

            // Get CollectionName
            this._collection_name = this.Index.ToString() + "_";
            for (int a1 = offset + 0xC; *(byteptr_t + a1) != 0; ++a1)
                this._collection_name += ((char)*(byteptr_t + a1)).ToString();

            // Get Filename
            for (int a1 = offset + 0x28; *(byteptr_t + a1) != 0; ++a1)
                this.filename += ((char)*(byteptr_t + a1)).ToString();

            // Get the rest of the settings
            this.Version = *(int*)(byteptr_t + offset + 8);
            this.FilenameHash = *(uint*)(byteptr_t + offset + 0x68);
            this.PermBlockByteOffset = *(uint*)(byteptr_t + offset + 0x6C);
            this.PermBlockByteSize = *(uint*)(byteptr_t + offset + 0x70);
            this.EndianSwapped = *(int*)(byteptr_t + offset + 0x74);
            this.TexturePack = *(int*)(byteptr_t + offset + 0x78);
            this.TextureIndexEntryTable = *(int*)(byteptr_t + offset + 0x7C);
            this.TextureStreamEntryTable = *(int*)(byteptr_t + offset + 0x80);
        }
    }
}