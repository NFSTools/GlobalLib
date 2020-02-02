namespace GlobalLib.Support.Shared.Class
{
    public partial class CarTypeInfo : Reflection.Interface.IGetValue, Reflection.Interface.ISetValue
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
        /// Provides info on whether this cartypeinfo can be deleted or not.
        /// </summary>
        public bool Deletable { get; set; } = true;

        /// <summary>
        /// Provides info on whether this cartypeinfo was modified.
        /// </summary>
        public bool Modified { get; set; } = false;

        /// <summary>
        /// Original collection name of the cartypeinfo.
        /// </summary>
        public string OriginalName { get; protected set; }
    }
}