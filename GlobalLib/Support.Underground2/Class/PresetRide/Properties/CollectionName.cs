using GlobalLib.Reflection.Attributes;
using GlobalLib.Reflection.Exception;
using GlobalLib.Utils;
using System;

namespace GlobalLib.Support.Underground2.Class
{
    public partial class PresetRide
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
                if (value.Length > MaxCNameLength)
                    throw new ArgumentLengthException("Length of the value passed should not exceed 31 characters.");
                if (this.Database.PresetRides.FindCollection(value) != null)
                    throw new CollectionExistenceException();
                this._collection_name = value;
            }
        }

        /// <summary>
        /// Binary memory hash of the collection name.
        /// </summary>
        public override uint BinKey { get => Bin.Hash(this._collection_name); }

        /// <summary>
        /// Vault memory hash of the collection name.
        /// </summary>
        public override uint VltKey { get => Vlt.Hash(this._collection_name); }
    
        
    }
}