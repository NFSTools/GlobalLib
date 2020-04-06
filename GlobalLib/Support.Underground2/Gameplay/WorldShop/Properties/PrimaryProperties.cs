using GlobalLib.Reflection;
using GlobalLib.Reflection.Attributes;
using GlobalLib.Reflection.Enum;
using GlobalLib.Reflection.Exception;
using System;

namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class WorldShop
	{
		private string _intro_movie = BaseArguments.NULL;
		private string _shop_trigger = BaseArguments.NULL;
		private string _event_to_complete = BaseArguments.NULL;
		private eWorldShopType _shop_type = eWorldShopType.PAINTSHOP;
		private eBoolean _initially_hidden = eBoolean.True;
		private eBoolean _unlocked_by_event = eBoolean.False;

		[AccessModifiable()]
		public string IntroMovie
		{
			get => this._intro_movie;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("This value cannot be left empty.");
				else if (value.Length > 0x17)
					throw new ArgumentLengthException("Length of the value passed should not exceed 23 characters.");
				else
					this._intro_movie = value;
			}
		}

		[AccessModifiable()]
		public string ShopTrigger
		{
			get => this._shop_trigger;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("This value cannot be left empty.");
				this._shop_trigger = value;
			}
		}

		[AccessModifiable()]
		[StaticModifiable()]
		public eWorldShopType ShopType
		{
			get => this._shop_type;
			set
			{
				if (Enum.IsDefined(typeof(eWorldShopType), value))
					this._shop_type = value;
				else
					throw new MappingFailException();
			}
		}

		[AccessModifiable()]
		[StaticModifiable()]
		public eBoolean InitiallyHidden
		{
			get => this._initially_hidden;
			set
			{
				if (Enum.IsDefined(typeof(eBoolean), value))
					this._initially_hidden = value;
				else
					throw new ArgumentOutOfRangeException("Value passed is not of boolean type.");
			}
		}

		[AccessModifiable()]
		[StaticModifiable()]
		public eBoolean RequiresEventCompleted
		{
			get => this._unlocked_by_event;
			set
			{
				if (Enum.IsDefined(typeof(eBoolean), value))
					this._unlocked_by_event = value;
				else
					throw new ArgumentOutOfRangeException("Value passed is not of boolean type.");
			}
		}

		[AccessModifiable()]
		[StaticModifiable()]
		public byte BelongsToStage { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public string EventToBeCompleted
		{
			get => this._event_to_complete;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("This value cannot be left empty.");
				this._event_to_complete = value;
			}
		}
	}
}