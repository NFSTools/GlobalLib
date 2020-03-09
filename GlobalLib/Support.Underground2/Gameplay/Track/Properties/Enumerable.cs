﻿namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class Track : Reflection.Interface.ICastable<Track>, Reflection.Interface.IGetValue,
		Reflection.Interface.ISetValue
	{
		/* 0x007C */ private eLocationType _location_type = eLocationType.CITY_CORE;
		/* 0x0080 */ private eDriftType _drift_type = eDriftType.VS_AI;
		/* 0x0094 */ private eRaceGameplayMode _race_gameplay_mode = eRaceGameplayMode.SPRINT;
		/* 0x00C4 */ private eTrackDifficulty _difficulty_forward = eTrackDifficulty.TRACK_DIFFICULTY_MEDIUM;
		/* 0x00C8 */ private eTrackDifficulty _difficulty_reverse = eTrackDifficulty.TRACK_DIFFICULTY_MEDIUM;

		/// <summary>
		/// Location type of the track.
		/// </summary>
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