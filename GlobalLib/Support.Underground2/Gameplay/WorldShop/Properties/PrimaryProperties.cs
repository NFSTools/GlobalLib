namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class WorldShop
	{
		private string _intro_movie;
		private Reflection.Enum.eWorldShopType _shop_type = Reflection.Enum.eWorldShopType.PAINTSHOP;
		private Reflection.Enum.eBoolean _initially_hidden = Reflection.Enum.eBoolean.True;
		private Reflection.Enum.eBoolean _unlocked_by_event = Reflection.Enum.eBoolean.False;

		[Reflection.Attributes.AccessModifiable()]
		public string IntroMovie
		{
			get => this._intro_movie;
			set
			{
				if (value == null) this._intro_movie = string.Empty;
				else if (value.Length > 0x17)
					throw new Reflection.Exception.ArgumentLengthException("Length of the value passed should not exceed 23 characters.");
				else
					this._intro_movie = value;
			}
		}

		[Reflection.Attributes.AccessModifiable()]
		public string ShopTrigger { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		public Reflection.Enum.eWorldShopType ShopType
		{
			get => this._shop_type;
			set
			{
				if (System.Enum.IsDefined(typeof(Reflection.Enum.eWorldShopType), value))
					this._shop_type = value;
				else
					throw new Reflection.Exception.MappingFailException();
			}
		}

		[Reflection.Attributes.AccessModifiable()]
		public Reflection.Enum.eBoolean InitiallyHidden
		{
			get => this._initially_hidden;
			set
			{
				if (System.Enum.IsDefined(typeof(Reflection.Enum.eBoolean), value))
					this._initially_hidden = value;
				else
					throw new System.ArgumentOutOfRangeException("Value passed is not of boolean type.");
			}
		}

		[Reflection.Attributes.AccessModifiable()]
		public Reflection.Enum.eBoolean RequiresEventCompleted
		{
			get => this._unlocked_by_event;
			set
			{
				if (System.Enum.IsDefined(typeof(Reflection.Enum.eBoolean), value))
					this._unlocked_by_event = value;
				else
					throw new System.ArgumentOutOfRangeException("Value passed is not of boolean type.");
			}
		}

		[Reflection.Attributes.AccessModifiable()]
		public byte BelongsToStage { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		public string EventToBeCompleted { get; set; }
	}
}