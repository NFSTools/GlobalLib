using GlobalLib.Core;
using GlobalLib.Reflection.Enum;

namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class BankTrigger
	{
		private unsafe void Disassemble(byte* byteptr_t)
		{
			this.CashValue = *(ushort*)byteptr_t;
			this._initially_unlocked = (*(byteptr_t + 2) == 1) ? eBoolean.False : eBoolean.True;
			this.BankIndex = *(byteptr_t + 3);
			this.RequiredStagesCompleted = *(int*)(byteptr_t + 4);
			uint key = *(uint*)(byteptr_t + 8);
			this._collection_name = Map.Lookup(key, false) ?? $"0x{key:X8}";
		}
	}
}