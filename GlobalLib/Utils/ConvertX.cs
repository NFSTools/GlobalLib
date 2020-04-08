using System;



namespace GlobalLib.Utils
{
    /// <summary>
    /// Collection that automatically converts hexadecimal strings to specified types.
    /// If conversion fails, returns 0.
    /// </summary>
    public static class ConvertX
    {
        public static sbyte ToSByte(string value)
        {
            try { return Convert.ToSByte(value, 16); }
            catch (Exception) { return 0; }
        }

        public static short ToInt16(string value)
        {
            try { return Convert.ToInt16(value, 16); }
            catch (Exception) { return 0; }
        }

        public static int ToInt32(string value)
        {
            try { return Convert.ToInt32(value, 16); }
            catch (Exception) { return 0; }
        }

        public static long ToInt64(string value)
        {
            try { return Convert.ToInt64(value, 16); }
            catch (Exception) { return 0; }
        }

        public static byte ToByte(string value)
        {
            try { return Convert.ToByte(value, 16); }
            catch (Exception) { return 0; }
        }

        public static ushort ToUInt16(string value)
        {
            try { return Convert.ToUInt16(value, 16); }
            catch (Exception) { return 0; }
        }

        public static uint ToUInt32(string value)
        {
            try { return Convert.ToUInt32(value, 16); }
            catch (Exception) { return 0; }
        }

        public static ulong ToUInt64(string value)
        {
            try { return Convert.ToUInt64(value, 16); }
            catch (Exception) { return 0; }
        }
    }
}
