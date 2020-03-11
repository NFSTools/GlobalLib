namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class Track
	{
		private Reflection.Enum.eBoolean _is_valid_race = Reflection.Enum.eBoolean.True;
		private Reflection.Enum.eBoolean _is_looping_race = Reflection.Enum.eBoolean.False;
		private Reflection.Enum.eBoolean _reverse_version_exists = Reflection.Enum.eBoolean.True;
		private Reflection.Enum.eBoolean _is_performance_tuning = Reflection.Enum.eBoolean.False;

		/// <summary>
		/// Indicates whether race is valid.
		/// </summary>
		[Reflection.Attributes.AccessModifiable()]
		public Reflection.Enum.eBoolean IsValidRace
		{
			get => this._is_valid_race;
			set
			{
				if (System.Enum.IsDefined(typeof(Reflection.Enum.eBoolean), value))
					this._is_valid_race = value;
				else
					throw new System.ArgumentOutOfRangeException("Value passed is not of boolean type.");
			}
		}

		/// <summary>
		/// Indicates whether race is looping.
		/// </summary>
		[Reflection.Attributes.AccessModifiable()]
		public Reflection.Enum.eBoolean IsLoopingRace
		{
			get => this._is_looping_race;
			set
			{
				if (System.Enum.IsDefined(typeof(Reflection.Enum.eBoolean), value))
					this._is_looping_race = value;
				else
					throw new System.ArgumentOutOfRangeException("Value passed is not of boolean type.");
			}
		}

		/// <summary>
		/// Indicates whether reverse version of the race exists.
		/// </summary>
		[Reflection.Attributes.AccessModifiable()]
		public Reflection.Enum.eBoolean ReverseVersionExists
		{
			get => this._reverse_version_exists;
			set
			{
				if (System.Enum.IsDefined(typeof(Reflection.Enum.eBoolean), value))
					this._reverse_version_exists = value;
				else
					throw new System.ArgumentOutOfRangeException("Value passed is not of boolean type.");
			}
		}

		/// <summary>
		/// Indicates whether the race is used in performance tuning events.
		/// </summary>
		[Reflection.Attributes.AccessModifiable()]
		public Reflection.Enum.eBoolean IsPerformanceTuning
		{
			get => this._is_performance_tuning;
			set
			{
				if (System.Enum.IsDefined(typeof(Reflection.Enum.eBoolean), value))
					this._is_performance_tuning = value;
				else
					throw new System.ArgumentOutOfRangeException("Value passed is not of boolean type.");
			}
		}
	}
}