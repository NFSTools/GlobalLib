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

		public static bool PartPerformanceCollectionName(string CName)
		{
			if (CName.Length != 10) return false;
			try
			{
				uint _ = System.Convert.ToUInt32(CName, 16);
				return true;
			}
			catch (System.Exception)
			{
				return false;
			}
		}

		public static bool PerfSliderCollectionName(string CName)
		{
			if (CName.Length != 10) return false;
			try
			{
				uint _ = System.Convert.ToUInt32(CName, 16);
				return true;
			}
			catch (System.Exception)
			{
				return false;
			}
		}

		public static bool PartUnlockableCollectionName(string CName)
		{
			if (CName.Length != 10) return false;
			if (!CName.StartsWith("CARPART_")) return false;
			string index = FormatX.GetString(CName, "CARPART_{X}");
			if (ConvertX.ToInt32(index) == 0) return false;
			else return true;
		}
	
		public static bool CareerStageCollectionName(string CName)
		{
			if (!CName.StartsWith("STAGE_")) return false;
			string index = FormatX.GetString(CName, "STAGE_{X}");
			return byte.TryParse(index, out byte _);
		}
	
		public static bool BankTriggerCollectionName(string CName)
		{
			if (CName.Length != 15) return false;
			if (!CName.StartsWith("BANK_TRIGGER_")) return false;
			string index = FormatX.GetString(CName, "BANK_TRIGGER_{X}");
			return byte.TryParse(index, out byte _);
		}
	}
}