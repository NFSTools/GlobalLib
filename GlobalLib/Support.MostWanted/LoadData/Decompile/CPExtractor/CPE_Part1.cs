using GlobalLib.Core;
using GlobalLib.Utils;

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
                string debug = ScriptX.NullTerminatedString(byteptr_t + offset);
                if (debug == null) offset += 1;
                else offset += (uint)debug.Length + 1;
                Map.BinKeys[Bin.Hash(debug)] = debug;
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