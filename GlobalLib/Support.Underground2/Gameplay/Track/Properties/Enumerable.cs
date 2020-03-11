using GlobalLib.Reflection.Enum;



namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class Track
	{
		private eLocationType _location_type = eLocationType.CITY_CORE;
		private eDriftType _drift_type = eDriftType.VS_AI;
		private eRaceGameplayMode _race_gameplay_mode = eRaceGameplayMode.SPRINT;
		private eTrackDifficulty _difficulty_forward = eTrackDifficulty.TRACK_DIFFICULTY_MEDIUM;
		private eTrackDifficulty _difficulty_reverse = eTrackDifficulty.TRACK_DIFFICULTY_MEDIUM;

		/// <summary>
		/// Location type of the track.
		/// </summary>
		[Reflection.Attributes.AccessModifiable()]
		public eLocationType LocationType
		{
			get => this._location_type;
			set
			{
				if (!System.Enum.IsDefined(typeof(eLocationType), value))
					throw new Reflection.Exception.MappingFailException();
				this._location_type = value;
			}
		}

		/// <summary>
		/// Drift type of the track.
		/// </summary>
		[Reflection.Attributes.AccessModifiable()]
		public eDriftType DriftType
		{
			get => this._drift_type;
			set
			{
				if (!System.Enum.IsDefined(typeof(eDriftType), value))
					throw new Reflection.Exception.MappingFailException();
				this._drift_type = value;
			}
		}

		/// <summary>
		/// Represents the race gameplay mode of the track.
		/// </summary>
		[Reflection.Attributes.AccessModifiable()]
		public eRaceGameplayMode RaceGameplayMode
		{
			get => this._race_gameplay_mode;
			set
			{
				if (!System.Enum.IsDefined(typeof(eRaceGameplayMode), value))
					throw new Reflection.Exception.MappingFailException();
				this._race_gameplay_mode = value;
			}
		}

		/// <summary>
		/// Difficulty of the track when it has a forward direction.
		/// </summary>
		[Reflection.Attributes.AccessModifiable()]
		public eTrackDifficulty DifficultyForward
		{
			get => this._difficulty_forward;
			set
			{
				if (!System.Enum.IsDefined(typeof(eTrackDifficulty), value))
					throw new Reflection.Exception.MappingFailException();
				this._difficulty_forward = value;
			}
		}

		/// <summary>
		/// Difficulty of the track when it has a reverse direction.
		/// </summary>
		[Reflection.Attributes.AccessModifiable()]
		public eTrackDifficulty DifficultyReverse
		{
			get => this._difficulty_reverse;
			set
			{
				if (!System.Enum.IsDefined(typeof(eTrackDifficulty), value))
					throw new Reflection.Exception.MappingFailException();
				this._difficulty_reverse = value;
			}
		}
	}
}