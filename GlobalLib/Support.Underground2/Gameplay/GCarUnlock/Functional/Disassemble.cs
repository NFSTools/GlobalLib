namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class GCarUnlock
	{
		private unsafe void Disassemble(byte* byteptr_t)
		{
			uint key = 0;

			// Resolve data
			key = *(uint*)byteptr_t;
			this._collection_name = Core.Map.Lookup(key) ?? $"0x{key:X8}";
			key = *(uint*)(byteptr_t + 4);
			if (key != 0) this._req_event_completed1 = Core.Map.Lookup(key) ?? $"0x{key:X8}";
			key = *(uint*)(byteptr_t + 8);
			if (key != 0) this._req_event_completed2 = Core.Map.Lookup(key) ?? $"0x{key:X8}";
		}
	}
}