namespace GlobalLib.Support.Underground2.Class
{
    public partial class Material
    {
        private string _collection_name;

        /// <summary>
        /// Collection name of the variable.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        public override string CollectionName
        {
            get => this._collection_name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new System.ArgumentNullException("This value cannot be left empty.");
                if (value.Length > 0x1B)
                    throw new Reflection.Exception.ArgumentLengthException("Length of the value passed should not exceed 27 characters.");
                if (this.Database.GetClassIndex(value, GlobalLib.Database.eClassType.Material) != -1)
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