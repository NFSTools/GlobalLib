namespace GlobalLib.Database
{
	public partial class Carbon
	{
		public override string ToString()
		{
			string result = $"Database (Carbon) {System.Environment.NewLine}";
			result += $"Materials: {Materials.Length} {System.Environment.NewLine}";
			result += $"CarTypeInfos: {CarTypeInfos.Length} {System.Environment.NewLine}";
			result += $"PresetRides: {PresetRides.Length} {System.Environment.NewLine}";
			result += $"PresetSkins: {PresetSkins.Length} {System.Environment.NewLine}";
			result += $"FNGroups: {FNGroups.Count} {System.Environment.NewLine}";
			result += $"TPKBlocks: {TPKBlocks.Count} {System.Environment.NewLine}";
			return result;
		}
	}
}