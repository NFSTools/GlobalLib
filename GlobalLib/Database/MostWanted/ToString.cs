namespace GlobalLib.Database
{
	public partial class MostWanted
	{
		public override string ToString()
		{
			return "Database (MostWanted)";
		}

		/// <summary>
		/// Gets information about <see cref="MostWanted"/> database.
		/// </summary>
		/// <returns></returns>
		public override string GetDatabaseInfo()
		{
			string nl = System.Environment.NewLine;
			string info = this.ToString() + nl;
			info += $"{this.CarTypeInfos.ThisName} = {this.CarTypeInfos.Length} collections.{nl}";
			info += $"{this.Materials.ThisName} = {this.Materials.Length} collections.{nl}";
			info += $"{this.PresetRides.ThisName} = {this.PresetRides.Length} collections.{nl}";
			return info;
		}
	}
}