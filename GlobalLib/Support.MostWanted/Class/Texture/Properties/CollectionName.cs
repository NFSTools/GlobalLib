namespace GlobalLib.Support.MostWanted.Class
{
    public partial class Texture
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
                if (value.Contains(" "))
                    throw new System.Exception("CollectionName cannot contain whitespace.");
                var tpk = this.Database.TPKBlocks.FindCollection(this._parent_TPK);
                var key = Utils.Bin.Hash(value);
                var type = Reflection.Enum.eKeyType.BINKEY;
                if (tpk.GetTextureIndex(key, type) != -1)
                    throw new Reflection.Exception.CollectionExistenceException();
                this._collection_name = value;
                this.BinKey = Utils.Bin.Hash(value);
            }
        }
    }
}