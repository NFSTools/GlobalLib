using System;



namespace GlobalLib.Database
{
	public partial class Underground1
	{
		public override string ToString()
		{
			return "Database (Underground1)";
		}

		/// <summary>
		/// Gets information about <see cref="Underground2"/> database.
		/// </summary>
		/// <returns></returns>
		public override string GetDatabaseInfo()
		{
			string nl = Environment.NewLine;
			string info = this.ToString() + nl;
			//info += $"{this.CarTypeInfos.ThisName} = {this.CarTypeInfos.Length} collections.{nl}";
			info += $"{this.Materials.ThisName} = {this.Materials.Length} collections.{nl}";
			//info += $"{this.PresetRides.ThisName} = {this.PresetRides.Length} collections.{nl}";
			info += $"{this.SunInfos.ThisName} = {this.SunInfos.Length} collections.{nl}";
			//info += $"{this.Tracks.ThisName} = {this.Tracks.Length} collections.{nl}";
			return info;
		}
	}
}