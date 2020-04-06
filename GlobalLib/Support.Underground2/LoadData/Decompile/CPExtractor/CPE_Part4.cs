using GlobalLib.Support.Underground2.Framework;
using System.IO;

namespace GlobalLib.Support.Underground2
{
    public static partial class LoadData
    {
        /// <summary>
        /// Copies entire part4 of CarParts block into memory.
        /// </summary>
        /// <param name="byteptr_t">Pointer to the ID of the part4 of CarParts block.</param>
        /// <param name="length">Lenght of the part4 of CarParts block including ID and size.</param>
        /// <returns>Part4 data as a byte array.</returns>
        private static unsafe byte[] CPE_Part4(byte* byteptr_t, uint length)
        {
            if (length < Assert.CPPart4_AssertSize)
                throw new FileLoadException("Detected corrupted GlobalB.lzc CarParts block. Unable to load database.");
            byte[] data = new byte[Assert.CPPart4_AssertSize];
            for (int a1 = 0; a1 < Assert.CPPart4_AssertSize; ++a1)
                data[a1] = *(byteptr_t + a1);

            return data;
        }
    }
}