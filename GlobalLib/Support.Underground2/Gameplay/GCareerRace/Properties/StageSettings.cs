namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class GCareerRace
	{
		private Reflection.Enum.eBoolean _in_reverse_stage1 = Reflection.Enum.eBoolean.False;
		private Reflection.Enum.eBoolean _in_reverse_stage2 = Reflection.Enum.eBoolean.False;
		private Reflection.Enum.eBoolean _in_reverse_stage3 = Reflection.Enum.eBoolean.False;
		private Reflection.Enum.eBoolean _in_reverse_stage4 = Reflection.Enum.eBoolean.False;

		[Reflection.Attributes.AccessModifiable()]
		public ushort TrackID_Stage1 { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		public ushort TrackID_Stage2 { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		public ushort TrackID_Stage3 { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		public ushort TrackID_Stage4 { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		public byte NumLaps_Stage1 { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		public byte NumLaps_Stage2 { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		public byte NumLaps_Stage3 { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		public byte NumLaps_Stage4 { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		public Reflection.Enum.eBoolean InReverseDirection_Stage1
		{
			get => this._in_reverse_stage1;
			set
			{
				if (System.Enum.IsDefined(typeof(Reflection.Enum.eBoolean), value))
					this._in_reverse_stage1 = value;
				else
					throw new System.ArgumentOutOfRangeException("Value passed is not of boolean type.");
			}
		}

		[Reflection.Attributes.AccessModifiable()]
		public Reflection.Enum.eBoolean InReverseDirection_Stage2
		{
			get => this._in_reverse_stage2;
			set
			{
				if (System.Enum.IsDefined(typeof(Reflection.Enum.eBoolean), value))
					this._in_reverse_stage2 = value;
				else
					throw new System.ArgumentOutOfRangeException("Value passed is not of boolean type.");
			}
		}

		[Reflection.Attributes.AccessModifiable()]
		public Reflection.Enum.eBoolean InReverseDirection_Stage3
		{
			get => this._in_reverse_stage3;
			set
			{
				if (System.Enum.IsDefined(typeof(Reflection.Enum.eBoolean), value))
					this._in_reverse_stage3 = value;
				else
					throw new System.ArgumentOutOfRangeException("Value passed is not of boolean type.");
			}
		}

		[Reflection.Attributes.AccessModifiable()]
		public Reflection.Enum.eBoolean InReverseDirection_Stage4
		{
			get => this._in_reverse_stage4;
			set
			{
				if (System.Enum.IsDefined(typeof(Reflection.Enum.eBoolean), value))
					this._in_reverse_stage4 = value;
				else
					throw new System.ArgumentOutOfRangeException("Value passed is not of boolean type.");
			}
		}
	}
}