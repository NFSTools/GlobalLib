using GlobalLib.Reflection.Abstract;
using GlobalLib.Reflection.Interface;


namespace GlobalLib.Support.Shared.Class
{
    public partial class Material : ICollectable, IGetValue, ISetValue
    {
        /// <summary>
        /// ID of the material block
        /// </summary>
        public uint ID { get => Reflection.ID.Global.Materials; }

        /// <summary>
        /// Collection name of the variable.
        /// </summary>
        public override string CollectionName { get; set; }

        /// <summary>
        /// Binary memory hash of the collection name.
        /// </summary>
        public virtual uint BinKey { get => Utils.Bin.Hash(this.CollectionName); }

        /// <summary>
        /// Vault memory hash of the collection name.
        /// </summary>
        public virtual uint VltKey { get => Utils.Vlt.Hash(this.CollectionName); }
    }
}