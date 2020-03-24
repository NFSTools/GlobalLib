namespace GlobalLib.Support.Carbon.Class
{
    public partial class CarTypeInfo
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
                if (!this.Deletable)
                    throw new Reflection.Exception.CollectionExistenceException("CollectionName of a non-addon car cannot be changed.");
                if (string.IsNullOrWhiteSpace(value))
                    throw new System.ArgumentNullException("This value cannot be left empty.");
                if (value.Length > MaxCNameLength)
                    throw new Reflection.Exception.ArgumentLengthException("Length of the value passed should not exceed 13 characters.");
                if (this.Database.CarTypeInfos.Classes.ContainsKey(value))
                    throw new Reflection.Exception.CollectionExistenceException();
                this._collection_name = value;
                if (this._collision_external_name != Reflection.BaseArguments.NULL)
                    this._collision_external_name = value;
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

        /// <summary>
        /// Represents memory type of the cartypeinfo.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        public override Reflection.Enum.eMemoryType MemoryType { get => base.MemoryType; set => base.MemoryType = value; }
    }
}
