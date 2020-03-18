namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class PartUnlockable
	{
		private unsafe void Disassemble(byte* byteptr_t)
		{
			uint key = 0;

			// CollectionName
			this._collection_name = $"CARPART_{*(int*)byteptr_t:X2}";

			// Visual Ratings
			this.VisualRating_Level1 = (float)(((float)*(short*)(byteptr_t + 0x04)) * 0.002);
			this.VisualRating_Level2 = (float)(((float)*(short*)(byteptr_t + 0x10)) * 0.002);
			this.VisualRating_Level3 = (float)(((float)*(short*)(byteptr_t + 0x1C)) * 0.002);

			// Part Prices
			this.PartPrice_Level1 = *(short*)(byteptr_t + 6);
			this.PartPrice_Level2 = *(short*)(byteptr_t + 0x12);
			this.PartPrice_Level3 = *(short*)(byteptr_t + 0x1E);

			// Required Stages Done
			this.ReqStageDone_Level1 = *(byteptr_t + 8);
			this.ReqStageDone_Level2 = *(byteptr_t + 0x14);
			this.ReqStageDone_Level3 = *(byteptr_t + 0x20);

			// Unlocking Shops
			key = *(uint*)(byteptr_t + 0xC);
			this.UnlocksInShop_Level1 = Core.Map.Lookup(key) ?? string.Empty;
			key = *(uint*)(byteptr_t + 0x18);
			this.UnlocksInShop_Level2 = Core.Map.Lookup(key) ?? string.Empty;
			key = *(uint*)(byteptr_t + 0x24);
			this.UnlocksInShop_Level3 = Core.Map.Lookup(key) ?? string.Empty;
		}
	}
}