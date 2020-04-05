using GlobalLib.Reflection.Enum;
using GlobalLib.Utils;

namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class PartUnlockable
	{
		public unsafe void Assemble(byte* byteptr_t)
		{
			*(int*)byteptr_t = this.GetValidCollectionIndex();

			*(short*)(byteptr_t + 0x04) = (short)(this.VisualRating_Level1 * 500);
			*(short*)(byteptr_t + 0x10) = (short)(this.VisualRating_Level2 * 500);
			*(short*)(byteptr_t + 0x1C) = (short)(this.VisualRating_Level3 * 500);

			*(short*)(byteptr_t + 0x06) = this.PartPrice_Level1;
			*(short*)(byteptr_t + 0x12) = this.PartPrice_Level2;
			*(short*)(byteptr_t + 0x1E) = this.PartPrice_Level3;

			*(byteptr_t + 0x08) = (byte)this._unlock_method_level1;
			*(byteptr_t + 0x14) = (byte)this._unlock_method_level2;
			*(byteptr_t + 0x20) = (byte)this._unlock_method_level3;

			*(byteptr_t + 0x09) = (byte)1;
			*(byteptr_t + 0x15) = (byte)2;
			*(byteptr_t + 0x21) = (byte)3;

			if (this._unlock_method_level1 == ePartUnlockReq.SPECIFIC_SHOP_FOUND)
				*(uint*)(byteptr_t + 0x0C) = Bin.SmartHash(this.UnlocksInShop_Level1);
			else
			{
				*(byteptr_t + 0x0C) = this.RequiredRacesWon_Level1;
				*(byteptr_t + 0x0E) = this.BelongsToStage_Level1;
			}

			if (this._unlock_method_level2 == ePartUnlockReq.SPECIFIC_SHOP_FOUND)
				*(uint*)(byteptr_t + 0x18) = Bin.SmartHash(this.UnlocksInShop_Level2);
			else
			{
				*(byteptr_t + 0x18) = this.RequiredRacesWon_Level2;
				*(byteptr_t + 0x1A) = this.BelongsToStage_Level2;
			}

			if (this._unlock_method_level3 == ePartUnlockReq.SPECIFIC_SHOP_FOUND)
				*(uint*)(byteptr_t + 0x24) = Bin.SmartHash(this.UnlocksInShop_Level3);
			else
			{
				*(byteptr_t + 0x24) = this.RequiredRacesWon_Level3;
				*(byteptr_t + 0x26) = this.BelongsToStage_Level3;
			}
		}
	}
}