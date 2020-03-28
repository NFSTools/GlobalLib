namespace GlobalLib.Support.Underground2
{
    public static partial class SaveData
    {
        /// <summary>
        /// Writes all preset rides into the Global data.
        /// </summary>
        /// <param name="db">Database with classes.</param>
        /// <param name="bw">BinaryWriter for writing data.</param>
        private static void I_PresetRides(Database.Underground2 db, System.IO.BinaryWriter bw)
        {
            I_GlobalLibBlock(bw);
            bw.Write(Reflection.ID.Global.PresetRides);
            bw.Write(db.PresetRides.Length * 0x338);
            foreach (var ride in db.PresetRides.Collections)
                bw.Write(ride.Assemble());
        }
    }
}