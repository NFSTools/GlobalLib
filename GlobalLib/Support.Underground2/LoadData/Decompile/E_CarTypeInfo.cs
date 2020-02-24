namespace GlobalLib.Support.Underground2
{
    public static partial class LoadData
    {
        /// <summary>
        /// Decompile entire cartypeinfo block into Vector of separate elements.
        /// </summary>
        /// <param name="byteptr_t">Pointer to the beginning of cartypeinfo block in Global data.</param>
        /// <param name="length">Length of the block to be read.</param>
        /// <param name="db">Database to which add classes.</param>
        private static unsafe void E_CarTypeInfo(byte* byteptr_t, uint length, ref Database.Underground2 db)
        {
            uint size = 0x890; // is it tho?

            for (uint loop = 0; loop < length / size; ++loop)
            {
                uint offset = 8 + loop * size; // current offset of the cartypeinfo (padding included)

                // Get CollectionName
                string CName = Utils.ScriptX.NullTerminatedString(byteptr_t + offset, 0x10);

                CName = Utils.EA.Resolve.GetPathFromCollection(CName);
                Core.Map.BinKeys[Utils.Bin.Hash(CName)] = CName;
                if (!LibColBlockExists)
                    Core.Map.CollisionMap[Utils.Vlt.Hash(CName)] = CName;

                var Class = new Class.CarTypeInfo(byteptr_t + offset, CName, db);
                db.CarTypeInfos.Add(Class);
            }
        }
    }
}