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
			GlobalLib.Core.Process.Set = (int)GlobalLib.Core.GameINT.Underground2;
			GlobalLib.Core.Process.GlobalDir = @"E:\Need For Speed Underground 2\Need For Speed Underground 2";
			var db = new GlobalLib.Database.Underground2();
			GlobalLib.Core.Process.LoadData(db);
			watch.Stop();

			var elapsed_1 = watch.ElapsedMilliseconds;


			for (int a1 = 0; a1 < db.GCareerRaces.Length; ++a1)
			{
				if (db.GCareerRaces.Classes[a1].IsHiddenEvent == GlobalLib.Reflection.Enum.eBoolean.True)
					db.GCareerRaces.Classes[a1].IsHiddenEvent = GlobalLib.Reflection.Enum.eBoolean.False;
			}

			for (int a1 = 0; a1 < db.GCareerStages.Length; ++a1)
			{
				db.GCareerStages.Classes[a1].MaxCircuitsShownOnMap = 20;
				db.GCareerStages.Classes[a1].MaxDragsShownOnMap = 20;
				db.GCareerStages.Classes[a1].MaxStreetXShownOnMap = 20;
				db.GCareerStages.Classes[a1].MaxDriftsShownOnMap = 20;
				db.GCareerStages.Classes[a1].MaxSprintsShownOnMap = 20;
			}

			for (int a1 = 0; a1 < db.GCareerRaces.Length; ++a1)
			{
				if (db.GCareerRaces.Classes[a1].EventIconType == GlobalLib.Reflection.Enum.eEventIconType.URL &&
					db.GCareerRaces.Classes[a1].BelongsToStage == 4)
				{
					db.GCareerRaces.Classes[a1].NumStages = 1;
					db.GCareerRaces.Classes[a1].NumLaps_Stage1 = 1;
				}
			}



			using (var bw = new BinaryWriter(File.Open("UG2CAREER.BIN", FileMode.Create)))
			{
				GlobalLib.Support.Underground2.Framework.CareerManager.Assemble(bw, db);
			}






			int aa = 0;
		}
	}
}
