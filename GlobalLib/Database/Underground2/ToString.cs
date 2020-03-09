namespace GlobalLib.Database
{
	public partial class Underground2 : Reflection.Interface.IGetIndex//, Reflection.Interface.IOperative
	{
		public override string ToString()
		{
			string result = $"Database (Underground2) {System.Environment.NewLine}";
			//result += $"Materials: {Materials.Count} {System.Environment.NewLine}";
			//result += $"CarTypeInfos: {CarTypeInfos.Count} {System.Environment.NewLine}";
			//result += $"PresetRides: {PresetRides.Count} {System.Environment.NewLine}";
			result += $"FNGroups: {FNGroups.Count} {System.Environment.NewLine}";
			result += $"TPKBlocks: {TPKBlocks.Count} {System.Environment.NewLine}";
			return result;
		}
	}
}