﻿using GlobalLib.Core;
using GlobalLib.Support.MostWanted.Class;
using GlobalLib.Utils;
using GlobalLib.Utils.EA;
using System;

namespace GlobalLib.Support.MostWanted
{
    public static partial class LoadData
    {
        /// <summary>
        /// Decompile entire preset rides block into Vector of separate elements.
        /// </summary>
        /// <param name="byteptr_t">Pointer to the beginning of preset rides block in Global data.</param>
        /// <param name="length">Length of the block to be read.</param>
        /// <param name="db">Database to which add classes.</param>
        private static unsafe void E_PresetRides(byte* byteptr_t, uint length, Database.MostWanted db)
        {
            uint size = 0x290;

            for (uint loop = 0; loop < length / size; ++loop)
            {
                uint offset = loop * size; // current offset of the preset ride

                // Get CollectionName
                string CName = ScriptX.NullTerminatedString(byteptr_t + offset + 0x28, 0x20);

                CName = Resolve.GetPathFromCollection(CName);
                Map.BinKeys[Bin.Hash(CName)] = CName;

                var Class = new PresetRide((IntPtr)(byteptr_t + offset), CName, db);
                db.PresetRides.Collections.Add(Class);
            }
        }
    }
}