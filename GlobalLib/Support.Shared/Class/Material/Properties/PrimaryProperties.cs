namespace GlobalLib.Support.Shared.Class
{
    public partial class Material : Reflection.Interface.IGetValue, Reflection.Interface.ISetValue
    {
        /// <summary>
        /// ID of the material block
        /// </summary>
        public uint ID { get => Reflection.ID.Global.Materials; }

        /// <summary>
        /// Binary memory hash of the collection name.
        /// </summary>
        public virtual uint BinKey { get => 0; }

        /// <summary>
        /// Vault memory hash of the collection name.
        /// </summary>
        public virtual uint VltKey { get => 0; }
    }
}