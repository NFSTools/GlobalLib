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
        public static object RuntimeCast(object value, object oftype)
        {
            if (oftype is bool)
            {
                if (value.ToString() == Reflection.BaseArguments.TRUE) return true;
                else if (value.ToString() == Reflection.BaseArguments.FALSE) return false;
                else return StaticCast<bool>(value);
            }
            else if (oftype is string)
                return StaticCast<string>(value);
            else if (oftype is int)
                return StaticCast<int>(value);
            else if (oftype is uint)
                return StaticCast<uint>(value);
            else if (oftype is short)
                return StaticCast<short>(value);
            else if (oftype is ushort)
                return StaticCast<ushort>(value);
            else if (oftype is byte)
                return StaticCast<byte>(value);
            else if (oftype is sbyte)
                return StaticCast<sbyte>(value);
            else if (oftype is double)
                return StaticCast<double>(value);
            else if (oftype is float)
                return StaticCast<float>(value);
            else if (oftype is long)
                return StaticCast<long>(value);
            else if (oftype is ulong)
                return StaticCast<ulong>(value);
            else if (oftype is char)
                return StaticCast<char>(value);
            else if (oftype is decimal)
                return StaticCast<decimal>(value);
            else
                return value;
        }
    }
}