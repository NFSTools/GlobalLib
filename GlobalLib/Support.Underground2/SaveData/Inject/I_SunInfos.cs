namespace GlobalLib.Support.Underground2
{
    public static partial class SaveData
    {
        /// <summary>
        /// Writes all cartypeinfo into the Global data.
        /// </summary>
        /// <param name="db">Database with classes.</param>
        /// <param name="bw">BinaryWriter for writing data.</param>
        private static void I_SunInfos(Database.Underground2 db, System.IO.BinaryWriter bw)
        {
            I_GlobalLibBlock(bw);
            bw.Write(Reflection.ID.Global.SunInfos);
            bw.Write(db.SunInfos.Length * 0x110 + 8);
            bw.Write(0x1111111111111111);
            foreach (var suninfo in db.SunInfos.Collections)
                bw.Write(suninfo.Assemble());
        }
    }
}