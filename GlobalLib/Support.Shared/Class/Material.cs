namespace GlobalLib.Support.Shared.Class
{
    public class Material : Reflection.Abstract.Collectable
    {
        #region Private Fields

        protected const int _Unknown0 = 0;
        protected const int _Unknown1 = 1;
        protected const int _Localizer = 3;

        #endregion

        #region Main Properties

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

        #endregion

        #region Methods

        /// <summary>
        /// Assembles material into a byte array.
        /// </summary>
        /// <returns>Byte array of the material.</returns>
        public virtual unsafe byte[] Assemble() { return null; }

        /// <summary>
        /// Disassembles material array into separate properties.
        /// </summary>
        /// <param name="byteptr_t">Pointer to the material array.</param>
        protected virtual unsafe void Disassemble(byte* byteptr_t) { }

        #endregion
    }
}