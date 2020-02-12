﻿namespace GlobalLib.Support.Carbon
{
    public static partial class LoadData
    {
        /// <summary>
        /// Decompile entire preset skins block into Vector of separate elements.
        /// </summary>
        /// <param name="byteptr_t">Pointer to the beginning of preset skins block in Global data.</param>
        /// <param name="length">Length of the block to be read.</param>
        /// <param name="db">Database to which add classes.</param>
        private static unsafe void E_PresetSkins(byte* byteptr_t, uint length, ref Database.Carbon db)
        {
            uint size = 0x68;

            for (uint loop = 0; loop < length / size; ++loop)
            {
                uint offset = loop * size; // current offset of the preset skin

                // Get CollectionName
                string CName = Utils.ScriptX.NullTerminatedString(byteptr_t + offset + 0x8, 0x20);

                CName = Utils.EA.Resolve.GetPathFromCollection(CName);
                Core.Map.BinKeys[Utils.Bin.Hash(CName)] = CName;

                var Class = new Class.PresetSkin(byteptr_t + offset, CName, db);
                db.PresetSkins.Add(Class);
            }
        }

    }
}