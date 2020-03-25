namespace GlobalLib.Support.Underground2
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
            if (length < Framework.Assert.CPPart1_AssertSize)
                throw new System.IO.FileLoadException("Detected corrupted GlobalB.lzc CarParts block. Unable to load database.");
            byte[] data = new byte[Framework.Assert.CPPart1_AssertSize];
            uint offset = 8;
            while (offset < Framework.Assert.CPPart1_AssertSize)
            {
                string debug = Utils.ScriptX.NullTerminatedString(byteptr_t + offset);
                if (debug == null) offset += 1;
                else offset += (uint)debug.Length + 1;
                Core.Map.BinKeys[Utils.Bin.Hash(debug)] = debug;
            }
            for (int a1 = 0; a1 < Framework.Assert.CPPart1_AssertSize; ++a1)
                data[a1] = *(byteptr_t + a1);
            
            return data;
        }
    }
}