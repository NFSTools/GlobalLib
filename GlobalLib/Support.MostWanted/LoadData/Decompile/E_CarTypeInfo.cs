using GlobalLib.Core;
using GlobalLib.Support.MostWanted.Class;
using GlobalLib.Utils;
using GlobalLib.Utils.EA;
using System;

namespace GlobalLib.Support.MostWanted
{
    public static partial class LoadData
    {
        /// <summary>
        /// Decompile entire cartypeinfo block into Vector of separate elements.
        /// </summary>
        /// <param name="byteptr_t">Pointer to the beginning of cartypeinfo block in Global data.</param>
        /// <param name="length">Length of the block to be read.</param>
        /// <param name="db">Database to which add classes.</param>
        private static unsafe void E_CarTypeInfo(byte* byteptr_t, uint length, Database.MostWanted db)
        {
            uint size = 0xD0;

            for (uint loop = 0; loop < length / size; ++loop)
            {
                uint offset = 8 + loop * size; // current offset of the cartypeinfo (padding included)

                // Get CollectionName
                string CName = ScriptX.NullTerminatedString(byteptr_t + offset, 0x10);

                CName = Resolve.GetPathFromCollection(CName);
                Map.BinKeys[Bin.Hash(CName)] = CName;
                if (!LibColBlockExists)
                    Map.CollisionMap[Vlt.Hash(CName)] = CName;

                var Class = new CarTypeInfo((IntPtr)(byteptr_t + offset), CName, db);
                db.CarTypeInfos.Collections.Add(Class);
            }
        }
    }
}