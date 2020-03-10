namespace GlobalLib.Support.Shared.Class
{
	public class STRBlock
	{
		#region Main Properties

		/// <summary>
		/// Binary memory hash of the collection name.
		/// </summary>
		public virtual uint BinKey { get => 0; }

        /// <summary>
        /// Vault memory hash of the collection name.
        /// </summary>
        public virtual uint VltKey { get => 0; }

		#endregion

		#region Methods

		/// <summary>
		/// Assembles string block into a byte array.
		/// </summary>
		/// <returns>Byte array of the string block.</returns>
		public virtual unsafe byte[] Assemble() { return null; }

		/// <summary>
		/// Disassembles string block array into separate properties.
		/// </summary>
		/// <param name="byteptr_t">Pointer to the string block array.</param>
		protected virtual unsafe void Disassemble(byte* byteptr_t, int length) { }

		/// <summary>
		/// Disassembles labels block array into separate properties.
		/// </summary>
		/// <param name="byteptr_t">Pointer to the label block array.</param>
		protected virtual unsafe void DisperseLabels(byte* byteptr_t, int length) { }

		/// <summary>
		/// Assembles labels block into a byte array.
		/// </summary>
		/// <returns>Byte array of the labels block.</returns>
		public virtual unsafe byte[] ParseLabels() { return null; }

		#endregion
	}
}