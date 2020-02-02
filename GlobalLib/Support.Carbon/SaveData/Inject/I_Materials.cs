﻿namespace GlobalLib.Support.Carbon
{
    public static partial class SaveData
    {
        /// <summary>
        /// Writes all materials into the Global data.
        /// </summary>
        /// <param name="db">Database with classes.</param>
        /// <param name="bw">BinaryWriter for writing data.</param>
        private static void I_Materials(Database.Carbon db, System.IO.BinaryWriter bw)
        {
            for (int a1 = 0; a1 < db.Materials.Count; ++a1)
                bw.Write(db.Materials[a1].Assemble());
        }
    }
}