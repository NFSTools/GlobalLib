using GlobalLib.Reflection.Attributes;
using GlobalLib.Reflection.Enum;
using GlobalLib.Reflection.Exception;
using System;

namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class PartUnlockable
	{
		private ePartUnlockReq _unlock_method_level1 = ePartUnlockReq.INITIALLY_UNLOCKED;
		private ePartUnlockReq _unlock_method_level2 = ePartUnlockReq.INITIALLY_UNLOCKED;
		private ePartUnlockReq _unlock_method_level3 = ePartUnlockReq.INITIALLY_UNLOCKED;

		[AccessModifiable()]
		[StaticModifiable()]
		public float VisualRating_Level1 { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public float VisualRating_Level2 { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public float VisualRating_Level3 { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public short PartPrice_Level1 { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public short PartPrice_Level2 { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public short PartPrice_Level3 { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public ePartUnlockReq UnlockMethod_Level1
		{
			get => this._unlock_method_level1;
			set
			{
				if (!Enum.IsDefined(typeof(ePartUnlockReq), value))
					throw new MappingFailException();
				else
					this._unlock_method_level1 = value;
			}
		}

		[AccessModifiable()]
		[StaticModifiable()]
		public ePartUnlockReq UnlockMethod_Level2
		{
			get => this._unlock_method_level2;
			set
			{
				if (!Enum.IsDefined(typeof(ePartUnlockReq), value))
					throw new MappingFailException();
				else
					this._unlock_method_level2 = value;
			}
		}

		[AccessModifiable()]
		[StaticModifiable()]
		public ePartUnlockReq UnlockMethod_Level3
		{
			get => this._unlock_method_level3;
			set
			{
				if (!Enum.IsDefined(typeof(ePartUnlockReq), value))
					throw new MappingFailException();
				else
					this._unlock_method_level3 = value;
			}
		}
	}
}