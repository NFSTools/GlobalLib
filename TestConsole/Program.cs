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
        static void Main(string[] args)
        {
            string filepath = @"C:\Need for Speed Carbon";
            var database = new GlobalLib.Database.Carbon();
            GlobalLib.Core.Process.GlobalDir = filepath;
            GlobalLib.Core.Process.Set = (int)GlobalLib.Core.GameINT.Carbon;
            GlobalLib.Core.Process.MessageShow = true;
            
            
            
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            GlobalLib.Core.Process.LoadData(ref database);
            watch.Stop();
            Console.WriteLine($"Finished loading data in {watch.ElapsedMilliseconds}ms.");
            
            watch.Reset();
            watch.Start();
            GlobalLib.Core.Process.SaveData(database, false);
            watch.Stop();
            Console.WriteLine($"Finished saving data in {watch.ElapsedMilliseconds}ms.");


            Console.Read();
        }
    }
}
