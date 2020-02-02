namespace GlobalLib.Utils
{
    public static class FormatX
    {
        /// <summary>
        /// Returns substring of a value from a specified format.
        /// Example: if value = "Array[100]" and format = "Array[{X}]", this returns (string)"100".
        /// </summary>
        /// <param name="value">String from which to get format</param>
        /// <param name="format">Format to which parse the string and return the value.</param>
        /// <returns>String got from format of the value passed.</returns>
        public static string GetString(string value, string format)
        {
            try
            {
                int formatstart = format.IndexOf('{');
                int formatend = format.Length - format.IndexOf('}') - 1;
                string result = value.Substring(formatstart, value.Length - formatend - formatstart);
                return result;
            }
            catch (System.Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Returns integer of a value from a specified format.
        /// Example: if value = "Array[100]" and format = "Array[{X}]", this returns (int)100.
        /// </summary>
        /// <param name="value">String from which to get format</param>
        /// <param name="format">Format to which parse the string and return the value.</param>
        /// <returns>Integer got from format of the value passed.</returns>
        public static int GetInt32(string value, string format)
        {
            try
            {
                string result = GetString(value, format);
                return System.Convert.ToInt32(result);
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// Returns unsigned integer of a value from a specified format.
        /// Example: if value = "Array[100]" and format = "Array[{X}]", this returns (uint)100.
        /// </summary>
        /// <param name="value">String from which to get format</param>
        /// <param name="format">Format to which parse the string and return the value.</param>
        /// <returns>Unsigned integer got from format of the value passed.</returns>
        public static uint GetUInt32(string value, string format)
        {
            try
            {
                string result = GetString(value, format);
                return System.Convert.ToUInt32(result);
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// Returns short of a value from a specified format.
        /// Example: if value = "Array[100]" and format = "Array[{X}]", this returns (short)100.
        /// </summary>
        /// <param name="value">String from which to get format</param>
        /// <param name="format">Format to which parse the string and return the value.</param>
        /// <returns>Short got from format of the value passed.</returns>
        public static short GetInt16(string value, string format)
        {
            try
            {
                string result = GetString(value, format);
                return System.Convert.ToInt16(result);
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// Returns unsigned short of a value from a specified format.
        /// Example: if value = "Array[100]" and format = "Array[{X}]", this returns (ushort)100.
        /// </summary>
        /// <param name="value">String from which to get format</param>
        /// <param name="format">Format to which parse the string and return the value.</param>
        /// <returns>Unsigned short got from format of the value passed.</returns>
        public static ushort GetUInt16(string value, string format)
        {
            try
            {
                string result = GetString(value, format);
                return System.Convert.ToUInt16(result);
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// Returns long of a value from a specified format.
        /// Example: if value = "Array[100]" and format = "Array[{X}]", this returns (long)100.
        /// </summary>
        /// <param name="value">String from which to get format</param>
        /// <param name="format">Format to which parse the string and return the value.</param>
        /// <returns>Long got from format of the value passed.</returns>
        public static long GetInt64(string value, string format)
        {
            try
            {
                string result = GetString(value, format);
                return System.Convert.ToInt64(result);
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// Returns unsigned long of a value from a specified format.
        /// Example: if value = "Array[100]" and format = "Array[{X}]", this returns (ulong)100.
        /// </summary>
        /// <param name="value">String from which to get format</param>
        /// <param name="format">Format to which parse the string and return the value.</param>
        /// <returns>Unsigned long got from format of the value passed.</returns>
        public static ulong GetUInt64(string value, string format)
        {
            try
            {
                string result = GetString(value, format);
                return System.Convert.ToUInt64(result);
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// Returns byte of a value from a specified format.
        /// Example: if value = "Array[100]" and format = "Array[{X}]", this returns (byte)100.
        /// </summary>
        /// <param name="value">String from which to get format</param>
        /// <param name="format">Format to which parse the string and return the value.</param>
        /// <returns>Byte got from format of the value passed.</returns>
        public static byte GetByte(string value, string format)
        {
            try
            {
                string result = GetString(value, format);
                return System.Convert.ToByte(result);
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// Returns signed byte of a value from a specified format.
        /// Example: if value = "Array[100]" and format = "Array[{X}]", this returns (sbyte)100.
        /// </summary>
        /// <param name="value">String from which to get format</param>
        /// <param name="format">Format to which parse the string and return the value.</param>
        /// <returns>Signed byte got from format of the value passed.</returns>
        public static sbyte GetSByte(string value, string format)
        {
            try
            {
                string result = GetString(value, format);
                return System.Convert.ToSByte(result);
            }
            catch (System.Exception)
            {
                return 0;
            }
        }
    }
}