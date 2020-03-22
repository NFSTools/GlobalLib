﻿namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class PartUnlockable
	{
		private string _unlock_shop1 = Reflection.BaseArguments.NULL;
		private string _unlock_shop2 = Reflection.BaseArguments.NULL;
		private string _unlock_shop3 = Reflection.BaseArguments.NULL;

		[Reflection.Attributes.AccessModifiable()]
		public float VisualRating_Level1 { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		public float VisualRating_Level2 { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		public float VisualRating_Level3 { get; set; }

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
		public string UnlocksInShop_Level1
		{
			get => this._unlock_shop1;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new System.ArgumentNullException("This value cannot be left empty.");
				this._unlock_shop1 = value;
			}
		}

		[Reflection.Attributes.AccessModifiable()]
		public string UnlocksInShop_Level2
		{
			get => this._unlock_shop2;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new System.ArgumentNullException("This value cannot be left empty.");
				this._unlock_shop2 = value;
			}
		}

		[Reflection.Attributes.AccessModifiable()]
		public string UnlocksInShop_Level3
		{
			get => this._unlock_shop3;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new System.ArgumentNullException("This value cannot be left empty.");
				this._unlock_shop3 = value;
			}
		}
	}
}