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
            if (oftype is string)
                return ReinterpretCast<string>(value);
            else if (oftype is bool)
                return ReinterpretCast<bool>(value);
            else if (oftype is int)
                return ReinterpretCast<int>(value);
            else if (oftype is uint)
                return ReinterpretCast<uint>(value);
            else if (oftype is short)
                return ReinterpretCast<short>(value);
            else if (oftype is ushort)
                return ReinterpretCast<ushort>(value);
            else if (oftype is byte)
                return ReinterpretCast<byte>(value);
            else if (oftype is sbyte)
                return ReinterpretCast<sbyte>(value);
            else if (oftype is double)
                return ReinterpretCast<double>(value);
            else if (oftype is float)
                return ReinterpretCast<float>(value);
            else if (oftype is long)
                return ReinterpretCast<long>(value);
            else if (oftype is ulong)
                return ReinterpretCast<ulong>(value);
            else if (oftype is char)
                return ReinterpretCast<char>(value);
            else if (oftype is decimal)
                return ReinterpretCast<decimal>(value);
            else
                return value;
        }
    }
}
