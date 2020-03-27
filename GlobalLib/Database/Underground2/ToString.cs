namespace GlobalLib.Database
{
	public partial class Underground2
	{
		public override string ToString()
		{
			return "Database (Underground2)";
		}

		/// <summary>
		/// Gets information about <see cref="Underground2"/> database.
		/// </summary>
		/// <returns></returns>
		public override string GetDatabaseInfo()
		{
			string nl = System.Environment.NewLine;
			string info = this.ToString() + nl;
			info += $"{this.BankTriggers.ThisName} = {this.BankTriggers.Length} collections.{nl}";
			info += $"{this.CarTypeInfos.ThisName} = {this.CarTypeInfos.Length} collections.{nl}";
			info += $"{this.GCareerBrands.ThisName} = {this.GCareerBrands.Length} collections.{nl}";
			info += $"{this.GCareerRaces.ThisName} = {this.GCareerRaces.Length} collections.{nl}";
			info += $"{this.GCareerStages.ThisName} = {this.GCareerStages.Length} collections.{nl}";
			info += $"{this.GCarUnlocks.ThisName} = {this.GCarUnlocks.Length} collections.{nl}";
			info += $"{this.GShowcases.ThisName} = {this.GShowcases.Length} collections.{nl}";
			info += $"{this.Materials.ThisName} = {this.Materials.Length} collections.{nl}";
			info += $"{this.PartPerformances.ThisName} = {this.PartPerformances.Length} collections.{nl}";
			info += $"{this.PartUnlockables.ThisName} = {this.PartUnlockables.Length} collections.{nl}";
			info += $"{this.PerfSliderTunings.ThisName} = {this.PerfSliderTunings.Length} collections.{nl}";
			info += $"{this.PresetRides.ThisName} = {this.PresetRides.Length} collections.{nl}";
			info += $"{this.SMSMessages.ThisName} = {this.SMSMessages.Length} collections.{nl}";
			info += $"{this.Sponsors.ThisName} = {this.Sponsors.Length} collections.{nl}";
			info += $"{this.SunInfos.ThisName} = {this.SunInfos.Length} collections.{nl}";
			info += $"{this.Tracks.ThisName} = {this.Tracks.Length} collections.{nl}";
			info += $"{this.WorldChallenges.ThisName} = {this.WorldChallenges.Length} collections.{nl}";
			info += $"{this.WorldShops.ThisName} = {this.WorldShops.Length} collections.{nl}";
			return info;
		}
	}
}