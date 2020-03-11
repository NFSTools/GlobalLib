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

			var C = new GlobalLib.Support.Carbon.Class.PresetSkin();
			var MW = new GlobalLib.Support.MostWanted.Class.PresetRide();
			var UG2 = new GlobalLib.Support.Underground2.Class.CarTypeInfo();

			var strC = C.GetAccessibles();
			var strMW = MW.GetAccessibles();
			var strUG2 = UG2.GetAccessibles();

			string reference = null;
			bool done = db.PresetRides.Classes[0].SetValueOfInternalObject(ref reference, "Autosculpt", "SKIRT", "AutosculptZone3", "80");

			int aa = 0;
		}
	}
}
