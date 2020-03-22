namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class GShowcase
	{
		private unsafe void Disassemble(byte* byteptr_t)
		{
			uint key = 0;

			// Collection Name
			this._collection_name = Utils.ScriptX.NullTerminatedString(byteptr_t, 0x20);

			// Take Photo Settings
			this._take_photo = (Reflection.Enum.eTakePhotoMethod)(*(byteptr_t + 0x24));
			this.BelongsToStage = *(byteptr_t + 0x25);
			this.CashValue = *(short*)(byteptr_t + 0x26);
			this.Unknown0x34 = *(byteptr_t + 0x34);
			this.Unknown0x35 = *(byteptr_t + 0x35);
			this.RequiredVisualRating = *(float*)(byteptr_t + 0x3C);

			// Showcase Strings
			key = *(uint*)(byteptr_t + 0x28);
			this._desc_string_label = Core.Map.Lookup(key, true) ?? $"0x{key:X8}";
			key = *(uint*)(byteptr_t + 0x2C);
			this._destination_point = Core.Map.Lookup(key, true) ?? $"0x{key:X8}";
			key = *(uint*)(byteptr_t + 0x38);
			this._desc_attrib = Core.Map.Lookup(key, true) ?? $"0x{key:X8}";
		}
	}
}