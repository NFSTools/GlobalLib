﻿namespace GlobalLib.Support.MostWanted
{
    public static partial class LoadData
    {
        /// <summary>
        /// Copies entire part0 of CarParts block into memory.
        /// </summary>
        /// <param name="byteptr_t">Pointer to the ID of the part0 of CarParts block.</param>
        /// <param name="length">Lenght of the part0 of CarParts block including ID and size.</param>
        /// <returns>Part0 data as a byte array.</returns>
        private static unsafe byte[] CPE_Part0(byte* byteptr_t, uint length)
        {
            byte[] data = new byte[length];
            fixed (byte* dataptr_t = &data[0])
            {
                for (int a1 = 0; a1 < length; ++a1)
                    *(dataptr_t + a1) = *(byteptr_t + a1);
            }
            return data;
        }
    }
}