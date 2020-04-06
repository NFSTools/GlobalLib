using GlobalLib.Reflection.ID;
using System.IO;

namespace GlobalLib.Support.Underground2
{
    public static partial class SaveData
    {
        /// <summary>
        /// Writes all car parts into the Global data.
        /// </summary>
        /// <param name="db">Database with classes.</param>
        /// <param name="bw">BinaryWriter for writing data.</param>
        private static void I_CarParts(Database.Underground2 db, BinaryWriter bw)
        {
            var _part1 = CPI_Part1(db);
            var _part2 = CPI_Part2(db);
            var _part3 = CPI_Part3(db);
            var _part4 = CPI_Part4(db);
            var _part56 = CPI_Part56(db);
            var _part0 = db.SlotTypes.Part0.Data;

            int size = _part0.Length + _part1.Length + _part2.Length;
            size += _part3.Length + _part4.Length + _part56.Length;

            bw.Write(Global.CarParts);
            bw.Write(size);
            bw.Write(_part0);
            bw.Write(_part1);
            bw.Write(_part2);
            bw.Write(_part3);
            bw.Write(_part4);
            bw.Write(_part56);
        }
    }
}