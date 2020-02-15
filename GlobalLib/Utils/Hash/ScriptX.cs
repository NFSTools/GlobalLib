namespace GlobalLib.Utils
{
    /// <summary>
    /// Collection of functions used for parsing files and their data.
    /// </summary>
	public static class ScriptX
	{
        /// <summary>
        /// Gets string from inside quotation marks in the string passed. It can be
        /// any string of type "string str = "strlen" param", where result returned
        /// will be "strlen"
        /// </summary>
        /// <param name="value">String with quotes inside from which get the result.</param>
        /// <returns>String from quotation marks.</returns>
		public static string QuotedString(string value)
		{
            if (string.IsNullOrWhiteSpace(value)) return null;
            int first = 0;
            string result = null;
            while (value[first++] != '"') { }
            while (value[first] != '"')
                result += value[first++].ToString();
            return result;
        }
        
        /// <summary>
        /// Gets strings from inside all quotation marks of the string passed.
        /// </summary>
        /// <param name="value">String with quotes inside from which get the result.</param>
        /// <returns>Strings from quotation marks.</returns>
        public static string[] QuotedStrings(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return null;
            int first = -1;
            var result = new System.Collections.Generic.List<string>();
            while (first++ < value.Length)
            {
                string inter = null;
                while (first < value.Length && value[first++] != '"') { }
                while (first < value.Length && value[first] != '"')
                    inter += value[first++].ToString();
                if (first == value.Length) break;
                result.Add(inter);
            }
            return result.ToArray();
        }

        /// <summary>
        /// Reads null-terminated string from the byte stream.
        /// </summary>
        /// <param name="byteptr_t">Pointer to the data in the memory.</param>
        /// <returns>String read from the memory.</returns>
        public static unsafe string NullTerminatedString(byte* byteptr_t)
        {
            string result = string.Empty;
            for (int a1 = 0; *(byteptr_t + a1) != 0; ++a1)
                result += ((char)*(byteptr_t + a1)).ToString();
            return result;
        }

        /// <summary>
        /// Reads null-terminated string from the byte stream.
        /// </summary>
        /// <param name="byteptr_t">Pointer to the data in the memory.</param>
        /// <param name="maxlen">Maximum length to be read.</param>
        /// <returns>String read from the memory.</returns>
        public static unsafe string NullTerminatedString(byte* byteptr_t, int maxlen)
        {
            string result = string.Empty;
            for (int a1 = 0; a1 < maxlen && *(byteptr_t + a1) != 0; ++a1)
                result += ((char)*(byteptr_t + a1)).ToString();
            return result;
        }

        /// <summary>
        /// Reads null-terminated string using binary reader passed.
        /// </summary>
        /// <param name="br">Binary reader with which read the null-terminated string.</param>
        /// <returns>String read using binary reader.</returns>
        public static string NullTerminatedString(System.IO.BinaryReader br)
        {
            string result = string.Empty;
            byte reader;
            while ((reader = br.ReadByte()) != 0)
                result += ((char)reader).ToString();
            return result;
        }

        /// <summary>
        /// Reads null-terminated string using binary reader passed.
        /// </summary>
        /// <param name="br">Binary reader with which read the null-terminated string.</param>
        /// <param name="maxlen">Maximum length to be read.</param>
        /// <returns>String read using binary reader.</returns>
        public static string NullTerminatedString(System.IO.BinaryReader br, int maxlen)
        {
            string result = string.Empty;
            byte reader;
            for (int a1 = 0; a1 < maxlen && (reader = br.ReadByte()) != 0; ++a1)
                result += ((char)reader).ToString();
            return result;
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
        /// Removes all newlines and tabs from the string
        /// </summary>
        /// <param name="value">String to be modified.</param>
        /// <returns>String without newlines and tabs.</returns>
        public static string RemoveNewLines(string value)
        {
            string result = "";
            foreach (var c in value)
                if (c != '\n' && c != '\r' && c != '\t' && c != '\v') result += c.ToString();
            return result;
        }

        /// <summary>
        /// Cleans string from whitespace at the start (and optional ending).
        /// </summary>
        /// <param name="value">String to be cleaned.</param>
        /// <param name="frombothsides">True if clean from both start and end, false if just at the start.</param>
        /// <returns>Cleaned string without extra whitespace at the front (and optional at the end).</returns>
        public static string CleanString(string value, bool frombothsides)
        {
            if (string.IsNullOrWhiteSpace(value)) return string.Empty;
            int first = 0;
            int last = value.Length - 1;
            while (value[first] == ' ') ++first;
            while (value[last] == ' ') --last;
            if (frombothsides)
                return value.Substring(first, last - first + 1);
            else
                return value.Substring(first);
        }
    }
}
