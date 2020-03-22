namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class WorldShop
	{
		protected unsafe void Disassemble(byte* byteptr_t)
		{
			uint key = 0; // for reading keys and comparison

			// Collection Name
			this._collection_name = Utils.ScriptX.NullTerminatedString(byteptr_t, 0x20);

			// Intro Movie
			var str = Utils.ScriptX.NullTerminatedString(byteptr_t + 0x20, 0x18);
			if (!string.IsNullOrWhiteSpace(str)) this._intro_movie = str;

			// Shop Trigger
			key = *(uint*)(byteptr_t + 0x3C);
			this._shop_trigger = Core.Map.Lookup(key, true) ?? $"0x{key:X8}";

			// Shop Filename
			this._shop_filename = Utils.ScriptX.NullTerminatedString(byteptr_t + 0x40, 0x10);

			// Types and Unlocks
			this._shop_type = (Reflection.Enum.eWorldShopType)(*(byteptr_t + 0x50));
			this._initially_hidden = (*(byteptr_t + 0x51) == 1) ? Reflection.Enum.eBoolean.True : Reflection.Enum.eBoolean.False;

			key = *(uint*)(byteptr_t + 0x74);
			this._event_to_complete = Core.Map.Lookup(key, true) ?? $"0x{key:X8}";

			this._unlocked_by_event = (*(byteptr_t + 0x9C) == 1) ? Reflection.Enum.eBoolean.True : Reflection.Enum.eBoolean.False;
			this.BelongsToStage = *(byteptr_t + 0x9D);
		}
	}
}