namespace GlobalLib.Support.Carbon
{
    public static partial class SaveData
    {
        /// <summary>
        /// Writes all preset skins into the Global data.
        /// </summary>
        /// <param name="db">Database with classes.</param>
        /// <param name="bw">BinaryWriter for writing data.</param>
        private static void I_PresetSkins(Database.Carbon db, System.IO.BinaryWriter bw)
        {
            bw.Write(Reflection.ID.Global.PresetSkins);
            bw.Write(db.PresetSkins.Count * 0x68);
            for (int a1 = 0; a1 < db.PresetSkins.Count; ++a1)
                bw.Write(db.PresetSkins[a1].Assemble());
        }
    }
}