namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class GCareerRace
	{
		private string _intro_movie = Reflection.BaseArguments.NULL;
		private string _outro_movie = Reflection.BaseArguments.NULL;
		private string _gps_destination = Reflection.BaseArguments.NULL;

		[Reflection.Attributes.AccessModifiable()]
		public string IntroMovie
		{
			get => this._intro_movie;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new System.ArgumentNullException("This value cannot be left empty.");
				this._intro_movie = value;
			}
		}

		[Reflection.Attributes.AccessModifiable()]
		public string OutroMovie
		{
			get => this._outro_movie;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new System.ArgumentNullException("This value cannot be left empty.");
				this._outro_movie = value;
			}
		}

		[Reflection.Attributes.AccessModifiable()]
		public byte NumMapItems { get; set; }

		public byte Unknown0x3A { get; set; }
		public byte Unknown0x3B { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		public string GPSDestination
		{
			get => this._gps_destination;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new System.ArgumentNullException("This value cannot be left empty.");
				this._gps_destination = value;
			}
		}

		private Reflection.Enum.eDriftType DriftTypeIfDriftRace
		{
			get
			{
				if (this.EventBehaviorType != Reflection.Enum.eEventBehaviorType.Drift)
					return Reflection.Enum.eDriftType.VS_AI;

				var track1 = this.Database.Tracks.FindCollection($"Track_{this.TrackID_Stage1}");
				var track2 = this.Database.Tracks.FindCollection($"Track_{this.TrackID_Stage2}");
				var track3 = this.Database.Tracks.FindCollection($"Track_{this.TrackID_Stage3}");
				var track4 = this.Database.Tracks.FindCollection($"Track_{this.TrackID_Stage4}");

				var drift1 = (track1 != null) ? track1.DriftType : Reflection.Enum.eDriftType.VS_AI;
				var drift2 = (track2 != null) ? track2.DriftType : Reflection.Enum.eDriftType.VS_AI;
				var drift3 = (track3 != null) ? track3.DriftType : Reflection.Enum.eDriftType.VS_AI;
				var drift4 = (track4 != null) ? track4.DriftType : Reflection.Enum.eDriftType.VS_AI;

				if (drift1 == Reflection.Enum.eDriftType.DOWNHILL ||
					drift2 == Reflection.Enum.eDriftType.DOWNHILL ||
					drift3 == Reflection.Enum.eDriftType.DOWNHILL ||
					drift4 == Reflection.Enum.eDriftType.DOWNHILL)
					return Reflection.Enum.eDriftType.DOWNHILL;
				else
					return Reflection.Enum.eDriftType.VS_AI;
			}
		}
	}
}