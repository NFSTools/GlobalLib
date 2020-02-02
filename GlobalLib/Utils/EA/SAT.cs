using System;
using GlobalLib.Support.Shared.Parts.FNGParts;


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
                *(uint*)(byteptr_t + 0) = Reflection.ID.Global.FEngFiles;
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
            string result = "0x";
            result += alpha.ToString("X2");
            result += red.ToString("X2");
            result += green.ToString("X2");
            result += blue.ToString("X2");
            return result;
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
        /// Compares two FEngColors.
        /// </summary>
        /// <param name="a1">FEngColor 1.</param>
        /// <param name="a2">FEngColor 2.</param>
        /// <returns>True if two FEngColors are equal.</returns>
        public static bool EqualColors(FEngColor a1, FEngColor a2)
        {
            if (a1.Alpha != a2.Alpha) return false;
            if (a1.Red != a2.Red) return false;
            if (a1.Green != a2.Green) return false;
            if (a1.Blue != a2.Blue) return false;
            return true;
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
            return FormatX.GetByte(color, "0x{XX}ABCDEF");
        }

        /// <summary>
        /// Gets red parameter of a hexadecimal color passed.
        /// </summary>
        /// <param name="color">Hexadecimal color passed.</param>
        /// <returns>Red parameter as a byte.</returns>
        public static byte GetRed(string color)
        {
            return FormatX.GetByte(color, "0xAB{XX}CDEF");
        }

        /// <summary>
        /// Gets green parameter of a hexadecimal color passed.
        /// </summary>
        /// <param name="color">Hexadecimal color passed.</param>
        /// <returns>Green parameter as a byte.</returns>
        public static byte GetGreen(string color)
        {
            return FormatX.GetByte(color, "0xABCD{XX}EF");
        }

        /// <summary>
        /// Gets blue parameter of a hexadecimal color passed.
        /// </summary>
        /// <param name="color">Hexadecimal color passed.</param>
        /// <returns>Blue parameter as a byte.</returns>
        public static byte GetBlue(string color)
        {
            return FormatX.GetByte(color, "0xABCDEF{XX}");
        }
    }
}