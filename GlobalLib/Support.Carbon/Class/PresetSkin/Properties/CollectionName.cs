namespace GlobalLib.Support.Carbon.Class
{
    public partial class PresetSkin : Shared.Class.PresetSkin, Reflection.Interface.ICastable<PresetSkin>
    {
        private string _collection_name;

        /// <summary>
        /// Collection name of the variable.
        /// </summary>
        public string CollectionName
        {
            get => this._collection_name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new System.ArgumentNullException();
                if (value.Length > 0x1F)
                    throw new Reflection.Exception.ArgumentLengthException();
                if (this.Database.GetClassIndex(value, GlobalLib.Database.ClassType.PresetSkin) != -1)
                    throw new Reflection.Exception.CollectionExistenceException();
                this._collection_name = value;
            }
        }

        /// <summary>
        /// Binary memory hash of the collection name.
        /// </summary>
        public override uint BinKey { get => Utils.Bin.Hash(this._collection_name); }

        /// <summary>
        /// Vault memory hash of the collection name.
        /// </summary>
        public override uint VltKey { get => Utils.Vlt.Hash(this._collection_name); }
    }
}