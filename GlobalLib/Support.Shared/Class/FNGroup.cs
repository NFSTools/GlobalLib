namespace GlobalLib.Support.Shared.Class
{
    public class FNGroup
    {
		#region Main Properties

		/// <summary>
		/// Collection name of the variable.
		/// </summary>
		public string CollectionName { get; protected set; }

        /// <summary>
        /// Binary memory hash of the collection name.
        /// </summary>
        public uint BinKey { get => Utils.Bin.Hash(this.CollectionName); }

        /// <summary>
        /// Vault memory hash of the collection name.
        /// </summary>
        public uint VltKey { get => Utils.Vlt.Hash(this.CollectionName); }

        /// <summary>
        /// Size of the group in Global memory.
        /// </summary>
        public uint Size { get; protected set; }

        /// <summary>
        /// Represents boolean of whether this group can be destroyed b/c it is repetitive.
        /// </summary>
        public bool Destroy { get; protected set; } = false;

        #endregion

        #region Methods

        /// <summary>
        /// Assembles frontend group into a byte array.
        /// </summary>
        /// <returns>Byte array of the frontend group.</returns>
        public virtual unsafe byte[] Assemble() { return null; }

        /// <summary>
        /// Disassembles frontend group array into separate properties.
        /// </summary>
        /// <param name="byteptr_t">Pointer to the frontend group array.</param>
        protected virtual unsafe void Disassemble(byte[] data) { }

        #endregion
    }
}