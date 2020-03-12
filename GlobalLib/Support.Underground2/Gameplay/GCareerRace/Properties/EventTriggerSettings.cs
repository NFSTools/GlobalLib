namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class GCareerRace
	{
		private Reflection.Enum.eUnlockCondition _unlock_method = Reflection.Enum.eUnlockCondition.SPECIFIC_RACE_WON;
		private Reflection.Enum.eBoolean _is_suv_race = Reflection.Enum.eBoolean.False;
		private Reflection.Enum.eEventBehaviorType _event_behavior = Reflection.Enum.eEventBehaviorType.CIRCUIT;

		[Reflection.Attributes.AccessModifiable()]
		public string EventTrigger { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		public Reflection.Enum.eUnlockCondition UnlockMethod
		{
			get => this._unlock_method;
			set
			{
				if (System.Enum.IsDefined(typeof(Reflection.Enum.eUnlockCondition), value))
					this._unlock_method = value;
				else
					throw new Reflection.Exception.MappingFailException();
			}
		}

		[Reflection.Attributes.AccessModifiable()]
		public Reflection.Enum.eBoolean IsSUVRace
		{
			get => this._is_suv_race;
			set
			{
				if (System.Enum.IsDefined(typeof(Reflection.Enum.eBoolean), value))
					this._is_suv_race = value;
				else
					throw new System.ArgumentOutOfRangeException("Value passed is not of boolean type.");
			}
		}

		[Reflection.Attributes.AccessModifiable()]
		public Reflection.Enum.eEventBehaviorType EventBehaviorType
		{
			get => this._event_behavior;
			set
			{
				if (System.Enum.IsDefined(typeof(Reflection.Enum.eEventBehaviorType), value))
					this._event_behavior = value;
				else
					throw new Reflection.Exception.MappingFailException();
			}
		}
	}
}