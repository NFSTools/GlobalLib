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


			Console.WriteLine($"{elapsed_1}ms");

			/*
			using (var bw = new BinaryWriter(File.Open("UG2SLOTTYPES.BIN", FileMode.Create)))
			{
				var list = new List<GlobalLib.Support.Underground2.Parts.CarParts.CarSpoilMirrType>();
				foreach (var car in db.CarTypeInfos.Classes)
				{
					if (car.Spoiler != GlobalLib.Reflection.Enum.eSpoiler.SPOILER)
					{
						var add = new GlobalLib.Support.Underground2.Parts.CarParts.CarSpoilMirrType();
						add.CarTypeInfo = car.CollectionName;
						add.Spoiler = car.Spoiler;
						add.SpoilerNoMirror = true;
						list.Add(add);
					}
					if (car.Mirrors != GlobalLib.Reflection.Enum.eMirrorTypes.MIRRORS)
					{
						var add = new GlobalLib.Support.Underground2.Parts.CarParts.CarSpoilMirrType();
						add.CarTypeInfo = car.CollectionName;
						add.Mirrors = car.Mirrors;
						add.SpoilerNoMirror = false;
						list.Add(add);
					}
				}

				bw.Write(db.SlotTypes.SpoilMirrs.SetSpoilers(list));
			}
			*/

			int aa = 0; // for debug speed test

			Console.Read(); // for release speed test
		}
	}
}
