using GlobalLib.Utils;

namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class WorldChallenge
	{
		public unsafe void Assemble(byte* byteptr_t, MemoryWriter mw)
		{
			ushort pointer = (ushort)mw.Position;
			mw.WriteNullTerminated(this._collection_name);
			*(ushort*)byteptr_t = pointer;

			pointer = (ushort)mw.Position;
			mw.WriteNullTerminated(this._world_trigger);
			*(ushort*)(byteptr_t + 0x02) = pointer;

			*(byteptr_t + 0x04) = this.BelongsToStage;
			*(byteptr_t + 0x06) = (byte)((byte)this.UseOutrunsAsReqRaces * 2);
			*(byteptr_t + 0x07) = this.RequiredRacesWon;
			*(uint*)(byteptr_t + 0x08) = Bin.SmartHash(this.ChallengeSMSLabel);
			*(uint*)(byteptr_t + 0x0C) = Bin.SmartHash(this.ChallengeParent);
			*(int*)(byteptr_t + 0x10) = this.TimeLimit;
			*(byteptr_t + 0x14) = (byte)this.WorldChallengeType;
			*(byteptr_t + 0x15) = this.UnlockablePart1_Index;
			*(byteptr_t + 0x16) = this.UnlockablePart2_Index;
			*(byteptr_t + 0x17) = this.UnlockablePart3_Index;
		}
	}
}