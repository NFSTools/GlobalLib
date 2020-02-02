namespace GlobalLib.Support.Shared.Class
{
    public partial class FNGroup
    {
        /// <summary>
        /// Binary memory hash of the collection name.
        /// </summary>
        public uint BinKey { get => Utils.Bin.Hash(this.CollectionName); }

        /// <summary>
        /// Vault memory hash of the collection name.
        /// </summary>
        public uint VltKey { get => Utils.Vlt.Hash(this.CollectionName); }

        /// <summary>
        /// Size of the group in Global memory.
        /// </summary>
        public uint Size { get; protected set; }

        /// <summary>
        /// Represents boolean of whether this group can be destroyed b/c it is repetitive.
        /// </summary>
        public bool Destroy { get; protected set; } = false;
    }
}
