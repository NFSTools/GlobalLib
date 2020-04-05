using GlobalLib.Reflection;
using GlobalLib.Reflection.Attributes;
using GlobalLib.Reflection.Enum;
using System;

namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class GCareerRace
	{
		private string _intro_movie = BaseArguments.NULL;
		private string _outro_movie = BaseArguments.NULL;
		private string _gps_destination = BaseArguments.NULL;

		[AccessModifiable()]
		public string IntroMovie
		{
			get => this._intro_movie;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("This value cannot be left empty.");
				this._intro_movie = value;
			}
		}

		[AccessModifiable()]
		public string OutroMovie
		{
			get => this._outro_movie;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("This value cannot be left empty.");
				this._outro_movie = value;
			}
		}

		[AccessModifiable()]
		public byte NumMapItems { get; set; }

		[AccessModifiable()]
		public byte Unknown0x3A { get; set; }

		[AccessModifiable()]
		public byte Unknown0x3B { get; set; }

		[AccessModifiable()]
		public string GPSDestination
		{
			get => this._gps_destination;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("This value cannot be left empty.");
				this._gps_destination = value;
			}
		}

		private eDriftType DriftTypeIfDriftRace
		{
			get
			{
				if (this.EventBehaviorType != eEventBehaviorType.Drift)
					return eDriftType.VS_AI;

				var track1 = this.Database.Tracks.FindCollection($"Track_{this.TrackID_Stage1}");
				var track2 = this.Database.Tracks.FindCollection($"Track_{this.TrackID_Stage2}");
				var track3 = this.Database.Tracks.FindCollection($"Track_{this.TrackID_Stage3}");
				var track4 = this.Database.Tracks.FindCollection($"Track_{this.TrackID_Stage4}");

				var drift1 = (track1 != null) ? track1.DriftType : eDriftType.VS_AI;
				var drift2 = (track2 != null) ? track2.DriftType : eDriftType.VS_AI;
				var drift3 = (track3 != null) ? track3.DriftType : eDriftType.VS_AI;
				var drift4 = (track4 != null) ? track4.DriftType : eDriftType.VS_AI;

				if (drift1 == eDriftType.DOWNHILL ||
					drift2 == eDriftType.DOWNHILL ||
					drift3 == eDriftType.DOWNHILL ||
					drift4 == eDriftType.DOWNHILL)
					return eDriftType.DOWNHILL;
				else
					return eDriftType.VS_AI;
			}
		}
	}
}