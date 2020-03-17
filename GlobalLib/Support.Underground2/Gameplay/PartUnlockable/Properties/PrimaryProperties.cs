namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class PartUnlockable
	{
		[Reflection.Attributes.AccessModifiable()]
		public short VisualRating_Level1 { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		public short VisualRating_Level2 { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		public short VisualRating_Level3 { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		public short PartPrice_Level1 { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		public short PartPrice_Level2 { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		public short PartPrice_Level3 { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		public byte ReqStageDone_Level1 { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		public byte ReqStageDone_Level2 { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		public byte ReqStageDone_Level3 { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		public string UnlocksInShop_Level1 { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		public string UnlocksInShop_Level2 { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		public string UnlocksInShop_Level3 { get; set; }
	}
}