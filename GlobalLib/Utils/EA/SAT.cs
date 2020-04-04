using System;
using GlobalLib.Reflection.ID;



namespace GlobalLib.Utils.EA
{
    /// <summary>
    /// Collection of FEng and .fng relevant resolving functions.
    /// </summary>
    public static class SAT
    {
        /// <summary>
        /// Decompresses .fng JDLZ-compressed file.
        /// </summary>
        /// <param name="fng">.fng file as a byte array.</param>
        /// <returns>Decompressed FEng file as a byte array.</returns>
        public static unsafe byte[] Decompress(byte[] fng)
        {
            if (fng[0] == 3) // return if already decompressed
                return fng;

            byte[] InterData = new byte[fng.Length - 12];
            Buffer.BlockCopy(fng, 12, InterData, 0, fng.Length - 12);
            var NewData = JDLZ.Decompress(InterData);

            byte[] result = new byte[8 + NewData.Length];
            fixed (byte* byteptr_t = &result[0])
            {
                *(uint*)(byteptr_t + 0) = Global.FEngFiles;
                *(int*)(byteptr_t + 4) = NewData.Length;
            }

            Buffer.BlockCopy(NewData, 0, result, 8, NewData.Length);
            return result;
        }

        /// <summary>
        /// Converts ARGB representation to the hexadecimal one.
        /// </summary>
        /// <param name="alpha">Alpha value of the color.</param>
        /// <param name="red">Red value of the color.</param>
        /// <param name="green">Green value of the color.</param>
        /// <param name="blue">Blue value of the color.</param>
        /// <returns>String as a hexadecimal representation of the color.</returns>
        public static string ColorToHex(byte alpha, byte red, byte green, byte blue)
        {
            return $"0x{alpha:X2}{red:X2}{green:X2}{blue:X2}";
        }

        /// <summary>
        /// Gets index from "Color[#]" string.
        /// </summary>
        /// <param name="field">String from which get the index.</param>
        /// <returns>Integer value of the index of the color.</returns>
        public static int GetIndex(string field)
        {
            int result = -1;
            if (!field.StartsWith("Color["))
                return -1;
            if (!field.EndsWith("]"))
                return -1;
            try
            {
                string str = FormatX.GetString(field, "Color[{X}]");
                if (!int.TryParse(str, out result)) return -1;
            }
            catch { }
            return result;
        }

        /// <summary>
        /// Finds if the string passed can be a hexadecimal representation of a color.
        /// </summary>
        /// <param name="color">String passed to be evaluated.</param>
        /// <returns>True if the string can be a hexadecimal representation of a color.</returns>
        public static bool CanBeColor(string color)
        {
            bool result = false;
            if (color.Length != 10)
                return result;
            try
            {
                var value = Convert.ToUInt32(color, 16);
                result = true;
            }
            catch (Exception) { }
            return result;
        }

        /// <summary>
        /// Gets alpha parameter of a hexadecimal color passed.
        /// </summary>
        /// <param name="color">Hexadecimal color passed.</param>
        /// <returns>Alpha parameter as a byte.</returns>
        public static byte GetAlpha(string color)
        {
            try
            {
                string hex = FormatX.GetString(color, "0x{XX}ABCDEF");
                return Convert.ToByte(hex, 16);
            }
            catch (Exception) { return 0; }
        }

        /// <summary>
        /// Gets red parameter of a hexadecimal color passed.
        /// </summary>
        /// <param name="color">Hexadecimal color passed.</param>
        /// <returns>Red parameter as a byte.</returns>
        public static byte GetRed(string color)
        {
            try
            {
                string hex = FormatX.GetString(color, "0xAB{XX}CDEF");
                return Convert.ToByte(hex, 16);
            }
            catch (Exception) { return 0; }
        }

        /// <summary>
        /// Gets green parameter of a hexadecimal color passed.
        /// </summary>
        /// <param name="color">Hexadecimal color passed.</param>
        /// <returns>Green parameter as a byte.</returns>
        public static byte GetGreen(string color)
        {
            try
            {
                string hex = FormatX.GetString(color, "0xABCD{XX}EF");
                return Convert.ToByte(hex, 16);
            }
            catch (Exception) { return 0; }
        }

        /// <summary>
        /// Gets blue parameter of a hexadecimal color passed.
        /// </summary>
        /// <param name="color">Hexadecimal color passed.</param>
        /// <returns>Blue parameter as a byte.</returns>
        public static byte GetBlue(string color)
        {
            try
            {
                string hex = FormatX.GetString(color, "0xABCDEF{XX}");
                return Convert.ToByte(hex, 16);
            }
            catch (Exception) { return 0; }
        }
    }
}