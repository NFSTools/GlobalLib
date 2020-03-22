namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class Track
	{
		private string _race_descrition;
		private string _track_directory;
		private string _region_name;
		private string _region_directory;
		private int _location_index;
		private string _location_directory;

		/// <summary>
		/// Represents debug description of the race.
		/// </summary>
		[Reflection.Attributes.AccessModifiable()]
		public string RaceDescription
		{
			get => this._race_descrition;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new System.ArgumentNullException("This value cannot be left empty.");
				else if (value.Length > 0x1F)
					throw new Reflection.Exception.ArgumentLengthException("This value should be less than 31 characters long.");
				this._race_descrition = value;
			}
		}

		/// <summary>
		/// Represents region in which the track and its values are stored.
		/// </summary>
		[Reflection.Attributes.AccessModifiable()]
		public string RegionName
		{
			get => this._region_name;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new System.ArgumentNullException("This value cannot be left empty.");
				if (value.Length > 7)
					throw new Reflection.Exception.ArgumentLengthException("Length of the value passed should not exceed 7 characters.");
				if (!System.IO.Directory.Exists($"{Core.Process.GlobalDir}\\TRACKS\\ROUTES{value}"))
					throw new System.IO.DirectoryNotFoundException($"Directory named {value} does not exist.");
				if (!Framework.Validate.TrackRegionName(value))
					throw new System.Exception("Value passed cannot be a recognizable game directory.");
				this._region_name = value;
				this._track_directory = Framework.Parse.TrackDirectory(value, this._collection_name);
				this._region_directory = Framework.Parse.RegionDirectory(value);
				Utils.FormatX.GetInt32(value, "L{X}R#", out this._location_index);
				this._location_directory = $"Location{this._location_index.ToString()}";
			}
		}
	}
}