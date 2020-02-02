namespace GlobalLib.Support.MostWanted
{
    public static partial class LoadData
    {
        /// <summary>
        /// Gets the frontend group, decompresses it if needed, and plugs into Vector.
        /// </summary>
        /// <param name="byteptr_t">Pointer to the beginning of frontend group in Global data.</param>
        /// <param name="length">Length of the block to be read.</param>
        /// <param name="db">Database to which add classes.</param>
        private static unsafe void E_FNGroup(byte* byteptr_t, uint length, ref Database.MostWanted db)
        {
            // Copy data and decompress
            var data = new byte[length];
            fixed (byte* dataptr_t = &data[0])
            {
                for (int a1 = 0; a1 < data.Length; ++a1)
                    *(dataptr_t + a1) = *(byteptr_t + a1);
            }
            data = Utils.EA.SAT.Decompress(data);
            var Class = new Class.FNGroup(data);

            // Check whether this FEng class already exists in the database
            if (Class.Destroy)
                return;
            for (int a1 = 0; a1 < db.FNGroups.Count; ++a1)
            {
                if (Class.CollectionName == db.FNGroups[a1].CollectionName)
                    return;
            }
            db.FNGroups.Add(Class);
        }
    }
}