using System;
using System.Text;
using GlobalLib.Reflection;



namespace GlobalLib.Utils
{
    /// <summary>
    /// Collection with methods of vault hashing.
    /// </summary>
    public static class Vlt
    {
        /// <summary>
        /// Hashes string passed and returns its vault hash.
        /// </summary>
        /// <param name="value">String to be hashed.</param>
        /// <returns>Vlt Memory Hash of the string as an unsigned integer.</returns>
        public static uint Hash(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return 0;

            var arr = Encoding.ASCII.GetBytes(value);
            var a = 0x9E3779B9;
            var b = 0x9E3779B9;
            var c = 0xABCDEF00;
            var v1 = 0;
            var v2 = arr.Length;

            while (v2 >= 12)
            {
                a += BitConverter.ToUInt32(arr, v1);
                b += BitConverter.ToUInt32(arr, v1 + 4);
                c += BitConverter.ToUInt32(arr, v1 + 8);
                Mix32_1(ref a, ref b, ref c);
                v1 += 12;
                v2 -= 12;
            }

            c += (uint)arr.Length;

            switch (v2)
            {
                case 11:
                    c += (uint)arr[10 + v1] << 24;
                    goto case 10;
                case 10:
                    c += (uint)arr[9 + v1] << 16;
                    goto case 9;
                case 9:
                    c += (uint)arr[8 + v1] << 8;
                    goto case 8;
                case 8:
                    b += (uint)arr[7 + v1] << 24;
                    goto case 7;
                case 7:
                    b += (uint)arr[6 + v1] << 16;
                    goto case 6;
                case 6:
                    b += (uint)arr[5 + v1] << 8;
                    goto case 5;
                case 5:
                    b += arr[4 + v1];
                    goto case 4;
                case 4:
                    a += (uint)arr[3 + v1] << 24;
                    goto case 3;
                case 3:
                    a += (uint)arr[2 + v1] << 16;
                    goto case 2;
                case 2:
                    a += (uint)arr[1 + v1] << 8;
                    goto case 1;
                case 1:
                    a += arr[v1];
                    break;
                default:
                    break;
            }

            return Mix32_2(a, b, c);
        }

        /// <summary>
        /// Hashes string passed and returns its vault-64 hash.
        /// </summary>
        /// <param name="value">String to be hashed.</param>
        /// <returns>Vlt64 Memory Hash of the string as an unsigned long.</returns>
        public static ulong Hash64(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return 0;
            var arr = Encoding.ASCII.GetBytes(value);
            ulong a = 0x9E3779B97F4A7C13;
            ulong b = 0x9E3779B97F4A7C13;
            ulong c = 0x11223344ABCDEF00;
            int v1 = 0;
            int v2 = arr.Length;

            while (v2 >= 24)
            {
                a += BitConverter.ToUInt64(arr, v1);
                b += BitConverter.ToUInt64(arr, v1 + 8);
                c += BitConverter.ToUInt64(arr, v1 + 16);
                Mix64_1(ref a, ref b, ref c);
                v1 += 24;
                v2 -= 24;
            }

            c += (ulong)arr.Length;

            switch (v2)
            {
                case 23:
                    c += (ulong)arr[22] << 56;
                    goto case 22;
                case 22:
                    c += (ulong)arr[21] << 48;
                    goto case 21;
                case 21:
                    c += (ulong)arr[20] << 40;
                    goto case 20;
                case 20:
                    c += (ulong)arr[19] << 32;
                    goto case 19;
                case 19:
                    c += (ulong)arr[18] << 24;
                    goto case 18;
                case 18:
                    c += (ulong)arr[17] << 16;
                    goto case 17;
                case 17:
                    c += (ulong)arr[16] << 8;
                    goto case 16;
                case 16:
                    b += (ulong)arr[15] << 56;
                    goto case 15;
                case 15:
                    b += (ulong)arr[14] << 48;
                    goto case 14;
                case 14:
                    b += (ulong)arr[13] << 40;
                    goto case 13;
                case 13:
                    b += (ulong)arr[12] << 32;
                    goto case 12;
                case 12:
                    b += (ulong)arr[11] << 24;
                    goto case 11;
                case 11:
                    b += (ulong)arr[10] << 16;
                    goto case 10;
                case 10:
                    b += (ulong)arr[9] << 8;
                    goto case 9;
                case 9:
                    b += arr[8];
                    goto case 8;
                case 8:
                    a += (ulong)arr[7] << 56;
                    goto case 7;
                case 7:
                    a += (ulong)arr[6] << 48;
                    goto case 6;
                case 6:
                    a += (ulong)arr[5] << 40;
                    goto case 5;
                case 5:
                    a += (ulong)arr[4] << 32;
                    goto case 4;
                case 4:
                    a += (ulong)arr[3] << 24;
                    goto case 3;
                case 3:
                    a += (ulong)arr[2] << 16;
                    goto case 2;
                case 2:
                    a += (ulong)arr[1] << 8;
                    goto case 1;
                case 1:
                    a += arr[0];
                    break;
                default:
                    break;
            }

            return Mix64_2(a, b, c);
        }

        /// <summary>
        /// Hashes string passed and, if it starts with "0x", returns its unsigned integer value,
        /// otherwises converts to vault hash.
        /// </summary>
        /// <param name="value">String to be hashed.</param>
        /// <returns>Vlt Memory Hash of the string as an unsigned integer.</returns>
        public static uint SmartHash(string value)
        {
            if (value == BaseArguments.NULL) return 0;
            return (value?.StartsWith("0x") ?? false) ? ConvertX.ToUInt32(value) : Hash(value);
        }

        /// <summary>
        /// Hashes string passed and, if it starts with "0x", returns its unsigned long value,
        /// otherwises converts to vault-64 hash.
        /// </summary>
        /// <param name="value">String to be hashed.</param>
        /// <returns>Vlt64 Memory Hash of the string as an unsigned long.</returns>
        public static ulong SmartHash64(string value)
        {
            if (value == BaseArguments.NULL) return 0;
            return (value?.StartsWith("0x") ?? false) ? ConvertX.ToUInt64(value) : Hash64(value);
        }

        /// <summary>
        /// Reverses bytes of an unsigned integer passed.
        /// </summary>
        /// <param name="value">Value to be reversed.</param>
        /// <returns>Unsigned integer value with reversed bytes of a passed value.</returns
        public static uint Reverse(uint key)
        {
            return (key << 24) |
                   (((key >> 16) << 24) >> 16) |
                   (((key << 16) >> 24) << 16) |
                   (key >> 24);
        }

        /// <summary>
        /// Reverses bytes of an unsigned long passed.
        /// </summary>
        /// <param name="value">Value to be reversed.</param>
        /// <returns>Unsigned long value with reversed bytes of a passed value.</returns>
        public static unsafe ulong Reverse64(ulong key)
        {
            var arr = new byte[8];
            byte* byteptr_t = (byte*)&key;
            for (int a1 = 0; a1 < 8; ++a1)
                arr[a1] = *(byteptr_t + 7 - a1);
            fixed (byte* dataptr_t = &arr[0])
            {
                return *(ulong*)dataptr_t;
            }
        }

        private static void Mix32_1(ref uint a, ref uint b, ref uint c)
        {
            a = c >> 13 ^ (a - b - c);
            b = a << 8 ^ (b - c - a);
            c = b >> 13 ^ (c - a - b);
            a = c >> 12 ^ (a - b - c);
            b = a << 16 ^ (b - c - a);
            c = b >> 5 ^ (c - a - b);
            a = c >> 3 ^ (a - b - c);
            b = a << 10 ^ (b - c - a);
            c = b >> 15 ^ (c - a - b);
        }
        private static uint Mix32_2(uint a, uint b, uint c)
        {
            a = c >> 13 ^ (a - b - c);
            b = a << 8 ^ (b - c - a);
            c = b >> 13 ^ (c - a - b);
            a = c >> 12 ^ (a - b - c);
            b = a << 16 ^ (b - c - a);
            c = b >> 5 ^ (c - a - b);
            a = c >> 3 ^ (a - b - c);
            b = a << 10 ^ (b - c - a);
            return b >> 15 ^ (c - a - b);
        }
        private static void Mix64_1(ref ulong a, ref ulong b, ref ulong c)
        {
            a = c >> 43 ^ (a - b - c);
            b = a << 9 ^ (b - c - a);
            c = b >> 8 ^ (c - a - b);
            a = c >> 38 ^ (a - b - c);
            b = a << 23 ^ (b - c - a);
            c = b >> 5 ^ (c - a - b);
            a = c >> 35 ^ (a - b - c);
            b = a << 49 ^ (b - c - a);
            c = b >> 11 ^ (c - a - b);
            a = c >> 12 ^ (a - b - c);
            b = a << 18 ^ (b - c - a);
            c = b >> 22 ^ (c - a - b);
        }
        private static ulong Mix64_2(ulong a, ulong b, ulong c)
        {
            a = c >> 43 ^ (a - b - c);
            b = a << 9 ^ (b - c - a);
            c = b >> 8 ^ (c - a - b);
            a = c >> 38 ^ (a - b - c);
            b = a << 23 ^ (b - c - a);
            c = b >> 5 ^ (c - a - b);
            a = c >> 35 ^ (a - b - c);
            b = a << 49 ^ (b - c - a);
            c = b >> 11 ^ (c - a - b);
            a = c >> 12 ^ (a - b - c);
            b = a << 18 ^ (b - c - a);
            return b >> 22 ^ (c - a - b);
        }
    }
}
