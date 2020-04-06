using GlobalLib.Reflection.ID;
using System.IO;

namespace GlobalLib.Support.Carbon
{
    public static partial class SaveData
    {
        /// <summary>
        /// Writes all preset rides into the Global data.
        /// </summary>
        /// <param name="db">Database with classes.</param>
        /// <param name="bw">BinaryWriter for writing data.</param>
        private static void I_PresetRides(Database.Carbon db, BinaryWriter bw)
        {
            bw.Write(Global.PresetRides);
            bw.Write(db.PresetRides.Length * 0x600);
            foreach (var ride in db.PresetRides.Collections)
                bw.Write(ride.Assemble());
        }
    }
}