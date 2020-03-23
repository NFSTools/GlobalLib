namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class PartUnlockable
	{
		private unsafe void Disassemble(byte* byteptr_t)
		{
			uint key = 0;
			string show = string.Empty;

			// CollectionName
			this._collection_name = this.GetValidCollectionName(*(int*)byteptr_t);

			// Visual Ratings
			this.VisualRating_Level1 = (float)(((float)*(short*)(byteptr_t + 0x04)) * 0.002);
			this.VisualRating_Level2 = (float)(((float)*(short*)(byteptr_t + 0x10)) * 0.002);
			this.VisualRating_Level3 = (float)(((float)*(short*)(byteptr_t + 0x1C)) * 0.002);

			// Part Prices
			this.PartPrice_Level1 = *(short*)(byteptr_t + 0x06);
			this.PartPrice_Level2 = *(short*)(byteptr_t + 0x12);
			this.PartPrice_Level3 = *(short*)(byteptr_t + 0x1E);

			// Required Stages Done
			this._unlock_method_level1 = (Reflection.Enum.ePartUnlockReq)(*(byteptr_t + 0x08));
			this._unlock_method_level2 = (Reflection.Enum.ePartUnlockReq)(*(byteptr_t + 0x14));
			this._unlock_method_level3 = (Reflection.Enum.ePartUnlockReq)(*(byteptr_t + 0x20));

			// Unlocking Requirements
			if (this._unlock_method_level1 == Reflection.Enum.ePartUnlockReq.SPECIFIC_SHOP_FOUND)
			{
				key = *(uint*)(byteptr_t + 0x0C);
				this.UnlocksInShop_Level1 = Core.Map.Lookup(key, true) ?? Reflection.BaseArguments.NULL;
			}
			else
			{
				this.RequiredRacesWon_Level1 = *(byteptr_t + 0x0C);
				this.BelongsToStage_Level1 = *(byteptr_t + 0x0E);
			}

			if (this._unlock_method_level2 == Reflection.Enum.ePartUnlockReq.SPECIFIC_SHOP_FOUND)
			{
				key = *(uint*)(byteptr_t + 0x18);
				this.UnlocksInShop_Level2 = Core.Map.Lookup(key, true) ?? Reflection.BaseArguments.NULL;
			}
			else
			{
				this.RequiredRacesWon_Level2 = *(byteptr_t + 0x18);
				this.BelongsToStage_Level2 = *(byteptr_t + 0x1A);
			}

			if (this._unlock_method_level3 == Reflection.Enum.ePartUnlockReq.SPECIFIC_SHOP_FOUND)
			{
				key = *(uint*)(byteptr_t + 0x24);
				this.UnlocksInShop_Level3 = Core.Map.Lookup(key, true) ?? Reflection.BaseArguments.NULL;
			}
			else
			{
				this.RequiredRacesWon_Level3 = *(byteptr_t + 0x24);
				this.BelongsToStage_Level3 = *(byteptr_t + 0x26);
			}
		}
	}
}