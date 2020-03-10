using GlobalLib.Reflection.Abstract;



namespace GlobalLib.Support.Shared.Class
{
    public partial class PresetSkin : ICollectable
    {
        /// <summary>
        /// Collection name of the variable.
        /// </summary>
        public override string CollectionName { get; set; }

        /// <summary>
        /// Binary memory hash of the collection name.
        /// </summary>
        public virtual uint BinKey { get => Utils.Bin.Hash(this.CollectionName); }

        /// <summary>
        /// Vault memory hash of the collection name.
        /// </summary>
        public virtual uint VltKey { get => Utils.Vlt.Hash(this.CollectionName); }
    }
}