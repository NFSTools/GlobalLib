namespace GlobalLib.Support.MostWanted.Class
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
            this._collection_name = this.Index.ToString() + "_" + Utils.EA.Comp.GetTPKName(this.Index);

            // Get Filename
            this.filename = Utils.ScriptX.NullTerminatedString(byteptr_t + offset + 0x28, 0x40);

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