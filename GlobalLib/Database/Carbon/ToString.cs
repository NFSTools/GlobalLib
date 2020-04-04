using System;



namespace GlobalLib.Database
{
	public partial class Carbon
	{
		public override string ToString()
		{
			return "Database (Carbon)";
		}

		/// <summary>
		/// Gets information about <see cref="Carbon"/> database.
		/// </summary>
		/// <returns></returns>
		public override string GetDatabaseInfo()
		{
			string nl = Environment.NewLine;
			string info = this.ToString() + nl;
			info += $"{this.CarTypeInfos.ThisName} = {this.CarTypeInfos.Length} collections.{nl}";
			info += $"{this.Materials.ThisName} = {this.Materials.Length} collections.{nl}";
			info += $"{this.PresetRides.ThisName} = {this.PresetRides.Length} collections.{nl}";
			info += $"{this.PresetSkins.ThisName} = {this.PresetSkins.Length} collections.{nl}";
			return info;
		}
	}
}