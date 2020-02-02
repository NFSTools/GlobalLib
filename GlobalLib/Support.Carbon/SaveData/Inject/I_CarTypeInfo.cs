namespace GlobalLib.Support.Carbon
{
    public static partial class SaveData
    {
        /// <summary>
        /// Writes all cartypeinfo into the Global data.
        /// </summary>
        /// <param name="db">Database with classes.</param>
        /// <param name="bw">BinaryWriter for writing data.</param>
        private static void I_CarTypeInfo(Database.Carbon db, System.IO.BinaryWriter bw)
        {
            bw.Write(Reflection.ID.Global.CarTypeInfo);
            bw.Write(db.CarTypeInfos.Count * 0xD0 + 8);
            bw.Write(0x1111111111111111);
            for (int a1 = 0; a1 < db.CarTypeInfos.Count; ++a1)
                bw.Write(db.CarTypeInfos[a1].Assemble(a1));
        }
    }
}