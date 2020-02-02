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
                string CName = "";
                for (uint a1 = offset + 8; *(byteptr_t + a1) != 0; ++a1)
                    CName += ((char)*(byteptr_t + a1)).ToString();

                CName = Utils.EA.Resolve.GetPathFromCollection(CName);
                Core.Map.RaiderKeys[Utils.Bin.Hash(CName)] = CName;

                var Class = new Class.PresetSkin(byteptr_t + offset, CName);
                db.PresetSkins.Add(Class);
            }
        }

    }
}