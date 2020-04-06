using GlobalLib.Reflection.Attributes;
using GlobalLib.Reflection.Enum;
using System;

namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class GCareerRace
	{
		private eBoolean _in_reverse_stage1 = eBoolean.False;
		private eBoolean _in_reverse_stage2 = eBoolean.False;
		private eBoolean _in_reverse_stage3 = eBoolean.False;
		private eBoolean _in_reverse_stage4 = eBoolean.False;

		[AccessModifiable()]
		[StaticModifiable()]
		public ushort TrackID_Stage1 { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public ushort TrackID_Stage2 { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public ushort TrackID_Stage3 { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public ushort TrackID_Stage4 { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public byte NumLaps_Stage1 { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public byte NumLaps_Stage2 { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public byte NumLaps_Stage3 { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public byte NumLaps_Stage4 { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public eBoolean InReverseDirection_Stage1
		{
			get => this._in_reverse_stage1;
			set
			{
				if (Enum.IsDefined(typeof(eBoolean), value))
					this._in_reverse_stage1 = value;
				else
					throw new ArgumentOutOfRangeException("Value passed is not of boolean type.");
			}
		}

		[AccessModifiable()]
		[StaticModifiable()]
		public eBoolean InReverseDirection_Stage2
		{
			get => this._in_reverse_stage2;
			set
			{
				if (Enum.IsDefined(typeof(eBoolean), value))
					this._in_reverse_stage2 = value;
				else
					throw new ArgumentOutOfRangeException("Value passed is not of boolean type.");
			}
		}

		[AccessModifiable()]
		[StaticModifiable()]
		public eBoolean InReverseDirection_Stage3
		{
			get => this._in_reverse_stage3;
			set
			{
				if (Enum.IsDefined(typeof(eBoolean), value))
					this._in_reverse_stage3 = value;
				else
					throw new ArgumentOutOfRangeException("Value passed is not of boolean type.");
			}
		}

		[AccessModifiable()]
		[StaticModifiable()]
		public eBoolean InReverseDirection_Stage4
		{
			get => this._in_reverse_stage4;
			set
			{
				if (Enum.IsDefined(typeof(eBoolean), value))
					this._in_reverse_stage4 = value;
				else
					throw new ArgumentOutOfRangeException("Value passed is not of boolean type.");
			}
		}
	}
}