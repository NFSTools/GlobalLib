namespace GlobalLib.Utils
{
    /// <summary>
    /// Collection of cast functions.
    /// </summary>
    public static partial class Cast
    {
        /// <summary>
        /// Special dynamic memory allocated casting function. Attempts to cast memory to any type specified.
        /// </summary>
        /// <param name="source">Object passed to be casted.</param>
        /// <param name="dest">Type to be converted to.</param>
        /// <returns>Dynamically allocated object of type specified, if fails, returns null.</returns>
        public static dynamic DynamicCast(dynamic source, System.Type dest)
        {
            try
            {
                return System.Convert.ChangeType(source, dest);
            }
            catch (System.Exception)
            {
                return null;
            }
        }
    }
}
