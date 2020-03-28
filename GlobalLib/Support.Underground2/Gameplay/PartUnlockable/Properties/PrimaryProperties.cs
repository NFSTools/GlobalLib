namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class PartUnlockable
	{
		private Reflection.Enum.ePartUnlockReq _unlock_method_level1 = Reflection.Enum.ePartUnlockReq.INITIALLY_UNLOCKED;
		private Reflection.Enum.ePartUnlockReq _unlock_method_level2 = Reflection.Enum.ePartUnlockReq.INITIALLY_UNLOCKED;
		private Reflection.Enum.ePartUnlockReq _unlock_method_level3 = Reflection.Enum.ePartUnlockReq.INITIALLY_UNLOCKED;

		[Reflection.Attributes.AccessModifiable()]
		[Reflection.Attributes.StaticModifiable()]
		public float VisualRating_Level1 { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		[Reflection.Attributes.StaticModifiable()]
		public float VisualRating_Level2 { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		[Reflection.Attributes.StaticModifiable()]
		public float VisualRating_Level3 { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		[Reflection.Attributes.StaticModifiable()]
		public short PartPrice_Level1 { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		[Reflection.Attributes.StaticModifiable()]
		public short PartPrice_Level2 { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		[Reflection.Attributes.StaticModifiable()]
		public short PartPrice_Level3 { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		[Reflection.Attributes.StaticModifiable()]
		public Reflection.Enum.ePartUnlockReq UnlockMethod_Level1
		{
			get => this._unlock_method_level1;
			set
			{
				if (!System.Enum.IsDefined(typeof(Reflection.Enum.ePartUnlockReq), value))
					throw new Reflection.Exception.MappingFailException();
				else
					this._unlock_method_level1 = value;
			}
		}

		[Reflection.Attributes.AccessModifiable()]
		[Reflection.Attributes.StaticModifiable()]
		public Reflection.Enum.ePartUnlockReq UnlockMethod_Level2
		{
			get => this._unlock_method_level2;
			set
			{
				if (!System.Enum.IsDefined(typeof(Reflection.Enum.ePartUnlockReq), value))
					throw new Reflection.Exception.MappingFailException();
				else
					this._unlock_method_level2 = value;
			}
		}

		[Reflection.Attributes.AccessModifiable()]
		[Reflection.Attributes.StaticModifiable()]
		public Reflection.Enum.ePartUnlockReq UnlockMethod_Level3
		{
			get => this._unlock_method_level3;
			set
			{
				if (!System.Enum.IsDefined(typeof(Reflection.Enum.ePartUnlockReq), value))
					throw new Reflection.Exception.MappingFailException();
				else
					this._unlock_method_level3 = value;
			}
		}
	}
}