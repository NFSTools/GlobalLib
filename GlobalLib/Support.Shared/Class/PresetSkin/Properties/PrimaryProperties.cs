namespace GlobalLib.Support.Shared.Class
{
    public partial class PresetSkin : Reflection.Interface.IGetValue, Reflection.Interface.ISetValue
    {
        /// <summary>
        /// Binary memory hash of the collection name.
        /// </summary>
        public uint BinKey { get => Utils.Bin.Hash(this._collection_name); }

        /// <summary>
        /// Vault memory hash of the collection name.
        /// </summary>
        public uint VltKey { get => Utils.Vlt.Hash(this._collection_name); }
    }
}