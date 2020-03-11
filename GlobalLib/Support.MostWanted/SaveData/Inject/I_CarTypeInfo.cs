namespace GlobalLib.Support.MostWanted
{
    public static partial class SaveData
    {
        /// <summary>
        /// Writes all cartypeinfo into the Global data.
        /// </summary>
        /// <param name="db">Database with classes.</param>
        /// <param name="bw">BinaryWriter for writing data.</param>
        private static void I_CarTypeInfo(Database.MostWanted db, System.IO.BinaryWriter bw)
        {
            bw.Write(Reflection.ID.Global.CarTypeInfo);
            bw.Write(db.CarTypeInfos.Length * 0xD0 + 8);
            bw.Write(0x1111111111111111);
            for (int a1 = 0; a1 < db.CarTypeInfos.Length; ++a1)
                bw.Write(db.CarTypeInfos.Classes[a1].Assemble(a1));
        }
    }
}