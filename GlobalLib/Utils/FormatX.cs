using System;



namespace GlobalLib.Utils
{
    /// <summary>
    /// Collection that gets values from formats provided. In case getting a value fails,
    /// function returns false.
    /// </summary>
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
            catch (Exception)
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
        public static bool GetInt32(string value, string format, out int result)
        {
            try
            {
                string str = GetString(value, format);
                result = Convert.ToInt32(str);
                return true;
            }
            catch (Exception)
            {
                result = 0;
                return false;
            }
        }

        /// <summary>
        /// Returns unsigned integer of a value from a specified format.
        /// Example: if value = "Array[100]" and format = "Array[{X}]", this returns (uint)100.
        /// </summary>
        /// <param name="value">String from which to get format</param>
        /// <param name="format">Format to which parse the string and return the value.</param>
        /// <returns>Unsigned integer got from format of the value passed.</returns>
        public static bool GetUInt32(string value, string format, out uint result)
        {
            try
            {
                string str = GetString(value, format);
                result = Convert.ToUInt32(str);
                return true;
            }
            catch (Exception)
            {
                result = 0;
                return false;
            }
        }

        /// <summary>
        /// Returns short of a value from a specified format.
        /// Example: if value = "Array[100]" and format = "Array[{X}]", this returns (short)100.
        /// </summary>
        /// <param name="value">String from which to get format</param>
        /// <param name="format">Format to which parse the string and return the value.</param>
        /// <returns>Short got from format of the value passed.</returns>
        public static bool GetInt16(string value, string format, out short result)
        {
            try
            {
                string str = GetString(value, format);
                result = Convert.ToInt16(str);
                return true;
            }
            catch (Exception)
            {
                result = 0;
                return false;
            }
        }

        /// <summary>
        /// Returns unsigned short of a value from a specified format.
        /// Example: if value = "Array[100]" and format = "Array[{X}]", this returns (ushort)100.
        /// </summary>
        /// <param name="value">String from which to get format</param>
        /// <param name="format">Format to which parse the string and return the value.</param>
        /// <returns>Unsigned short got from format of the value passed.</returns>
        public static bool GetUInt16(string value, string format, out ushort result)
        {
            try
            {
                string str = GetString(value, format);
                result = Convert.ToUInt16(str);
                return true;
            }
            catch (Exception)
            {
                result = 0;
                return false;
            }
        }

        /// <summary>
        /// Returns long of a value from a specified format.
        /// Example: if value = "Array[100]" and format = "Array[{X}]", this returns (long)100.
        /// </summary>
        /// <param name="value">String from which to get format</param>
        /// <param name="format">Format to which parse the string and return the value.</param>
        /// <returns>Long got from format of the value passed.</returns>
        public static bool GetInt64(string value, string format, out long result)
        {
            try
            {
                string str = GetString(value, format);
                result = Convert.ToInt64(str);
                return true;
            }
            catch (Exception)
            {
                result = 0;
                return false;
            }
        }

        /// <summary>
        /// Returns unsigned long of a value from a specified format.
        /// Example: if value = "Array[100]" and format = "Array[{X}]", this returns (ulong)100.
        /// </summary>
        /// <param name="value">String from which to get format</param>
        /// <param name="format">Format to which parse the string and return the value.</param>
        /// <returns>Unsigned long got from format of the value passed.</returns>
        public static bool GetUInt64(string value, string format, out ulong result)
        {
            try
            {
                string str = GetString(value, format);
                result = Convert.ToUInt64(str);
                return true;
            }
            catch (Exception)
            {
                result = 0;
                return false;
            }
        }

        /// <summary>
        /// Returns byte of a value from a specified format.
        /// Example: if value = "Array[100]" and format = "Array[{X}]", this returns (byte)100.
        /// </summary>
        /// <param name="value">String from which to get format</param>
        /// <param name="format">Format to which parse the string and return the value.</param>
        /// <returns>Byte got from format of the value passed.</returns>
        public static bool GetByte(string value, string format, out byte result)
        {
            try
            {
                string str = GetString(value, format);
                result = Convert.ToByte(str);
                return true;
            }
            catch (Exception)
            {
                result = 0;
                return false;
            }
        }

        /// <summary>
        /// Returns signed byte of a value from a specified format.
        /// Example: if value = "Array[100]" and format = "Array[{X}]", this returns (sbyte)100.
        /// </summary>
        /// <param name="value">String from which to get format</param>
        /// <param name="format">Format to which parse the string and return the value.</param>
        /// <returns>Signed byte got from format of the value passed.</returns>
        public static bool GetSByte(string value, string format, out sbyte result)
        {
            try
            {
                string str = GetString(value, format);
                result = Convert.ToSByte(str);
                return true;
            }
            catch (Exception)
            {
                result = 0;
                return false;
            }
        }
    }
}