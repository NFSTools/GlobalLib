namespace GlobalLib.Support.MostWanted.Class
{
    public partial class CarTypeInfo : Shared.Class.CarTypeInfo, Reflection.Interface.ICastable<CarTypeInfo>
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
                if (value.Length > 13)
                    throw new Reflection.Exception.ArgumentLengthException();
                if (this.Database.GetClassIndex(value, GlobalLib.Database.ClassType.CarTypeInfo) != -1)
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
