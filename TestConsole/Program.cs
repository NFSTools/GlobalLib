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
			GlobalLib.Core.Process.GlobalDir = @"C:\Need For Speed Underground 2\Need For Speed Underground 2";
			var db = new GlobalLib.Database.Underground2();
			GlobalLib.Core.Process.LoadData(db);
			watch.Stop();

			var elapsed = watch.ElapsedMilliseconds;

			var cla = db.CarTypeInfos.FindClass("SUPRA");

			var str = cla.GetAccessibles();
			var oof = cla.GetValue(str[12]);
			cla.SetValue(str[12], 3);
			cla.SetValue("IsSUV", "True");

			int aa = 0;
		}
	}
}
