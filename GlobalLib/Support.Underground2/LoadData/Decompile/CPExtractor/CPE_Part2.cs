namespace GlobalLib.Support.Underground2
{
    public static partial class LoadData
    {
        /// <summary>
        /// Copies entire part2 of CarParts block into memory.
        /// </summary>
        /// <param name="byteptr_t">Pointer to the ID of the part2 of CarParts block.</param>
        /// <param name="length">Lenght of the part2 of CarParts block including ID and size.</param>
        /// <returns>Part2 data as a byte array.</returns>
        private static unsafe byte[] CPE_Part2(byte* byteptr_t, uint length)
        {
            if (length < Framework.Assert.CPPart2_AssertSize)
                throw new System.IO.FileLoadException("Detected corrupted GlobalB.lzc CarParts block. Unable to load database.");
            byte[] data = new byte[Framework.Assert.CPPart2_AssertSize];
            for (int a1 = 0; a1 < Framework.Assert.CPPart2_AssertSize; ++a1)
                data[a1] = *(byteptr_t + a1);
            return data;
        }
    }
}