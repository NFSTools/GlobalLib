namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class Track : Reflection.Interface.ICastable<Track>, Reflection.Interface.IGetValue,
		Reflection.Interface.ISetValue
	{
		/* 0x0020 - 0x0040 */ private string _track_directory;
		/* 0x0040 - 0x0048 */ private string _region_name;
		/* 0x0048 - 0x0068 */ private string _region_directory;
		/* 0x0068 - 0x006C */ private int _location_index;
		/* 0x006C - 0x007C */ private string _location_directory;

		/// <summary>
		/// Represents region in which the track and its values are stored.
		/// </summary>
		public string RegionName
		{
			get => this._region_name;
			set
			{
				if (value.Length > 7)
					throw new Reflection.Exception.ArgumentLengthException("Length of the value passed should not exceed 7 characters.");
				if (!System.IO.Directory.Exists($"{Core.Process.GlobalDir}\\TRACKS\\{value}"))
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