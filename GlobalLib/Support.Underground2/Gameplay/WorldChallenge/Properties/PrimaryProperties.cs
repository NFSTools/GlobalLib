namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class WorldChallenge
	{
		private string _sms_label = Reflection.BaseArguments.NULL;
		private string _chal_parent = Reflection.BaseArguments.NULL;
		private string _world_trigger = Reflection.BaseArguments.NULL;
		private Reflection.Enum.eBoolean _use_outruns = Reflection.Enum.eBoolean.False;
		private Reflection.Enum.eWorldChallengeType _chal_type = Reflection.Enum.eWorldChallengeType.Showcase;

		[Reflection.Attributes.AccessModifiable()]
		public string WorldChallengeTrigger
		{
			get => this._world_trigger;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new System.ArgumentNullException("This value cannot be left empty.");
				this._world_trigger = value;
			}
		}

		[Reflection.Attributes.AccessModifiable()]
		public byte BelongsToStage { get; set; }

		public byte _padding0 { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		public Reflection.Enum.eBoolean UseOutrunsAsReqRaces
		{
			get => this._use_outruns;
			set
			{
				if (System.Enum.IsDefined(typeof(Reflection.Enum.eBoolean), value))
					this._use_outruns = value;
				else
					throw new System.ArgumentOutOfRangeException("Value passed is not of boolean type.");
			}
		}

		[Reflection.Attributes.AccessModifiable()]
		public byte RequiredRacesWon { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		public string ChallengeSMSLabel
		{
			get => this._sms_label;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new System.ArgumentNullException("This value cannot be left empty.");
				this._sms_label = value;
			}
		}

		[Reflection.Attributes.AccessModifiable()]
		public string ChallengeParent
		{
			get => this._chal_parent;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new System.ArgumentNullException("This value cannot be left empty.");
				this._chal_parent = value;
			}
		}

		[Reflection.Attributes.AccessModifiable()]
		public int TimeLimit { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		public Reflection.Enum.eWorldChallengeType WorldChallengeType
		{
			get => this._chal_type;
			set
			{
				if (!System.Enum.IsDefined(typeof(Reflection.Enum.eWorldChallengeType), value))
					throw new Reflection.Exception.MappingFailException();
				this._chal_type = value;
			}
		}

		[Reflection.Attributes.AccessModifiable()]
		public byte UnlockablePart1_Index { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		public byte UnlockablePart2_Index { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		public byte UnlockablePart3_Index { get; set; }
	}
}