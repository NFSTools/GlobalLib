namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class BankTrigger
	{
		public unsafe byte[] Assemble()
		{
			var result = new byte[0xC];
			fixed (byte* byteptr_t = &result[0])
			{
				*(ushort*)byteptr_t = this.CashValue;
				*(byteptr_t + 2) = (this.InitiallyUnlocked == Reflection.Enum.eBoolean.True) ? (byte)1 : (byte)0;
				*(byteptr_t + 3) = this.BankIndex;
				*(int*)(byteptr_t + 4) = this.RequiredStagesCompleted;
				*(uint*)(byteptr_t + 8) = this.BinKey;
			}
			return result;
		}
	}
}