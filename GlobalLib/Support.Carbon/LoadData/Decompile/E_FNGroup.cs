﻿using GlobalLib.Support.Carbon.Class;
using GlobalLib.Utils;
using GlobalLib.Utils.EA;

namespace GlobalLib.Support.Carbon
{
    public static partial class LoadData
    {
        /// <summary>
        /// Gets the frontend group, decompresses it if needed, and plugs into Vector.
        /// </summary>
        /// <param name="byteptr_t">Pointer to the beginning of frontend group in Global data.</param>
        /// <param name="length">Length of the block to be read.</param>
        /// <param name="db">Database to which add classes.</param>
        private static unsafe void E_FNGroup(byte* byteptr_t, uint length, Database.Carbon db)
        {
            // Copy data and decompress
            var data = new byte[length];
            fixed (byte* dataptr_t = &data[0])
            {
                for (int a1 = 0; a1 < data.Length; ++a1)
                    *(dataptr_t + a1) = *(byteptr_t + a1);
            }
            data = SAT.Decompress(data);
            var Class = new FNGroup(data, db);

            // Check whether this FEng class already exists in the database
            if (Class.Destroy)
                return;
            if (db.FNGroups.FindCollection(Class.CollectionName) != null)
                return;
            db.FNGroups.Collections.Add(Class);
            Bin.Hash(Class.CollectionName);
        }
    }
}