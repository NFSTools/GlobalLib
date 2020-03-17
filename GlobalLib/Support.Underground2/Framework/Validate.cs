using GlobalLib.Utils;



namespace GlobalLib.Support.Underground2.Framework
{
	public static class Validate
	{
		public static bool TrackRegionName(string region_name)
		{
			// Allowed format: L#R&, where # = int number, & = ascii char
			if (!region_name.StartsWith("L")) return false;
			if (region_name.Substring(region_name.Length - 2, 1) != "R") return false;
			if ((byte)region_name[region_name.Length - 1] > sbyte.MaxValue) return false;
			if (!FormatX.GetInt32(region_name, "L{X}R#", out int result)) return false;
			return true;
		}

		public static bool TrackCollectionName(string CName)
		{
			// Allowed format: Track_#, where # is ushort
			if (!CName.StartsWith("Track_")) return false;
			if (!FormatX.GetInt32(CName, "Track_{X}", out int result)) return false;
			return result <= ushort.MaxValue;
		}

		public static bool PartUnlockableCollectionName(string CName)
		{
			if (CName.Length != 10) return false;
			if (!CName.StartsWith("CarPart_")) return false;
			string index = FormatX.GetString(CName, "CarPart_{X}");
			if (ConvertX.ToInt32(index) == 0) return false;
			else return true;
		}
	}
}