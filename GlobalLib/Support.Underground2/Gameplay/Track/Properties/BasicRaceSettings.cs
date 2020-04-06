using GlobalLib.Reflection.Attributes;
using GlobalLib.Reflection.Enum;
using System;

namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class Track
	{
		private eBoolean _is_valid_race = eBoolean.True;
		private eBoolean _is_looping_race = eBoolean.False;
		private eBoolean _reverse_version_exists = eBoolean.True;
		private eBoolean _is_performance_tuning = eBoolean.False;

		/// <summary>
		/// Indicates whether race is valid.
		/// </summary>
		[AccessModifiable()]
		[StaticModifiable()]
		public eBoolean IsValidRace
		{
			get => this._is_valid_race;
			set
			{
				if (Enum.IsDefined(typeof(eBoolean), value))
					this._is_valid_race = value;
				else
					throw new ArgumentOutOfRangeException("Value passed is not of boolean type.");
			}
		}

		/// <summary>
		/// Indicates whether race is looping.
		/// </summary>
		[AccessModifiable()]
		[StaticModifiable()]
		public eBoolean IsLoopingRace
		{
			get => this._is_looping_race;
			set
			{
				if (Enum.IsDefined(typeof(eBoolean), value))
					this._is_looping_race = value;
				else
					throw new ArgumentOutOfRangeException("Value passed is not of boolean type.");
			}
		}

		/// <summary>
		/// Indicates whether reverse version of the race exists.
		/// </summary>
		[AccessModifiable()]
		[StaticModifiable()]
		public eBoolean ReverseVersionExists
		{
			get => this._reverse_version_exists;
			set
			{
				if (Enum.IsDefined(typeof(eBoolean), value))
					this._reverse_version_exists = value;
				else
					throw new ArgumentOutOfRangeException("Value passed is not of boolean type.");
			}
		}

		/// <summary>
		/// Indicates whether the race is used in performance tuning events.
		/// </summary>
		[AccessModifiable()]
		[StaticModifiable()]
		public eBoolean IsPerformanceTuning
		{
			get => this._is_performance_tuning;
			set
			{
				if (Enum.IsDefined(typeof(eBoolean), value))
					this._is_performance_tuning = value;
				else
					throw new ArgumentOutOfRangeException("Value passed is not of boolean type.");
			}
		}
	}
}