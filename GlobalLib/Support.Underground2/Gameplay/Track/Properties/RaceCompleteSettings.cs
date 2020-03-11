namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class Track
	{
		/// <summary>
		/// Unique ID value of the track that is used ingame.
		/// </summary>
		public ushort TrackID { get; private set; }

		/// <summary>
		/// Total length of the whole track
		/// </summary>
		[Reflection.Attributes.AccessModifiable()]
		public uint RaceLength { get; set; }

		/// <summary>
		/// Indicates maximum time allowed to complete the race in forward direction.
		/// </summary>
		[Reflection.Attributes.AccessModifiable()]
		public float TimeLimitToBeatForward { get; set; }

		/// <summary>
		/// Indicates maximum time allowed to complete the race in reverse direction.
		/// </summary>
		[Reflection.Attributes.AccessModifiable()]
		public float TimeLimitToBeatReverse { get; set; }

		/// <summary>
		/// Indicates score needed to beat the drift race in forward direction.
		/// </summary>
		[Reflection.Attributes.AccessModifiable()]
		public int ScoreToBeatDriftForward { get; set; }

		/// <summary>
		/// Indicates score needed to beat the drift race in reverse direction.
		/// </summary>
		[Reflection.Attributes.AccessModifiable()]
		public int ScoreToBeatDriftReverse { get; set; }

		/// <summary>
		/// Indicates number of seconds that should pass before opponents can take first shortcut.
		/// </summary>
		[Reflection.Attributes.AccessModifiable()]
		public short NumSecBeforeShorcutsAllowed { get; set; }

		/// <summary>
		/// Indicates minimum amount of seconds to drift.
		/// </summary>
		[Reflection.Attributes.AccessModifiable()]
		public short DriftSecondsMin { get; set; }

		/// <summary>
		/// Indicates maximum amount of seconds to drift.
		/// </summary>
		[Reflection.Attributes.AccessModifiable()]
		public short DriftSecondsMax { get; set; }

		/// <summary>
		/// Indicates configuration settings of the car at the start.
		/// </summary>
		[Reflection.Attributes.AccessModifiable()]
		public short CarRaceStartConfig { get; set; }
	}
}