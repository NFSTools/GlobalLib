using System;



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
			string nl = Environment.NewLine;
			string equals = " = ";
			string collections = " collections.";
			string info = this.ToString() + nl;
			info += $"{this.CarTypeInfos.ThisName}{equals}{this.CarTypeInfos.Length}{collections}{nl}";
			info += $"{this.Materials.ThisName}{equals}{this.Materials.Length}{collections}{nl}";
			info += $"{this.PresetRides.ThisName}{equals}{this.PresetRides.Length}{collections}{nl}";
			return info;
		}
	}
}