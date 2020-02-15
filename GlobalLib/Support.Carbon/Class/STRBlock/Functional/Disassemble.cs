namespace GlobalLib.Support.Carbon.Class
{
	public partial class STRBlock : Shared.Class.STRBlock
	{
		protected override unsafe void Disassemble(byte* byteptr_t, int length)
		{
			int ReaderOffset = 0;
			uint ReaderID = 0;
			int BlockSize = 0;

			// Run through file
			while (ReaderOffset < length)
			{
				ReaderID = *(uint*)(byteptr_t + ReaderOffset);
				BlockSize = *(int*)(byteptr_t + ReaderOffset + 4);
				if (ReaderID == Reflection.ID.Global.STRBlocks)
				{
					var categ = Utils.ScriptX.NullTerminatedString(byteptr_t + ReaderOffset + 20, 0x10);
					if (categ == "Global")
					{
						this._offset = ReaderOffset;
						this._size = BlockSize;
					}
				}
				ReaderOffset += 8 + BlockSize;
			}

			// Check if string block exists
			if (this._offset == -1 || this._size == -1) return;

			// Advance position and read through header
			byteptr_t += this._offset + 8;
			this._num_entries = *(int*)(byteptr_t);
			this._key_offset = *(int*)(byteptr_t + 4);
			this._text_offset = *(int*)(byteptr_t + 8);
			this._category = Utils.ScriptX.NullTerminatedString(byteptr_t + 12, 0x10);

			// Begin reading through string records
			for (int a1 = 0; a1 < this._num_entries; ++a1)
			{
				var info = new Shared.Parts.STRParts.StringRecord();
				info.Key = *(uint*)(byteptr_t + this._key_offset + a1 * 8);
				var pos = this._text_offset + *(int*)(byteptr_t + this._key_offset + a1 * 8 + 4);
				info.Text = Utils.ScriptX.NullTerminatedString(byteptr_t + pos);
				this._stringinfo.Add(info);
			}
		}
	}
}