using GlobalLib.Reflection.ID;

namespace GlobalLib.Support.Underground1.Class
{
	public partial class STRBlock
	{
		/// <summary>
		/// Assembles labels block into a byte array.
		/// </summary>
		/// <returns>Byte array of the labels block.</returns>
		public override unsafe byte[] ParseLabels()
		{
			// Precalculate size
			this._size = 0x10 + this._unknown.Length + this._stringinfo.Count * 8;
			foreach (var info in this._stringinfo)
				this._size += info.NulledLabelLength;
			int padding = 0x10 - ((this._size + 0xC) % 0x10);
			if (padding != 0x10) this._size += padding;

			// var mark = "GlobalLib by MaxHwoy " + DateTime.Today.ToString("dd-MM-yyyy");
			this._unk_data_offset = 0x10;
			this._key_offset = 0x10 + this._labunk.Length;
			this._text_offset = 0x10 + this._labunk.Length + this._stringinfo.Count * 8;

			// Begin writing
			var result = new byte[this._size + 8];
			fixed (byte* byteptr_t = &result[0])
			{
				// Write header
				*(uint*)byteptr_t = Global.STRBlocks;
				*(int*)(byteptr_t + 0x4) = this._size;
				*(int*)(byteptr_t + 0x8) = this._unk_data_offset;
				*(int*)(byteptr_t + 0xC) = this._stringinfo.Count;
				*(int*)(byteptr_t + 0x10) = this._key_offset;
				*(int*)(byteptr_t + 0x14) = this._text_offset;
				for (int a1 = 0; a1 < this._labunk.Length; ++a1)
					*(byteptr_t + 0x18 + a1) = this._labunk[a1];

				// Write hashes and offsets
				int textoff = 0;
				var keyptr_t = byteptr_t + 8 + this._key_offset;
				var textptr_t = byteptr_t + 8 + this._text_offset;
				for (int a1 = 0; a1 < this._stringinfo.Count; ++a1)
				{
					*(uint*)(keyptr_t + a1 * 8) = this._stringinfo[a1].Key;
					*(int*)(keyptr_t + a1 * 8 + 4) = textoff;
					for (int a2 = 0; a2 < this._stringinfo[a1].Label.Length; ++a2)
						*(textptr_t + textoff + a2) = (byte)this._stringinfo[a1].Label[a2];
					textoff += this._stringinfo[a1].NulledLabelLength;
				}
			}
			return result;
		}
	}
}