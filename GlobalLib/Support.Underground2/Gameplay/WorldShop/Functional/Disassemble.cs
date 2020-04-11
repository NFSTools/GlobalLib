using GlobalLib.Core;
using GlobalLib.Reflection.Enum;
using GlobalLib.Utils;

namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class WorldShop
	{
		protected unsafe void Disassemble(byte* byteptr_t)
		{
			uint key = 0; // for reading keys and comparison

			// Collection Name
			this._collection_name = ScriptX.NullTerminatedString(byteptr_t, 0x20);

			// Intro Movie
			var str = ScriptX.NullTerminatedString(byteptr_t + 0x20, 0x18);
			if (!string.IsNullOrWhiteSpace(str)) this._intro_movie = str;

			// Shop Trigger
			key = *(uint*)(byteptr_t + 0x3C);
			var guess = $"TRIGGER_{this._collection_name}";
			var hash = Bin.Hash(guess);
			if (key == hash)
				this._shop_trigger = guess;
			else
				this._shop_trigger = Map.Lookup(key, true) ?? $"0x{key:X8}";

			// Shop Filename
			this._shop_filename = ScriptX.NullTerminatedString(byteptr_t + 0x40, 0x10);

			// Types and Unlocks
			this._shop_type = (eWorldShopType)(*(byteptr_t + 0x50));
			this._initially_hidden = (*(byteptr_t + 0x51) == 1) ? eBoolean.True : eBoolean.False;

			key = *(uint*)(byteptr_t + 0x74);
			this._event_to_complete = Map.Lookup(key, true) ?? $"0x{key:X8}";

			this._unlocked_by_event = (*(byteptr_t + 0x9C) == 1) ? eBoolean.True : eBoolean.False;
			this.BelongsToStage = *(byteptr_t + 0x9D);
		}
	}
}