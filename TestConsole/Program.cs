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
			GlobalLib.Core.Process.Set = (int)GlobalLib.Core.GameINT.Carbon;
			GlobalLib.Core.Process.GlobalDir = @"C:\Need For Speed Carbon";
			var db = new GlobalLib.Database.Carbon();
			GlobalLib.Core.Process.LoadData(db);

			//var trackmaps = File.ReadAllBytes("TrackMaps.bin");
			//fixed (byte* byteptr_t = &trackmaps[0])
			//{
			//	var TPK = new GlobalLib.Support.Carbon.Class.TPKBlock(byteptr_t, -1, null);
			//	var arr = TPK.Assemble();
			//	using (var bw = new BinaryWriter(File.Open("NewMaps.bin", FileMode.Create)))
			//	{
			//		bw.Write(arr);
			//	}
			//
			//}



			int aa = 0;
		}
	}
}
