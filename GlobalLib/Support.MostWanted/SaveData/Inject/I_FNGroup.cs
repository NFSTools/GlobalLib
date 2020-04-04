namespace GlobalLib.Support.MostWanted
{
    public static partial class SaveData
    {
        /// <summary>
        /// Writes all frontend groups into the Global data.
        /// </summary>
        /// <param name="db">Database with classes.</param>
        /// <param name="bw">BinaryWriter for writing data.</param>
        private static void I_FNGroup(Database.MostWanted db, System.IO.BinaryWriter bw)
        {
            for (int a1 = 0; a1 < db.FNGroups.Length; ++a1)
            {
                I_GlobalLibBlock(bw);
                bw.Write(db.FNGroups[a1].Assemble());
            }
        }
    }
}