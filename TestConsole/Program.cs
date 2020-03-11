using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
	class Program
	{
		static unsafe void Main(string[] args)
		{
			var watch = new System.Diagnostics.Stopwatch();

			watch.Start();
			GlobalLib.Core.Process.Set = (int)GlobalLib.Core.GameINT.Carbon;
			GlobalLib.Core.Process.GlobalDir = @"C:\Need for Speed Carbon";
			var db = new GlobalLib.Database.Carbon();
			GlobalLib.Core.Process.LoadData(db);
			watch.Stop();

			var elapsed_1 = watch.ElapsedMilliseconds;

			watch.Reset();

			watch.Start();
			GlobalLib.Core.Process.SaveData(db, false);
			watch.Stop();

			var elapsed_2 = watch.ElapsedMilliseconds;

			var mat = db.Materials.GetAccessibleProperties(db.Materials.Classes[0].CollectionName);
			var car = db.CarTypeInfos.GetAccessibleProperties(db.CarTypeInfos.Classes[0].CollectionName);
			var ride = db.PresetRides.GetAccessibleProperties(db.PresetRides.Classes[0].CollectionName);
			var skin = db.PresetSkins.GetAccessibleProperties(db.PresetSkins.Classes[0].CollectionName);

			db.PresetRides.Classes[0].SetValue("SpoilerType", "_CARRER");

			int aa = 0;
		}
	}
}
