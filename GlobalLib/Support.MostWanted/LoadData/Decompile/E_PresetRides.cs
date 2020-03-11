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
                string CName = Utils.ScriptX.NullTerminatedString(byteptr_t + offset + 0x28, 0x20);

                CName = Utils.EA.Resolve.GetPathFromCollection(CName);
                Core.Map.BinKeys[Utils.Bin.Hash(CName)] = CName;

                var Class = new Class.PresetRide(byteptr_t + offset, CName, db);
                db.PresetRides.Classes.Add(Class);
            }
        }
    }
}