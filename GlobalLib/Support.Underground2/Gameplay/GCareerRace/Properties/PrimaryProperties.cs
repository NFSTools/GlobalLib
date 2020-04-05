using GlobalLib.Reflection;
using GlobalLib.Reflection.Attributes;
using GlobalLib.Reflection.Enum;
using GlobalLib.Reflection.Exception;
using System;

namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class GCareerRace
	{
		private byte _num_of_opponents = 0;
		private byte _num_of_stages = 1;
		private string _player_car_type = BaseArguments.NULL;
		private eEventIconType _event_icon_type = eEventIconType.REGULAR;
		private eTrackDifficulty _difficulty_level = eTrackDifficulty.TRACK_DIFFICULTY_MEDIUM;
		private eBoolean _is_drive_to_gps = eBoolean.False;
		private eBoolean _is_hidden_event = eBoolean.False;

		[AccessModifiable()]
		[StaticModifiable()]
		public int EarnableRespect { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public string PlayerCarType
		{
			get => this._player_car_type;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("This value cannot be left empty.");
				this._player_car_type = value;
			}
		}

		[AccessModifiable()]
		[StaticModifiable()]
		public int CashValue { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public eEventIconType EventIconType
		{
			get => this._event_icon_type;
			set
			{
				if (Enum.IsDefined(typeof(eEventIconType), value))
					this._event_icon_type = value;
				else
					throw new MappingFailException();
			}
		}

		[AccessModifiable()]
		public eBoolean IsDriveToGPS
		{
			get => this._is_drive_to_gps;
			set
			{
				if (Enum.IsDefined(typeof(eBoolean), value))
					this._is_drive_to_gps = value;
				else
					throw new ArgumentOutOfRangeException("Value passed is not of boolean type.");
			}
		}

		[AccessModifiable()]
		[StaticModifiable()]
		public eTrackDifficulty DifficultyLevel
		{
			get => this._difficulty_level;
			set
			{
				if (Enum.IsDefined(typeof(eTrackDifficulty), value))
					this._difficulty_level = value;
				else
					throw new MappingFailException();
			}
		}

		[AccessModifiable()]
		[StaticModifiable()]
		public byte BelongsToStage { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public byte NumOpponents
		{
			get => this._num_of_opponents;
			set
			{
				if (value < 0 || value > 5)
					throw new ArgumentOutOfRangeException("Value passed should be in range 0-5.");
				this._num_of_opponents = value;
			}
		}

		[AccessModifiable()]
		[StaticModifiable()]
		public byte UnknownDragValue { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public byte NumStages
		{
			get => this._num_of_stages;
			set
			{
				if (value < 0 || value > 4)
					throw new ArgumentOutOfRangeException("Value passed should be in range 0-4.");
				this._num_of_stages = value;
			}
		}

		[AccessModifiable()]
		[StaticModifiable()]
		public eBoolean IsHiddenEvent
		{
			get => this._is_hidden_event;
			set
			{
				if (Enum.IsDefined(typeof(eBoolean), value))
					this._is_hidden_event = value;
				else
					throw new ArgumentOutOfRangeException("Value passed is not of boolean type.");
			}
		}

		private byte _padding0 = 0;
		private byte _padding1 = 0;
		private int _padding2 = 0;
		private int _padding3 = 0;
	}
}