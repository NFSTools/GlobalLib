using System;



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
			string nl = Environment.NewLine;
			string equals = " = ";
			string collections = " collections.";
			string info = this.ToString() + nl;
			info += $"{this.AcidEffects.ThisName}{equals}{this.AcidEffects.Length}{collections}{nl}";
			info += $"{this.BankTriggers.ThisName}{equals}{this.BankTriggers.Length}{collections}{nl}";
			info += $"{this.CarTypeInfos.ThisName}{equals}{this.CarTypeInfos.Length}{collections}{nl}";
			info += $"{this.GCareerBrands.ThisName}{equals}{this.GCareerBrands.Length}{collections}{nl}";
			info += $"{this.GCareerRaces.ThisName}{equals}{this.GCareerRaces.Length}{collections}{nl}";
			info += $"{this.GCareerStages.ThisName}{equals}{this.GCareerStages.Length}{collections}{nl}";
			info += $"{this.GCarUnlocks.ThisName}{equals}{this.GCarUnlocks.Length}{collections}{nl}";
			info += $"{this.GShowcases.ThisName}{equals}{this.GShowcases.Length}{collections}{nl}";
			info += $"{this.Materials.ThisName}{equals}{this.Materials.Length}{collections}{nl}";
			info += $"{this.PartPerformances.ThisName}{equals}{this.PartPerformances.Length}{collections}{nl}";
			info += $"{this.PartUnlockables.ThisName}{equals}{this.PartUnlockables.Length}{collections}{nl}";
			info += $"{this.PerfSliderTunings.ThisName}{equals}{this.PerfSliderTunings.Length}{collections}{nl}";
			info += $"{this.PresetRides.ThisName}{equals}{this.PresetRides.Length}{collections}{nl}";
			info += $"{this.SMSMessages.ThisName}{equals}{this.SMSMessages.Length}{collections}{nl}";
			info += $"{this.Sponsors.ThisName}{equals}{this.Sponsors.Length}{collections}{nl}";
			info += $"{this.SunInfos.ThisName}{equals}{this.SunInfos.Length}{collections}{nl}";
			info += $"{this.Tracks.ThisName}{equals}{this.Tracks.Length}{collections}{nl}";
			info += $"{this.WorldChallenges.ThisName}{equals}{this.WorldChallenges.Length}{collections}{nl}";
			info += $"{this.WorldShops.ThisName}{equals}{this.WorldShops.Length}{collections}{nl}";
			return info;
		}
	}
}