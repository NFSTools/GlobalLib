using GlobalLib.Reflection;
using GlobalLib.Reflection.Attributes;
using GlobalLib.Reflection.Enum;
using GlobalLib.Reflection.Exception;
using System;

namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class GCareerRace
	{
		private string _event_trigger = BaseArguments.NULL;
		private eUnlockCondition _unlock_method = eUnlockCondition.SPECIFIC_RACE_WON;
		private eBoolean _is_suv_race = eBoolean.False;
		private eEventBehaviorType _event_behavior = eEventBehaviorType.Circuit;

		[AccessModifiable()]
		public string EventTrigger
		{
			get => this._event_trigger;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("This value cannot be left empty.");
				this._event_trigger = value;
			}
		}

		[AccessModifiable()]
		[StaticModifiable()]
		public eUnlockCondition UnlockMethod
		{
			get => this._unlock_method;
			set
			{
				if (Enum.IsDefined(typeof(eUnlockCondition), value))
					this._unlock_method = value;
				else
					throw new MappingFailException();
			}
		}

		[AccessModifiable()]
		[StaticModifiable()]
		public eBoolean IsSUVRace
		{
			get => this._is_suv_race;
			set
			{
				if (Enum.IsDefined(typeof(eBoolean), value))
					this._is_suv_race = value;
				else
					throw new ArgumentOutOfRangeException("Value passed is not of boolean type.");
			}
		}

		[AccessModifiable()]
		public eEventBehaviorType EventBehaviorType
		{
			get => this._event_behavior;
			set
			{
				if (Enum.IsDefined(typeof(eEventBehaviorType), value))
					this._event_behavior = value;
				else
					throw new MappingFailException();
			}
		}
	}
}