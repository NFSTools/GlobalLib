namespace GlobalLib.Utils
{
    /// <summary>
    /// Collection of cast functions.
    /// </summary>
    public static partial class Cast
    {
        /// <summary>
        /// Casts any type passed to any primitive type specified.
        /// </summary>
        /// <param name="value">Object passed to be casted.</param>
        /// <param name="oftype">Primitive type to be converted to.</param>
        /// <returns>Casted value of the passed object.</returns>
        public static object RuntimeCast(object value, System.Type oftype)
        {
            if (oftype == typeof(string)) return value.ToString();
            else return System.Convert.ChangeType(value, oftype);
        }
    }
}