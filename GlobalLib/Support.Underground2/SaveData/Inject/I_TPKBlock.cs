﻿using System.IO;

namespace GlobalLib.Support.Underground2
{
    public static partial class SaveData
    {
        /// <summary>
        /// Writes TPK block into Global data.
        /// </summary>
        /// <param name="db">Database with classes.</param>
        /// <param name="bw">BinaryWriter for writing data.</param>
        /// <param name="index">Index of the TPK block in the database</param>
        private static void I_TPKBlock(Database.Underground2 db, BinaryWriter bw, ref int index)
        {
            I_GlobalLibBlock(bw);
            bw.Write(db.TPKBlocks.Collections[index++].Assemble());
        }
    }
}