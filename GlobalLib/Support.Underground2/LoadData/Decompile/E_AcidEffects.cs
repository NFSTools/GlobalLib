using GlobalLib.Core;
using GlobalLib.Support.Underground2.Class;
using GlobalLib.Utils;
using GlobalLib.Utils.EA;
using System;

namespace GlobalLib.Support.Underground2
{
    public static partial class LoadData
    {
        /// <summary>
        /// Decompile entire acid effects block into Vector of separate elements.
        /// </summary>
        /// <param name="byteptr_t">Pointer to the beginning of acid effects block in Global data.</param>
        /// <param name="length">Length of the block to be read.</param>
        /// <param name="db">Database to which add classes.</param>
        private static unsafe void E_AcidEffects(byte* byteptr_t, uint length, Database.Underground2 db)
        {
            const uint size = 0xD0;

            for (uint loop = 0; loop < length / size; ++loop)
            {
                uint offset = 0x18 + loop * size; // current offset of the acid effect (padding included)

                // Get CollectionName
                string CName = ScriptX.NullTerminatedString(byteptr_t + offset + 0x90, 0x40);

                CName = Resolve.GetPathFromCollection(CName);
                Map.BinKeys[Bin.Hash(CName)] = CName;

                var Class = new AcidEffect((IntPtr)(byteptr_t + offset), CName, db);
                db.AcidEffects.Collections.Add(Class);
            }
        }
    }
}