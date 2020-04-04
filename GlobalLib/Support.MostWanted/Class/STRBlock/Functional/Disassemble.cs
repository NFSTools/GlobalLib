namespace GlobalLib.Support.MostWanted.Class
{
	public partial class STRBlock
	{
		/// <summary>
		/// Disassembles string block array into separate properties.
		/// </summary>
		/// <param name="byteptr_t">Pointer to the string block array.</param>
		protected override unsafe void Disassemble(byte* byteptr_t, int length)
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
				if (!found && ReaderID == Reflection.ID.Global.STRBlocks)
				{
					this._offset = ReaderOffset;
					this._size = BlockSize;
					this.CollectionName = Reflection.BaseArguments.GLOBAL;
					found = true;
				}
				ReaderOffset += 8 + BlockSize;
			}

			// Check if string block exists
			if (this._offset == -1 || this._size == -1) return;

			// Advance position and read through header
			byteptr_t += this._offset + 8;
			this._unk_data_offset = *(int*)byteptr_t;
			this._num_entries = *(int*)(byteptr_t + 4);
			this._key_offset = *(int*)(byteptr_t + 8);
			this._text_offset = *(int*)(byteptr_t + 12);

			// Get unknown data into memory
			this._unknown = new byte[this._key_offset - this._unk_data_offset];
			for (int a1 = 0; a1 < this._unknown.Length; ++a1)
				this._unknown[a1] = *(byteptr_t + this._unk_data_offset + a1);

			// Begin reading through string records
			for (int a1 = 0; a1 < this._num_entries; ++a1)
			{
				var info = new Shared.Parts.STRParts.StringRecord(this);
				info.Key = *(uint*)(byteptr_t + this._key_offset + a1 * 8);
				var pos = this._text_offset + *(int*)(byteptr_t + this._key_offset + a1 * 8 + 4);
				info.Text = Utils.ScriptX.NullTerminatedString(byteptr_t + pos);
				this._stringinfo.Add(info);
			}
		}
	}
}