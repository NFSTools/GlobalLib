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
			GlobalLib.Core.Process.Set = (int)GlobalLib.Core.GameINT.MostWanted;
			GlobalLib.Core.Process.GlobalDir = @"E:\Need for Speed Most Wanted";
			var db = new GlobalLib.Database.MostWanted();
			GlobalLib.Core.Process.LoadData(db);
			watch.Stop();

			var elapsed = watch.ElapsedMilliseconds;

			var tex = db.TPKBlocks[1].Textures[16].MemoryCast("TEXTURE");
			var car = db.CarTypeInfos.Classes[15].MemoryCast("M3GTR");
			var mat = db.Materials.Classes[7].MemoryCast("USELESS");

			var texstr = tex.GetAccessibles();
			var carstr = car.GetAccessibles();
			var matstr = mat.GetAccessibles();
			
			bool tr = car.OfEnumerableType("Spoiler");
			var opt = car.GetPropertyEnumerableTypes("Spoiler");

			int aa = 0;
		}
	}
}
