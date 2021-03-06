﻿using GlobalLib.Reflection.ID;
using System.IO;

namespace GlobalLib.Support.Underground2
{
    public static partial class SaveData
    {
        /// <summary>
        /// Writes all cartypeinfo into the Global data.
        /// </summary>
        /// <param name="db">Database with classes.</param>
        /// <param name="bw">BinaryWriter for writing data.</param>
        private static void I_CarTypeInfo(Database.Underground2 db, BinaryWriter bw)
        {
            int index = 0;
            bw.Write(Global.CarTypeInfo);
            bw.Write(db.CarTypeInfos.Length * 0x890 + 8);
            bw.Write(0x1111111111111111);
            foreach (var car in db.CarTypeInfos.Collections)
            {
                car.Index = index++;
                bw.Write(car.Assemble());
            }
        }
    }
}