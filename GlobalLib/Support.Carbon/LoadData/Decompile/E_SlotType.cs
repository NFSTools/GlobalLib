namespace GlobalLib.Support.Carbon
{
    public static partial class LoadData
    {
        /// <summary>
        /// Extracts slottype block into memory.
        /// </summary>
        /// <param name="byteptr_t">Pointer to the ID of spoilerss block in Global data.</param>
        /// <param name="length">Length of the block to be read (including ID and size).</param>
        /// <param name="db">Database to which add classes.</param>
        private static unsafe void E_SlotType(byte* byteptr_t, uint length, Database.Carbon db)
        {
            var Data = new byte[length];
            fixed (byte* dataptr_t = &Data[0])
            {
                for (int a1 = 0; a1 < length; ++a1)
                    *(dataptr_t + a1) = *(byteptr_t + a1);
            }
            db.SlotTypes.Spoilers = new Parts.CarParts.Spoilers(Data);
        }
    }
}