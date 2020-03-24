namespace GlobalLib.Support.Underground2
{
    public static partial class SaveData
    {
        /// <summary>
        /// Writes all frontend groups into the Global data.
        /// </summary>
        /// <param name="db">Database with classes.</param>
        /// <param name="bw">BinaryWriter for writing data.</param>
        private static void I_FNGroup(Database.Underground2 db, System.IO.BinaryWriter bw)
        {
            for (int a1 = 0; a1 < db.FNGroups.Count; ++a1)
            {
                I_GlobalLibBlock(bw);
                bw.Write(db.FNGroups[a1].Assemble());
            }
        }
    }
}