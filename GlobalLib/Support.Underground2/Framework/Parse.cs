using GlobalLib.Utils;



namespace GlobalLib.Support.Underground2.Framework
{
	public static class Parse
	{
		public static string TrackCollectionName(string name)
		{
			if (string.IsNullOrWhiteSpace(name)) return null;
			var tokens = name.Split(new char[] { ' ', '\\', '/' }, System.StringSplitOptions.RemoveEmptyEntries);
			if (tokens.Length < 1) return null;
			return tokens[tokens.Length - 1];
		}

		public static string TrackDirectory(string region_name, string CName)
		{
			FormatX.GetInt32(region_name, "L{X}R#", out int area);
			return $"Location{area.ToString()}\\{CName}";
		}

		public static string RegionDirectory(string region_name)
		{
			FormatX.GetInt32(region_name, "L{X}R#", out int area);
			string loc = region_name.Substring(region_name.Length - 1, 1);
			return $"Location{area.ToString()}\\Region{loc.ToUpper()}";
		}
	}
}
