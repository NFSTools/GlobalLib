namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class Sponsor
	{
		public unsafe byte[] Assemble(Utils.MemoryWriter mw)
		{
			var result = new byte[0x10];
			fixed (byte* byteptr_t = &result[0])
			{
				ushort pointer = (ushort)mw.Position;
				mw.WriteNullTerminated(this._collection_name);
				*(ushort*)byteptr_t = pointer;
				*(short*)(byteptr_t + 2) = this.CashValuePerWin;
				*(byteptr_t + 4) = (byte)this.ReqSponsorRace1;
				*(byteptr_t + 5) = (byte)this.ReqSponsorRace2;
				*(byteptr_t + 6) = (byte)this.ReqSponsorRace3;
				*(uint*)(byteptr_t + 8) = this.BinKey;
				*(short*)(byteptr_t + 12) = this.SignCashBonus;
				*(short*)(byteptr_t + 14) = this.PotentialCashBonus;
			}
			return result;
		}
	}
}


