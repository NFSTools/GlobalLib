namespace GlobalLib.Support.Shared.Class
{
    public partial class TPKBlock
    {
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
    }
}