namespace GlobalLib.Support.Shared.Class
{
    public class TPKBlock
    {
        #region Private Fields

        protected string _collection_name;
        protected int Version { get; set; } = 8; // 8 for C, 5 for MW and UG2
        protected string filename { get; set; } // 0x40 bytes max
        protected uint FilenameHash { get; set; } // Utils.Bin.Hash(this.filename)
        protected uint PermBlockByteOffset { get; set; } = 0; // usually 0
        protected uint PermBlockByteSize { get; set; } = 0; // usually 0
        protected int EndianSwapped { get; set; } = 0; // usually 0
        protected int TexturePack { get; set; } = 0; // usually 0
        protected int TextureIndexEntryTable { get; set; } = 0; // usually 0
        protected int TextureStreamEntryTable { get; set; } = 0; // usually 0

        #endregion

        #region Main Properties

        /// <summary>
        /// Collection name of the variable.
        /// </summary>
        public string CollectionName { get => this._collection_name; }

        /// <summary>
        /// Binary memory hash of the collection name.
        /// </summary>
        public uint BinKey { get => Utils.Bin.Hash(this._collection_name); }

        /// <summary>
        /// Vault memory hash of the collection name.
        /// </summary>
        public uint VltKey { get => Utils.Vlt.Hash(this._collection_name); }

        /// <summary>
        /// Index of the TPK in the Global data.
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// True if this tpk is in GlobalA file.
        /// </summary>
        public bool InGlobalA { get; set; }

        #endregion

        #region Internal Methods

        /// <summary>
        /// Assembles <see cref="TPKBlock"/> into a byte array.
        /// </summary>
        /// <returns>Byte array of the tpk block.</returns>
        public virtual unsafe byte[] Assemble() { return null; }

        /// <summary>
        /// Disassembles <see cref="TPKBlock"/> array into separate properties.
        /// </summary>
        /// <param name="byteptr_t">Pointer to the tpk block array.</param>
        protected virtual unsafe void Disassemble(byte* byteptr_t) { }

        /// <summary>
        /// Tries to find <see cref="Texture"/> based on the key passed.
        /// </summary>
        /// <param name="key">Key of the <see cref="Texture"/> Collection Name.</param>
        /// <param name="type">Type of the key passed.</param>
        /// <returns>Texture if it is found; null otherwise.</returns>
        public virtual Texture FindTexture(uint key, Database.Collection.eKeyType type) { return null; }

        /// <summary>
        /// Gets index of the <see cref="Texture"/> in the <see cref="TPKBlock"/>.
        /// </summary>
        /// <param name="CName">Collection Name of the <see cref="Texture"/>.</param>
        /// <returns>Index number as an integer. If element does not exist, returns -1.</returns>
        public virtual int GetTextureIndex(string CName) { return -1; }

        /// <summary>
        /// Attempts to add <see cref="Texture"/> to the <see cref="TPKBlock"/> data.
        /// </summary>
        /// <param name="CName">Collection Name of the new <see cref="Texture"/>.</param>
        /// <param name="filename">Path of the texture to be imported.</param>
        /// <returns>True if texture adding was successful, false otherwise.</returns>
        public virtual bool TryAddTexture(string CName, string filename) { return false; }

        /// <summary>
        /// Attempts to add <see cref="Texture"/> to the <see cref="TPKBlock"/> data.
        /// </summary>
        /// <param name="CName">Collection Name of the new <see cref="Texture"/>.</param>
        /// <param name="filename">Path of the texture to be imported.</param>
        /// <param name="error">Error occured when trying to add a texture.</param>
        /// <returns>True if texture adding was successful, false otherwise.</returns>
        public virtual bool TryAddTexture(string CName, string filename, out string error)
        {
            error = null;
            return false;
        }

        /// <summary>
        /// Attempts to remove <see cref="Texture"/> specified from <see cref="TPKBlock"/> data.
        /// </summary>
        /// <param name="CName">Collection Name of the <see cref="Texture"/> to be deleted.</param>
        /// <returns>True if texture removing was successful, false otherwise.</returns>
        public virtual bool TryRemoveTexture(string CName) { return false; }

        /// <summary>
        /// Attempts to remove <see cref="Texture"/> specified from <see cref="TPKBlock"/> data.
        /// </summary>
        /// <param name="CName">Collection Name of the <see cref="Texture"/> to be deleted.</param>
        /// <param name="error">Error occured when trying to remove a texture.</param>
        /// <returns>True if texture removing was successful, false otherwise.</returns>
        public virtual bool TryRemoveTexture(string CName, out string error)
        {
            error = null;
            return false;
        }

        /// <summary>
        /// Attempts to clone <see cref="Texture"/> specified in the <see cref="TPKBlock"/> data.
        /// </summary>
        /// <param name="newname">Collection Name of the new <see cref="Texture"/>.</param>
        /// <param name="copyfrom">Collection Name of the <see cref="Texture"/> to clone.</param>
        /// <returns>True if texture cloning was successful, false otherwise.</returns>
        public virtual bool TryCloneTexture(string newname, string copyfrom) { return false; }

        /// <summary>
        /// Attempts to clone <see cref="Texture"/> specified in the <see cref="TPKBlock"/> data.
        /// </summary>
        /// <param name="newname">Collection Name of the new <see cref="Texture"/>.</param>
        /// <param name="copyfrom">Collection Name of the <see cref="Texture"/> to clone.</param>
        /// <param name="error">Error occured when trying to clone a texture.</param>
        /// <returns>True if texture cloning was successful, false otherwise.</returns>
        public virtual bool TryCloneTexture(string newname, string copyfrom, out string error)
        {
            error = null;
            return false;
        }

        /// <summary>
        /// Attemps to replace <see cref="Texture"/> specified in the <see cref="TPKBlock"/> data with a new one.
        /// </summary>
        /// <param name="CName">Collection Name of the <see cref="Texture"/> to be replaced.</param>
        /// <param name="filename">Path of the texture that replaces the current one.</param>
        /// <returns>True if texture replacing was successful, false otherwise.</returns>
        public virtual bool TryReplaceTexture(string CName, string filename) { return false; }

        /// <summary>
        /// Attemps to replace <see cref="Texture"/> specified in the <see cref="TPKBlock"/> data with a new one.
        /// </summary>
        /// <param name="CName">Collection Name of the <see cref="Texture"/> to be replaced.</param>
        /// <param name="filename">Path of the texture that replaces the current one.</param>
        /// <param name="error">Error occured when trying to replace a texture.</param>
        /// <returns>True if texture replacing was successful, false otherwise.</returns>
        public virtual bool TryReplaceTexture(string CName, string filename, out string error)
        {
            error = null;
            return false;
        }

        /// <summary>
        /// Attemps to export <see cref="Texture"/> specified to the path and mode provided.
        /// </summary>
        /// <param name="CName">Collection Name of the <see cref="Texture"/> to be exported.</param>
        /// <param name="path">Path where the texture should be exported.</param>
        /// <param name="mode">Mode in which export the texture. Range: ".dds", ".png", ".jpg", ".tiff", ".bmp".</param>
        /// <returns>True if texture export was successful, false otherwise.</returns>
        public virtual bool TryExportTexture(string CName, string path, string mode) { return false; }

        /// <summary>
        /// Attemps to export <see cref="Texture"/> specified to the path and mode provided.
        /// </summary>
        /// <param name="CName">Collection Name of the <see cref="Texture"/> to be exported.</param>
        /// <param name="path">Path where the texture should be exported.</param>
        /// <param name="mode">Mode in which export the texture. Range: ".dds", ".png", ".jpg", ".tiff", ".bmp".</param>
        /// <param name="error">Error occured when trying to clone a texture.</param>
        /// <returns>True if texture export was successful, false otherwise.</returns>
        public virtual bool TryExportTexture(string CName, string path, string mode, out string error)
        {
            error = null;
            return false;
        }

        #endregion

        #region Reading Methods

        /// <summary>
        /// Finds offsets of all partials and its parts in the tpk block.
        /// </summary>
        /// <param name="byteptr_t">Pointer to the tpk block array.</param>
        /// <returns>Array of all offsets.</returns>
        protected virtual unsafe int[] FindOffsets(byte* byteptr_t) { return null; }

        /// <summary>
        /// Gets amount of textures in the tpk block.
        /// </summary>
        /// <param name="byteptr_t">Pointer to the tpk block array.</param>
        /// <param name="offset">Partial 1 part2 offset in the tpk block array.</param>
        /// <returns>Number of textures in the tpk block.</returns>
        protected virtual unsafe int GetTextureCount(byte* byteptr_t, int offset) { return 0; }

        /// <summary>
        /// Gets tpk header information.
        /// </summary>
        /// <param name="byteptr_t">Pointer to the tpk block array.</param>
        /// <param name="offset">Partial 1 part1 offset in the tpk block array.</param>
        protected virtual unsafe void GetHeaderInfo(byte* byteptr_t, int offset) { }

        /// <summary>
        /// Gets list of keys of the textures in the tpk block array.
        /// </summary>
        /// <param name="byteptr_t">Pointer to the tpk block array.</param>
        /// <param name="offset">Partial 1 part2 offset in the tpk block array.</param>
        protected virtual unsafe void GetKeyList(byte* byteptr_t, int offset) { }

        /// <summary>
        /// Gets list of offset slots of the textures in the tpk block array.
        /// </summary>
        /// <param name="byteptr_t">Pointer to the tpk block array.</param>
        /// <param name="offset">Partial 1 part3 offset in the tpk block array.</param>
        protected virtual unsafe void GetOffsetSlots(byte* byteptr_t, int offset) { }

        /// <summary>
        /// Gets list of compressions of the textures in the tpk block array.
        /// </summary>
        /// <param name="byteptr_t">Pointer to the tpk block array.</param>
        /// <param name="offset">Partial 1 part5 offset in the tpk block array.</param>
        protected virtual unsafe void GetCompressionList(byte* byteptr_t, int offset) { }

        /// <summary>
        /// Gets list of offsets and sizes of the texture headers in the tpk block array.
        /// </summary>
        /// <param name="byteptr_t">Pointer to the tpk block array.</param>
        /// <param name="offset">Partial 1 part4 offset in the tpk block array.</param>
        /// <returns>Array of offsets and sizes of texture headers.</returns>
        protected virtual unsafe int[,] GetTextureHeaders(byte* byteptr_t, int offset) { return null; }

        /// <summary>
        /// Parses compressed texture and returns it on the output.
        /// </summary>
        /// <param name="byteptr_t">Pointer to the tpk block array.</param>
        /// <param name="offslot">Offslot of the texture to be parsed</param>
        /// <returns>Decompressed texture valid to the current support.</returns>
        protected virtual unsafe void ParseCompTexture(byte* byteptr_t, Parts.TPKParts.OffSlot offslot) { }

        #endregion

        #region Writing Methods

        /// <summary>
        /// Sorts textures by their binary memory hashes.
        /// </summary>
        protected virtual unsafe void TextureSort() { }

        /// <summary>
        /// Checks texture keys and tpk keys for matching.
        /// </summary>
        protected virtual unsafe void CheckKeys() { }

        /// <summary>
        /// Checks texture compressions and tpk compressions for matching.
        /// </summary>
        protected virtual unsafe void CheckComps() { }

        /// <summary>
        /// Assembles partial 1 part1 of the tpk block.
        /// </summary>
        /// <returns>Byte array of the partial 1 part1.</returns>
        protected virtual unsafe byte[] Get1Part1() { return null; }

        /// <summary>
        /// Assembles partial 1 part2 of the tpk block.
        /// </summary>
        /// <returns>Byte array of the partial 1 part2.</returns>
        protected virtual unsafe byte[] Get1Part2() { return null; }

        /// <summary>
        /// Assembles partial 1 part4 of the tpk block.
        /// </summary>
        /// <returns>Byte array of the partial 1 part4.</returns>
        protected virtual unsafe byte[] Get1Part4() { return null; }

        /// <summary>
        /// Assembles partial 1 part5 of the tpk block.
        /// </summary>
        /// <returns>Byte array of the partial 1 part5.</returns>
        protected virtual unsafe byte[] Get1Part5() { return null; }

        /// <summary>
        /// Assembles partial 2 part1 of the tpk block.
        /// </summary>
        /// <returns>Byte array of the partial 2 part1.</returns>
        protected virtual unsafe byte[] Get2Part1() { return null; }

        /// <summary>
        /// Assembles partial 2 part2 of the tpk block.
        /// </summary>
        /// <returns>Byte array of the partial 2 part2.</returns>
        protected virtual unsafe byte[] Get2Part2() { return null; }

        #endregion
    }
}