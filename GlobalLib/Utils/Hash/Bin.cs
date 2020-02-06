namespace GlobalLib.Utils
{
    /// <summary>
    /// Collection with methods of binary hashing.
    /// </summary>
    public static class Bin
    {
        /// <summary>
        /// Hashes string passed and returns its binary hash.
        /// </summary>
        /// <param name="value">String to be hashed.</param>
        /// <returns>Bin Memory Hash of the string as an unsigned integer.</returns>
        public static uint Hash(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) // check for being null
                return 0;

            byte[] arr = System.Text.Encoding.GetEncoding(1252).GetBytes(value);
            int len = 0;
            uint result = 0xFFFFFFFF;

            while (len < arr.Length)
            {
                result *= 0x21;
                result += arr[len++];
            }

            // Put into raider keys
            Core.Map.BinKeys[result] = value;
            return result;
        }

        /// <summary>
        /// Reverses bytes of an unsigned integer passed.
        /// </summary>
        /// <param name="value">Value to be reversed.</param>
        /// <returns>Unsigned integer value with reversed bytes of a passed value.</returns>
        public static uint Reverse(uint value)
        {
            return (value << 24) |
                   (((value >> 16) << 24) >> 16) |
                   (((value << 16) >> 24) << 16) |
                   (value >> 24);
        }
    }
}
