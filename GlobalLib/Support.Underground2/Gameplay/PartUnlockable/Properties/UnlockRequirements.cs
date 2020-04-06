using GlobalLib.Reflection;
using GlobalLib.Reflection.Attributes;
using System;

namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class PartUnlockable
	{
		private string _unlock_shop1 = BaseArguments.NULL;
		private string _unlock_shop2 = BaseArguments.NULL;
		private string _unlock_shop3 = BaseArguments.NULL;


		[AccessModifiable()]
		[StaticModifiable()]
		public string UnlocksInShop_Level1
		{
			get => this._unlock_shop1;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("This value cannot be left empty.");
				this._unlock_shop1 = value;
			}
		}

		[AccessModifiable()]
		[StaticModifiable()]
		public string UnlocksInShop_Level2
		{
			get => this._unlock_shop2;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("This value cannot be left empty.");
				this._unlock_shop2 = value;
			}
		}

		[AccessModifiable()]
		[StaticModifiable()]
		public string UnlocksInShop_Level3
		{
			get => this._unlock_shop3;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("This value cannot be left empty.");
				this._unlock_shop3 = value;
			}
		}

		[AccessModifiable()]
		[StaticModifiable()]
		public byte RequiredRacesWon_Level1 { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public byte RequiredRacesWon_Level2 { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public byte RequiredRacesWon_Level3 { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public byte BelongsToStage_Level1 { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public byte BelongsToStage_Level2 { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public byte BelongsToStage_Level3 { get; set; }
	}
}
