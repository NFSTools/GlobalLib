namespace GlobalLib.Support.Underground2
{
    public static partial class SaveData
    {
        /// <summary>
        /// Writes all preset rides into the Global data.
        /// </summary>
        /// <param name="db">Database with classes.</param>
        /// <param name="bw">BinaryWriter for writing data.</param>
        private static void I_Tracks(Database.Underground2 db, System.IO.BinaryWriter bw)
        {
            I_GlobalLibBlock(bw);
            bw.Write(Reflection.ID.Global.Tracks);
            bw.Write(db.Tracks.Length * 0x128);
            foreach (var track in db.Tracks.Classes.Values)
                bw.Write(track.Assemble());
        }
    }
}