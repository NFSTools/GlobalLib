using GlobalLib.Reflection.Abstract;
using GlobalLib.Reflection.Interface;


namespace GlobalLib.Support.Shared.Class
{
    public partial class CarTypeInfo : ICollectable, IGetValue, ISetValue
    {
        /// <summary>
        /// Collection name of the variable.
        /// </summary>
        public override string CollectionName { get; set; }

        /// <summary>
        /// Binary memory hash of the collection name.
        /// </summary>
        public virtual uint BinKey { get => 0; }

        /// <summary>
        /// Vault memory hash of the collection name.
        /// </summary>
        public virtual uint VltKey { get => 0; }

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