using System.Collections.Generic;



namespace GlobalLib.Core
{
    public static class Map
    {
        /// <summary>
        /// Represents all binary memory hashes through runtime of the library.
        /// </summary>
        public static Dictionary<uint, string> RaiderKeys { get; } = new Dictionary<uint, string>();

        /// <summary>
        /// Represents map of all possible collisions that can be used.
        /// </summary>
        public static Dictionary<uint, string> CollisionMap { get; set; } = new Dictionary<uint, string>();

        /// <summary>
        /// Represents list of all possible window tints that can be used.
        /// </summary>
        public static List<string> WindowTintMap { get; set; } = new List<string>() { };

        /// <summary>
        /// Represents array of all possible rim brands that can be used.
        /// </summary>
        public static List<string> RimBrands { get; set; } = new List<string>();

        /// <summary>
        /// Lookup through raider key map that throws no exceptions.
        /// </summary>
        /// <param name="key">Binary memory hash to look for.</param>
        /// <returns>Result value from the key passed, if value was not found, returns null instead.</returns>
        public static string Lookup(uint key)
        {
            if (RaiderKeys.TryGetValue(key, out string result))
                return result;
            else
                return null;
        }
    }
}
