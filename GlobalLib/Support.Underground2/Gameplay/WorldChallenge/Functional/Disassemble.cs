using GlobalLib.Core;
using GlobalLib.Reflection.Enum;
using GlobalLib.Utils;

namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class WorldChallenge
	{
		protected unsafe void Disassemble(byte* ptr_header, byte* ptr_string)
		{
			ushort pointer = 0; // used for reading pointer data
			uint key = 0; // for reading keys and comparison

			// Collection Name
			pointer = *(ushort*)ptr_header;
			this._collection_name = ScriptX.NullTerminatedString(ptr_string + pointer);

			// Challenge Trigger
			pointer = *(ushort*)(ptr_header + 2);
			this._world_trigger = ScriptX.NullTerminatedString(ptr_string + pointer);

			// Stage and Unlock settings
			this.BelongsToStage = *(ptr_header + 4);
			this._padding0 = *(ptr_header + 5);
			this.UseOutrunsAsReqRaces = (*(ptr_header + 6) == 2) ? eBoolean.True : eBoolean.False;
			this.RequiredRacesWon = *(ptr_header + 7);

			// Hashes
			key = *(uint*)(ptr_header + 0x8);
			this._sms_label = Map.Lookup(key, true) ?? $"0x{key:X8}";
			key = *(uint*)(ptr_header + 0xC);
			this._chal_parent = Map.Lookup(key, true) ?? $"0x{key:X8}";

			// Time Limit
			this.TimeLimit = *(int*)(ptr_header + 0x10);

			// Type and Unlockables
			this.WorldChallengeType = (eWorldChallengeType)(*(ptr_header + 0x14));
			this.UnlockablePart1_Index = *(ptr_header + 0x15);
			this.UnlockablePart2_Index = *(ptr_header + 0x16);
			this.UnlockablePart3_Index = *(ptr_header + 0x17);
		}
	}
}