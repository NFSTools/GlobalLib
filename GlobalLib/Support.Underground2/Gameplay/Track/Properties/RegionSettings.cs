using GlobalLib.Reflection;
using GlobalLib.Reflection.Attributes;
using GlobalLib.Reflection.Exception;
using GlobalLib.Support.Underground2.Framework;
using GlobalLib.Utils;
using System;

namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class Track
	{
		private string _race_descrition = BaseArguments.NULL;
		private string _track_directory;
		private string _region_name;
		private string _region_directory;
		private int _location_index;
		private string _location_directory;

		/// <summary>
		/// Represents debug description of the race.
		/// </summary>
		[AccessModifiable()]
		public string RaceDescription
		{
			get => this._race_descrition;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("This value cannot be left empty.");
				else if (value.Length > 0x1F)
					throw new ArgumentLengthException("This value should be less than 31 characters long.");
				this._race_descrition = value;
			}
		}

		/// <summary>
		/// Represents region in which the track and its values are stored.
		/// </summary>
		[AccessModifiable()]
		public string RegionName
		{
			get => this._region_name;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("This value cannot be left empty.");
				if (value.Length > 7)
					throw new ArgumentLengthException("Length of the value passed should not exceed 7 characters.");
				if (!Validate.TrackRegionName(value))
					throw new Exception("Value passed cannot be a recognizable game directory.");
				this._region_name = value;
				this._track_directory = Parse.TrackDirectory(value, this._collection_name);
				this._region_directory = Parse.RegionDirectory(value);
				FormatX.GetInt32(value, "L{X}R#", out this._location_index);
				this._location_directory = $"Location{this._location_index.ToString()}";
			}
		}
	}
}