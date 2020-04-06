using GlobalLib.Reflection.ID;
using System.IO;

namespace GlobalLib.Support.Carbon
{
    public static partial class SaveData
    {
        /// <summary>
        /// Writes all preset skins into the Global data.
        /// </summary>
        /// <param name="db">Database with classes.</param>
        /// <param name="bw">BinaryWriter for writing data.</param>
        private static void I_PresetSkins(Database.Carbon db, BinaryWriter bw)
        {
            bw.Write(Global.PresetSkins);
            bw.Write(db.PresetSkins.Length * 0x68);
            foreach (var skin in db.PresetSkins.Collections)
                bw.Write(skin.Assemble());
        }
    }
}