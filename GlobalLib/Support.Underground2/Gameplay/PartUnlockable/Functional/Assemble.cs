namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class PartUnlockable
	{
		public unsafe void Assemble(byte* byteptr_t)
		{
			string index = Utils.FormatX.GetString(this._collection_name, "CARPART_{X}");
			*(int*)byteptr_t = Utils.ConvertX.ToInt32(index);

			*(short*)(byteptr_t + 0x04) = (short)(this.VisualRating_Level1 * 500);
			*(short*)(byteptr_t + 0x10) = (short)(this.VisualRating_Level2 * 500);
			*(short*)(byteptr_t + 0x1C) = (short)(this.VisualRating_Level3 * 500);

			*(short*)(byteptr_t + 0x06) = this.PartPrice_Level1;
			*(short*)(byteptr_t + 0x12) = this.PartPrice_Level2;
			*(short*)(byteptr_t + 0x1E) = this.PartPrice_Level3;

			*(byteptr_t + 0x08) = this.ReqStageDone_Level1;
			*(byteptr_t + 0x14) = this.ReqStageDone_Level2;
			*(byteptr_t + 0x20) = this.ReqStageDone_Level3;

			*(byteptr_t + 0x09) = (byte)1;
			*(byteptr_t + 0x15) = (byte)2;
			*(byteptr_t + 0x21) = (byte)3;

			*(uint*)(byteptr_t + 0x0C) = Utils.Bin.Hash(this.UnlocksInShop_Level1);
			*(uint*)(byteptr_t + 0x18) = Utils.Bin.Hash(this.UnlocksInShop_Level2);
			*(uint*)(byteptr_t + 0x24) = Utils.Bin.Hash(this.UnlocksInShop_Level3);
		}
	}
}