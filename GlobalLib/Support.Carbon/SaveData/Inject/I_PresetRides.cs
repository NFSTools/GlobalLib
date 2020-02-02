namespace GlobalLib.Support.Carbon
{
    public static partial class SaveData
    {
        /// <summary>
        /// Writes all preset rides into the Global data.
        /// </summary>
        /// <param name="db">Database with classes.</param>
        /// <param name="bw">BinaryWriter for writing data.</param>
        private static void I_PresetRides(Database.Carbon db, System.IO.BinaryWriter bw)
        {
            bw.Write(Reflection.ID.Global.PresetRides);
            bw.Write(db.PresetRides.Count * 0x600);
            for (int a1 = 0; a1 < db.PresetRides.Count; ++a1)
                bw.Write(db.PresetRides[a1].Assemble());
        }
    }
}