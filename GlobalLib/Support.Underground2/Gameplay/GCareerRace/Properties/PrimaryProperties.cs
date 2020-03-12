namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class GCareerRace
	{
		private string _player_car_type = Reflection.BaseArguments.NULL;
		private Reflection.Enum.eEventIconType _event_icon_type = Reflection.Enum.eEventIconType.REGULAR;
		private Reflection.Enum.eTrackDifficulty _difficulty_level = Reflection.Enum.eTrackDifficulty.TRACK_DIFFICULTY_MEDIUM;
		private Reflection.Enum.eBoolean _is_drive_to_gps = Reflection.Enum.eBoolean.False;
		private Reflection.Enum.eBoolean _is_hidden_event = Reflection.Enum.eBoolean.False;

		[Reflection.Attributes.AccessModifiable()]
		public int EarnableRespect { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		public string PlayerCarType
		{
			get => this._player_car_type;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new System.ArgumentNullException("This value cannot be left empty.");
				this._player_car_type = value;
			}
		}

		[Reflection.Attributes.AccessModifiable()]
		public int CashValue { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		public Reflection.Enum.eEventIconType EventIconType
		{
			get => this._event_icon_type;
			set
			{
				if (System.Enum.IsDefined(typeof(Reflection.Enum.eEventIconType), value))
					this._event_icon_type = value;
				else
					throw new Reflection.Exception.MappingFailException();
			}
		}

		[Reflection.Attributes.AccessModifiable()]
		public Reflection.Enum.eBoolean IsDriveToGPS
		{
			get => this._is_drive_to_gps;
			set
			{
				if (System.Enum.IsDefined(typeof(Reflection.Enum.eBoolean), value))
					this._is_drive_to_gps = value;
				else
					throw new System.ArgumentOutOfRangeException("Value passed is not of boolean type.");
			}
		}

		[Reflection.Attributes.AccessModifiable()]
		public Reflection.Enum.eTrackDifficulty DifficultyLevel
		{
			get => this._difficulty_level;
			set
			{
				if (System.Enum.IsDefined(typeof(Reflection.Enum.eTrackDifficulty), value))
					this._difficulty_level = value;
				else
					throw new Reflection.Exception.MappingFailException();
			}
		}

		[Reflection.Attributes.AccessModifiable()]
		public byte BelongsToStage { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		public byte NumOpponents { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		public byte UnknownDragValue { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		public byte NumStages { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		public Reflection.Enum.eBoolean IsHiddenEvent
		{
			get => this._is_hidden_event;
			set
			{
				if (System.Enum.IsDefined(typeof(Reflection.Enum.eBoolean), value))
					this._is_hidden_event = value;
				else
					throw new System.ArgumentOutOfRangeException("Value passed is not of boolean type.");
			}
		}

		private byte _padding0 = 0;
		private byte _padding1 = 0;
		private int _padding2 = 0;
		private int _padding3 = 0;
	}
}