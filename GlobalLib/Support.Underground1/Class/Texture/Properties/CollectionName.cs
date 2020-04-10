using GlobalLib.Reflection.Attributes;
using GlobalLib.Reflection.Enum;
using GlobalLib.Reflection.Exception;
using GlobalLib.Utils;
using System;


namespace GlobalLib.Support.Underground1.Class
{
    public partial class Texture
    {
        private string _collection_name;

        /// <summary>
        /// Collection name of the variable.
        /// </summary>
        [AccessModifiable()]
        public override string CollectionName
        {
            get => this._collection_name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("This value cannot be left empty.");
                if (value.Contains(" "))
                    throw new Exception("CollectionName cannot contain whitespace.");
                var tpk = this.Database.TPKBlocks.FindCollection(this._parent_TPK);
                var key = Bin.Hash(value);
                var type = eKeyType.BINKEY;
                if (tpk.GetTextureIndex(key, type) != -1)
                    throw new CollectionExistenceException();
                this._collection_name = value;
                this.BinKey = Bin.Hash(value);
            }
        }
    }
}