using System.Text;
using GlobalLib.Core;
using GlobalLib.Reflection;



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

            var arr = Encoding.ASCII.GetBytes(value);
            var len = 0;
            var result = 0xFFFFFFFF;

            while (len < arr.Length)
            {
                result *= 0x21;
                result += arr[len++];
            }

            // Put into raider keys
            Map.BinKeys[result] = value;
            return result;
        }

        /// <summary>
        /// Hashes string passed and, if it starts with "0x", returns its unsigned integer value,
        /// otherwises converts to binary hash,
        /// </summary>
        /// <param name="value">String to be hashed.</param>
        /// <returns>Bin Memory Hash of the string as an unsigned integer.</returns>
        public static uint SmartHash(string value)
        {
            if (value == BaseArguments.NULL) return 0;
            return (value?.StartsWith("0x") ?? false) ? ConvertX.ToUInt32(value) : Hash(value);
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
