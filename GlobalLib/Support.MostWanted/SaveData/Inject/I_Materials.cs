namespace GlobalLib.Support.MostWanted
{
    public static partial class SaveData
    {
        /// <summary>
        /// Writes all materials into the Global data.
        /// </summary>
        /// <param name="db">Database with classes.</param>
        /// <param name="bw">BinaryWriter for writing data.</param>
        private static void I_Materials(Database.MostWanted db, System.IO.BinaryWriter bw)
        {
            for (int a1 = 0; a1 < db.Materials.Length; ++a1)
                bw.Write(db.Materials.Classes[a1].Assemble());
        }
    }
}