namespace GlobalLib.Support.MostWanted
{
    public static partial class SaveData
    {
        /// <summary>
        /// Writes all preset rides into the Global data.
        /// </summary>
        /// <param name="db">Database with classes.</param>
        /// <param name="bw">BinaryWriter for writing data.</param>
        private static void I_PresetRides(Database.MostWanted db, System.IO.BinaryWriter bw)
        {
            bw.Write(Reflection.ID.Global.PresetRides);
            bw.Write(db.PresetRides.Length * 0x290);
            for (int a1 = 0; a1 < db.PresetRides.Length; ++a1)
                bw.Write(db.PresetRides.Classes[a1].Assemble());
        }
    }
}