using GlobalLib.Reflection.ID;
using System;

namespace GlobalLib.Support.Carbon.Class
{
	public partial class STRBlock
	{
		/// <summary>
		/// Assembles string block into a byte array.
		/// </summary>
		/// <returns>Byte array of the string block.</returns>
		public override unsafe byte[] Assemble()
		{
			// Precalculate size
			this._size = 0x3C + this._stringinfo.Count * 8;
			foreach (var info in this._stringinfo)
				this._size += info.NulledTextLength;
			int padding = 0x10 - ((this._size + 8) % 0x10);
			if (padding != 0x10) this._size += padding;

			var mark = "GlobalLib by MaxHwoy " + DateTime.Today.ToString("dd-MM-yyyy");
			this._key_offset = 0x3C;
			this._text_offset = 0x3C + this._stringinfo.Count * 8;

			// Sort records by keys
			this._stringinfo.Sort((a, b) => a.Key.CompareTo(b.Key));

			// Begin writing
			var result = new byte[this._size + 8];
			fixed (byte* byteptr_t = &result[0])
			{
				// Write header
				*(uint*)byteptr_t = Global.STRBlocks;
				*(int*)(byteptr_t + 0x4) = this._size;
				*(int*)(byteptr_t + 0x8) = this._stringinfo.Count;
				*(int*)(byteptr_t + 0xC) = this._key_offset;
				*(int*)(byteptr_t + 0x10) = this._text_offset;
				for (int a1 = 0; a1 < this._category.Length; ++a1)
					*(byteptr_t + 0x14 + a1) = (byte)this._category[a1];
				for (int a1 = 0; a1 < mark.Length; ++a1)
					*(byteptr_t + 0x24 + a1) = (byte)mark[a1];

				// Write hashes and offsets
				int textoff = 0;
				var keyptr_t = byteptr_t + 8 + this._key_offset;
				var textptr_t = byteptr_t + 8 + this._text_offset;
				for (int a1 = 0; a1 < this._stringinfo.Count; ++a1)
				{
					*(uint*)(keyptr_t + a1 * 8) = this._stringinfo[a1].Key;
					*(int*)(keyptr_t + a1 * 8 + 4) = textoff;
					for (int a2 = 0; a2 < this._stringinfo[a1].Text.Length; ++a2)
						*(textptr_t + textoff + a2) = (byte)this._stringinfo[a1].Text[a2];
					textoff += this._stringinfo[a1].NulledTextLength;
				}
			}
			return result;
		}
	}
}