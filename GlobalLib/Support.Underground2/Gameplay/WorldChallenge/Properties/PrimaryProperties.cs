using GlobalLib.Reflection;
using GlobalLib.Reflection.Attributes;
using GlobalLib.Reflection.Enum;
using GlobalLib.Reflection.Exception;
using System;

namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class WorldChallenge
	{
		private string _sms_label = BaseArguments.NULL;
		private string _chal_parent = BaseArguments.NULL;
		private string _world_trigger = BaseArguments.NULL;
		private eBoolean _use_outruns = eBoolean.False;
		private eWorldChallengeType _chal_type = eWorldChallengeType.Showcase;

		[AccessModifiable()]
		public string WorldChallengeTrigger
		{
			get => this._world_trigger;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("This value cannot be left empty.");
				this._world_trigger = value;
			}
		}

		[AccessModifiable()]
		[StaticModifiable()]
		public byte BelongsToStage { get; set; }

		public byte _padding0 { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public eBoolean UseOutrunsAsReqRaces
		{
			get => this._use_outruns;
			set
			{
				if (Enum.IsDefined(typeof(eBoolean), value))
					this._use_outruns = value;
				else
					throw new ArgumentOutOfRangeException("Value passed is not of boolean type.");
			}
		}

		[AccessModifiable()]
		[StaticModifiable()]
		public byte RequiredRacesWon { get; set; }

		[AccessModifiable()]
		public string ChallengeSMSLabel
		{
			get => this._sms_label;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("This value cannot be left empty.");
				this._sms_label = value;
			}
		}

		[AccessModifiable()]
		public string ChallengeParent
		{
			get => this._chal_parent;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("This value cannot be left empty.");
				this._chal_parent = value;
			}
		}

		[AccessModifiable()]
		[StaticModifiable()]
		public int TimeLimit { get; set; }

		[AccessModifiable()]
		public eWorldChallengeType WorldChallengeType
		{
			get => this._chal_type;
			set
			{
				if (!Enum.IsDefined(typeof(eWorldChallengeType), value))
					throw new MappingFailException();
				this._chal_type = value;
			}
		}

		[AccessModifiable()]
		public byte UnlockablePart1_Index { get; set; }

		[AccessModifiable()]
		public byte UnlockablePart2_Index { get; set; }

		[AccessModifiable()]
		public byte UnlockablePart3_Index { get; set; }
	}
}