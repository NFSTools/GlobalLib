using GlobalLib.Reflection;
using GlobalLib.Reflection.Attributes;
using GlobalLib.Reflection.Enum;
using GlobalLib.Reflection.Exception;
using GlobalLib.Utils;
using System;

namespace GlobalLib.Support.MostWanted.Class
{
    public partial class CarTypeInfo
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
                if (!this.Deletable)
                    throw new CollectionExistenceException("CollectionName of a non-addon car cannot be changed.");
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("This value cannot be left empty.");
                if (value.Contains(" "))
                    throw new Exception("CollectionName cannot contain whitespace.");
                if (value.Length > MaxCNameLength)
                    throw new ArgumentLengthException("Length of the value passed should not exceed 13 characters.");
                if (this.Database.CarTypeInfos.FindCollection(value) != null)
                    throw new CollectionExistenceException();
                this._collection_name = value;
                if (this._collision_external_name != BaseArguments.NULL)
                    this._collision_external_name = value;
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

        /// <summary>
        /// Represents memory type of the cartypeinfo.
        /// </summary>
        [AccessModifiable()]
        public override eMemoryType MemoryType { get => base.MemoryType; set => base.MemoryType = value; }
    }
}
