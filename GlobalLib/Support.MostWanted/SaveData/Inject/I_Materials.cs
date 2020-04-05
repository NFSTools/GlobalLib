using System.IO;

namespace GlobalLib.Support.MostWanted
{
    public static partial class SaveData
    {
        /// <summary>
        /// Writes all materials into the Global data.
        /// </summary>
        /// <param name="db">Database with classes.</param>
        /// <param name="bw">BinaryWriter for writing data.</param>
        private static void I_Materials(Database.MostWanted db, BinaryWriter bw)
        {
            foreach (var material in db.Materials.Collections)
                bw.Write(material.Assemble());
        }
    }
}