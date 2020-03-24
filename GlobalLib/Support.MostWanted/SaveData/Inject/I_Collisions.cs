namespace GlobalLib.Support.MostWanted
{
    public static partial class SaveData
    {
        /// <summary>
        /// Writes all collisions into the Global data.
        /// </summary>
        /// <param name="db">Database with classes.</param>
        /// <param name="bw">BinaryWriter for writing data.</param>
        private static unsafe void I_Collisions(Database.MostWanted db, System.IO.BinaryWriter bw)
        {
            bw.Write(Reflection.ID.Global.Collisions);
            bw.Write(0xFFFFFFFF); // write temp size
            int initial_size = (int)bw.BaseStream.Position;

            // Copy all collisions by the internal names
            foreach (var info in db.CarTypeInfos.Classes.Values)
            {
                if (info.CollisionExternalName == Reflection.BaseArguments.NULL) continue;
                uint extkey = Utils.Vlt.Hash(info.CollisionExternalName);
                uint intkey = Utils.Vlt.Hash(info.CollisionInternalName);
                if (db.SlotTypes.Collisions.TryGetValue(intkey, out var collision))
                    bw.Write(collision.GetData(extkey));
            }

            // Copy all unknown collisions
            foreach (var collision in db.SlotTypes.Collisions)
            {
                if (collision.Value.Unknown)
                    bw.Write(collision.Value.GetData(0));
            }

            // Fix size
            bw.BaseStream.Position = initial_size - 4;
            bw.Write((int)bw.BaseStream.Length - initial_size);
            bw.BaseStream.Position = bw.BaseStream.Length;
        }
    }
}