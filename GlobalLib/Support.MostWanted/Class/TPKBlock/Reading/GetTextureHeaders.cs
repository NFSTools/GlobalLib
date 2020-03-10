namespace GlobalLib.Support.MostWanted.Class
{
    public partial class TPKBlock
    {
        /// <summary>
        /// Gets list of offsets and sizes of the texture headers in the tpk block array.
        /// </summary>
        /// <param name="byteptr_t">Pointer to the tpk block array.</param>
        /// <param name="offset">Partial 1 part4 offset in the tpk block array.</param>
        /// <returns>Array of offsets and sizes of texture headers.</returns>
        protected override unsafe int[,] GetTextureHeaders(byte* byteptr_t, int offset)
        {
            if (*(uint*)(byteptr_t + offset) != Reflection.ID.TPK.INFO_PART4_BLOCKID)
                return null; // check Part4 ID

            int ReaderSize = offset + 8 + *(int*)(byteptr_t + offset + 4);
            var offsets = new System.Collections.Generic.List<int>();
            var sizes = new System.Collections.Generic.List<int>();
            offset += 8;

            while (offset < ReaderSize)
            {
                offsets.Add(offset); // add offset
                sizes.Add(0x7C);  // constant size
                offset += 0x7C;
            }

            var result = new int[offsets.Count, 2];
            for (int a1 = 0; a1 < offsets.Count; ++a1)
            {
                result[a1, 0] = offsets[a1];
                result[a1, 1] = sizes[a1];
            }
            return result;
        }
    }
}