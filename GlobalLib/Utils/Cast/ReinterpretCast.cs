namespace GlobalLib.Utils
{
    /// <summary>
    /// Collection of cast functions.
    /// </summary>
    public static partial class Cast
    {
        /// <summary>
        /// Casts any object to any type specified.
        /// </summary>
        /// <typeparam name="TypeID">Type to be converted to.</typeparam>
        /// <param name="value">Object passed to be casted.</param>
        /// <returns>Casted value of type specified. If casting fails, default value of the type specified is being returned.</returns>
        public static TypeID ReinterpretCast<TypeID>(object value)
        {
            try
            {
                return (TypeID)System.Convert.ChangeType(value, typeof(TypeID));
            }
            catch (System.Exception)
            {
                return default(TypeID);
            }
        }
    }
}
