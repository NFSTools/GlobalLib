using GlobalLib.Reflection.ID;
using System.IO;

namespace GlobalLib.Support.Underground2
{
    public static partial class SaveData
    {
        /// <summary>
        /// Writes all tracks into the Global data.
        /// </summary>
        /// <param name="db">Database with classes.</param>
        /// <param name="bw">BinaryWriter for writing data.</param>
        private static void I_Tracks(Database.Underground2 db, BinaryWriter bw)
        {
            I_GlobalLibBlock(bw);
            bw.Write(Global.Tracks);
            bw.Write(db.Tracks.Length * 0x128);
            foreach (var track in db.Tracks.Collections)
                bw.Write(track.Assemble());
        }
    }
}