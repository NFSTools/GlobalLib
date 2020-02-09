namespace GlobalLib.Utils.EA
{
    /// <summary>
    /// Collection of functions to resolve major disassembly/assembly tasks.
    /// </summary>
    public static class Resolve
    {
        /// <summary>
        /// Gets swatch string from swatch number specified.
        /// </summary>
        /// <param name="swatch">Swatch number to be converted.</param>
        /// <returns>String value of swatch number passed.</returns>
        public static string GetSwatchString(byte swatch)
        {
            if (swatch >= 1 && swatch <= 9)
                return "SWATCH_COLOR0" + swatch.ToString();
            else if (swatch >= 10 && swatch <= 90)
                return "SWATCH_COLOR" + swatch.ToString();
            else
                return "SWATCH_COLOR01";
        }

        /// <summary>
        /// Gets vinyl string from vinyl number specified.
        /// </summary>
        /// <param name="swatch">Vinyl number to be converted.</param>
        /// <returns>String value of vinyl number passed.</returns>
        public static string GetVinylString(byte swatch)
        {
            if (swatch == 0)
                return null;
            else if (swatch >= 1 && swatch <= 9)
                return "VINYL_L1_COLOR0" + swatch.ToString();
            else if (swatch >= 10 && swatch <= 90)
                return "VINYL_L1_COLOR" + swatch.ToString();
            else
                return null;
        }

        /// <summary>
        /// Gets the index of SWATCH_COLOR and VINYL_L1_COLOR.
        /// </summary>
        /// <param name="swatch">String to get the index from.</param>
        /// <returns>Swatch index as a byte.</returns>
        public static byte GetSwatchIndex(string swatch)
        {
            if (string.IsNullOrWhiteSpace(swatch)) return 0;
            if (!byte.TryParse(swatch.Substring(swatch.Length - 2, 2), out byte result))
                result = 0;
            return result;
        }

        /// <summary>
        /// Gets pearl window tint string from a string passed.
        /// </summary>
        /// <param name="tint">String to get pearl window tint from.</param>
        /// <returns>Pearl tint string if was resolved, null otherwise.</returns>
        public static void GetWindowTintString(string tint)
        {
            try
            {
                if (!tint.StartsWith("WINDSHIELD_TINT")) return;
                if (!int.TryParse(tint.Substring(17, 1), out int level)) return;
                if (level == 3)
                {
                    string color = FormatX.GetString(tint, "WINDSHIELD_TINT_L3_{X}");
                    string var1 = "WINDSHIELD_TINT_L3_PEARL_" + color;
                    string var2 = "WINDSHIELD_TINT_L3_PEARL " + color;
                    Core.Map.WindowTintMap.Add(var1);
                    Core.Map.WindowTintMap.Add(var2);
                    Bin.Hash(var1);
                    Bin.Hash(var2);
                    return;
                }
                else
                    if (!Core.Map.WindowTintMap.Contains(tint))
                        Core.Map.WindowTintMap.Add(tint);
            }
            catch (System.Exception) { }
        }

        /// <summary>
        /// Removes all special characters from the string passed.
        /// </summary>
        /// <param name="name">String to get clear one from.</param>
        /// <returns>String without any special characters.</returns>
        public static string GetPathFromCollection(string name)
        {
            string result = name;
            string illegal = new string(System.IO.Path.GetInvalidFileNameChars()) + new string(System.IO.Path.GetInvalidPathChars());
            foreach (char letter in illegal)
                result = result.Replace(letter.ToString(), ".");
            return result;
        }

        /// <summary>
        /// Determines whether number is odd or even.
        /// </summary>
        /// <param name="number">Number passed to be based on.</param>
        /// <returns>True if odd, false if even.</returns>
        public static bool IsOdd(int number)
        {
            if (number % 2 == 0)
                return false;
            else
                return true;
        }

        /// <summary>
        /// Determines if values passed can make a color.
        /// </summary>
        /// <param name="a">Alpha value as an unsigned int.</param>
        /// <param name="r">Red value as an unsigned int.</param>
        /// <param name="g">Green value as an unsigned int.</param>
        /// <param name="b">Blue value as an unsigned int.</param>
        /// <returns>True if values passed can form a color.</returns>
        public static bool IsColor(uint a, uint r, uint g, uint b)
        {
            if (b < 0 || b > 255)
                return false;
            if (g < 0 || g > 255)
                return false;
            if (r < 0 || r > 255)
                return false;
            if (a < 0 || a > 255)
                return false;

            return true;
        }

        /// <summary>
        /// Returns byte array of padding bytes required to start at offset % start_at = 0
        /// </summary>
        /// <param name="length">Length of the current stream to be added to.</param>
        /// <param name="start_at">Offset at which padding ends.</param>
        /// <returns>Byte array of padding bytes.</returns>
        public static byte[] GetPaddingArray(int length, byte start_at)
        {
            byte[] result;
            int difference = start_at - (length % start_at);
            if (difference == start_at) difference = -1;
            switch (difference)
            {
                case -1:
                    result = new byte[0];
                    return result;
                case 4:
                    result = new byte[4 + start_at];
                    result[4] = (byte)(start_at - 4);
                    return result;
                case 8:
                    result = new byte[8];
                    return result;
                default:
                    result = new byte[difference];
                    result[4] = (byte)(difference - 8);
                    return result;
            }
        }

        /// <summary>
        /// Removes all whitespace from the string.
        /// </summary>
        /// <param name="value">String to be modified.</param>
        /// <returns>String without whitespace.</returns>
        public static string RemoveWhiteSpace(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return string.Empty;
            string result = "";
            foreach (var c in value)
                if (c != ' ') result += c.ToString();
            return result;
        }

        /// <summary>
        /// Removes all newlines and tabs from the string.
        /// </summary>
        /// <param name="value">String to be modified.</param>
        /// <returns>String without newlines and tabs.</returns>
        public static string RemoveNewLines(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return string.Empty;
            string result = "";
            foreach (var c in value)
                if (c != '\n' && c != '\r' && c != '\t' && c != '\v') result += c.ToString();
            return result;
        }

        /// <summary>
        /// Compares two font styles and returns true if they are equal.
        /// </summary>
        /// <param name="font1">Font style 1 to be compared.</param>
        /// <param name="font2">Font style 2 to be compared.</param>
        /// <returns>True if two fonts passed are equal.</returns>
        public static bool EqualFonts(System.Drawing.Font font1, System.Drawing.Font font2)
        {
            if (font1.Unit != font2.Unit) return false;
            if (font1.Bold != font2.Bold) return false;
            if (font1.Italic != font2.Italic) return false;
            if (font1.Underline != font2.Underline) return false;
            if (font1.Strikeout != font2.Strikeout) return false;
            if (font1.Name != font2.Name) return false;
            if (font1.Style != font2.Style) return false;
            return true;
        }
    }
}
