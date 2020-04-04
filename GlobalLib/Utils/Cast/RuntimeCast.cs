using System;



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
        public static object ReinterpretCast(object value, Type oftype)
        {
            if (oftype == typeof(string)) return value.ToString();
            else return Convert.ChangeType(value, oftype);
        }
    }
}