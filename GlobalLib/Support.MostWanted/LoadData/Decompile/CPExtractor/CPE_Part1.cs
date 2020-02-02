namespace GlobalLib.Support.MostWanted
{
    public static partial class LoadData
    {
        /// <summary>
        /// Decompiles part1 of CarParts block, extracts all strings and gets the array to memory.
        /// </summary>
        /// <param name="byteptr_t">Pointer to the ID of the part1 of CarParts block.</param>
        /// <param name="length">Lenght of the part1 of CarParts block including ID and size.</param>
        /// <returns>Part1 data as a byte array.</returns>
        private static unsafe byte[] CPE_Part1(byte* byteptr_t, uint length)
        {
            byte[] data = new byte[length];
            uint offset = 8;
            while (offset < length)
            {
                string debug = "";
                for (uint a1 = offset; *(byteptr_t + a1) != 0; ++a1)
                    debug += ((char)*(byteptr_t + a1)).ToString();
                offset += (uint)debug.Length + 1;
                Core.Map.RaiderKeys[Utils.Bin.Hash(debug)] = debug;
            }
            fixed (byte* dataptr_t = &data[0])
            {
                for (int a1 = 0; a1 < length; ++a1)
                    *(dataptr_t + a1) = *(byteptr_t + a1);
            }
            return data;
        }
    }
}