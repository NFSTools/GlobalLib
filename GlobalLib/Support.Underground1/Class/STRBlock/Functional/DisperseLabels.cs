using GlobalLib.Reflection.ID;
using GlobalLib.Utils;
using System.Collections.Generic;

namespace GlobalLib.Support.Underground1.Class
{
	public partial class STRBlock
	{
		/// <summary>
		/// Disassembles labels block array into separate properties.
		/// </summary>
		/// <param name="byteptr_t">Pointer to the label block array.</param>
		protected override unsafe void DisperseLabels(byte* byteptr_t, int length)
		{
			int ReaderOffset = 0;
			uint ReaderID = 0;
			int BlockSize = 0;
			bool found = false;

			// Run through file
			while (ReaderOffset < length)
			{
				ReaderID = *(uint*)(byteptr_t + ReaderOffset);
				BlockSize = *(int*)(byteptr_t + ReaderOffset + 4);
				if (!found && ReaderID == Global.STRBlocks)
				{
					this._offset = ReaderOffset;
					this._size = BlockSize;
					found = true;
				}
				ReaderOffset += 8 + BlockSize;
			}

			// Check if string block exists
			if (this._offset == -1 || this._size == -1) return;

			// Initialize map with keys and indexes
			var key_to_index = new Dictionary<uint, int>();
			for (int a1 = 0; a1 < this._stringinfo.Count; ++a1)
				key_to_index[this._stringinfo[a1].Key] = a1;

			// Advance position and read through header
			byteptr_t += this._offset + 8;
			this._unk_data_offset = *(int*)byteptr_t;
			this._num_entries = *(int*)(byteptr_t + 4);
			this._key_offset = *(int*)(byteptr_t + 8);
			this._text_offset = *(int*)(byteptr_t + 12);

			// Get unknown data into memory
			this._labunk = new byte[this._key_offset - this._unk_data_offset];
			for (int a1 = 0; a1 < this._labunk.Length; ++a1)
				this._labunk[a1] = *(byteptr_t + this._unk_data_offset + a1);

			// Begin reading through string records
			for (int a1 = 0; a1 < this._num_entries; ++a1)
			{
				var key = *(uint*)(byteptr_t + this._key_offset + a1 * 8);
				var pos = this._text_offset + *(int*)(byteptr_t + this._key_offset + a1 * 8 + 4);
				var label = ScriptX.NullTerminatedString(byteptr_t + pos);
				if (key_to_index.TryGetValue(key, out int index))
					this._stringinfo[index].Label = label;
				Bin.Hash(label);
			}
		}
	}
}