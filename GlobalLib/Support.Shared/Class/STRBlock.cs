using System.Collections.Generic;
using GlobalLib.Support.Shared.Parts.STRParts;



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

		/// <summary>
		/// Gets the <see cref="StringRecord"/> from the internal list.
		/// </summary>
		/// <param name="key">Key of the <see cref="StringRecord"/> to find.</param>
		/// <returns>StringRecord is it exists; otherwise null;</returns>
		public virtual StringRecord GetRecord(uint key) { return null; }

		/// <summary>
		/// Gets text from the binary key of a label provided.
		/// </summary>
		/// <param name="key">Key of the string label.</param>
		/// <returns>Text of the label as a string.</returns>
		public virtual string GetText(uint key)
		{
			return this.GetRecord(key)?.Text;
		}

		/// <summary>
		/// Attempts to add <see cref="StringRecord"/> in the <see cref="STRBlock"/>.
		/// </summary>
		/// <param name="key">Key of the new <see cref="StringRecord"/></param>
		/// <param name="label">Label of the new <see cref="StringRecord"/></param>
		/// <param name="text">Text of the new <see cref="StringRecord"/></param>
		/// <returns>True if adding was successful; false otherwise.</returns>
		public virtual bool TryAddRecord(string key, string label, string text) { return false; }

		/// <summary>
		/// Attempts to add <see cref="StringRecord"/> in the <see cref="STRBlock"/>.
		/// </summary>
		/// <param name="key">Key of the new <see cref="StringRecord"/></param>
		/// <param name="label">Label of the new <see cref="StringRecord"/></param>
		/// <param name="text">Text of the new <see cref="StringRecord"/></param>
		/// <param name="error">Error occured when trying to add the record.</param>
		/// <returns>True if adding was successful; false otherwise.</returns>
		public virtual bool TryAddRecord(string key, string label, string text, out string error)
		{
			error = null;
			return false;
		}

		/// <summary>
		/// Attempts to remove <see cref="StringRecord"/> with the key provided.
		/// </summary>
		/// <param name="index">Key of the <see cref="StringRecord"/> to be removed.</param>
		/// <returns>True if removing was successful; false otherwise.</returns>
		public virtual bool TryRemoveRecord(uint key) { return false; }

		/// <summary>
		/// Attempts to remove <see cref="StringRecord"/> with the key provided.
		/// </summary>
		/// <param name="index">Key of the <see cref="StringRecord"/> to be removed.</param>
		/// <param name="error">Error occured when trying to remove the record.</param>
		/// <returns>True if removing was successful; false otherwise.</returns>
		public virtual bool TryRemoveRecord(uint key, out string error)
		{
			error = null;
			return false;
		}

		/// <summary>
		/// Retrieves all <see cref="StringRecord"/> that have their texts containing text provided.
		/// </summary>
		/// <param name="text">Text that other <see cref="StringRecord"/> should match.</param>
		/// <returns>Enumerable of records containing text provided.</returns>
		public virtual IEnumerable<StringRecord> FindWithText(string text) { return null; }

		#endregion
	}
}