﻿using GlobalLib.Core;
using GlobalLib.Support.Carbon.Class;
using GlobalLib.Utils;
using GlobalLib.Utils.EA;
using System;

namespace GlobalLib.Support.Carbon
{
    public static partial class LoadData
    {
        /// <summary>
        /// Decompile entire preset skins block into Vector of separate elements.
        /// </summary>
        /// <param name="byteptr_t">Pointer to the beginning of preset skins block in Global data.</param>
        /// <param name="length">Length of the block to be read.</param>
        /// <param name="db">Database to which add classes.</param>
        private static unsafe void E_PresetSkins(byte* byteptr_t, uint length, Database.Carbon db)
        {
            uint size = 0x68;

            for (uint loop = 0; loop < length / size; ++loop)
            {
                uint offset = loop * size; // current offset of the preset skin

                // Get CollectionName
                string CName = ScriptX.NullTerminatedString(byteptr_t + offset + 0x8, 0x20);

                CName = Resolve.GetPathFromCollection(CName);
                Map.BinKeys[Bin.Hash(CName)] = CName;

                var Class = new PresetSkin((IntPtr)(byteptr_t + offset), CName, db);
                db.PresetSkins.Collections.Add(Class);
            }
        }

    }
}