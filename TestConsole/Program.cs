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

			Console.WriteLine("");
			Console.WriteLine($"Loading: {elapsed_1}ms");
			Console.WriteLine("");





			watch.Reset();
			watch.Start();
			GlobalLib.Core.Process.SaveData(db, false);
			watch.Stop();

			var elapsed_2 = watch.ElapsedMilliseconds;


			Console.WriteLine($"Saving: {elapsed_2}ms");






			int aaa = 0; // for debug speed test

			Console.Read(); // for release speed test
		}
	}
}
