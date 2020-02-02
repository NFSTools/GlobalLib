namespace GlobalLib.Utils
{
    /// <summary>
    /// Collection of cast functions.
    /// </summary>
    public static partial class Cast
    {
        /// <summary>
        /// Fast way to cast memory of one object to another. Does not guarantee to return exact copy.
        /// </summary>
        /// <param name="result">Object to be casted memory into.</param>
        /// <param name="source">Object to be casted memory from.</param>
        public static void MemoryCast(this object result, object source)
        {
            var SourceType = source.GetType(); // get type of the source object
            var ResultType = result.GetType(); // get type of the result object

            foreach (var FieldInfo in SourceType.GetFields()) // for each register in source object
            {
                var ResultField = ResultType.GetField(FieldInfo.Name); // get field of result
                if (ResultField == null) continue; // skip if a null field / nonexistent field
                ResultField.SetValue(result, FieldInfo.GetValue(source)); // cast memory
            }

            foreach (var PropertyInfo in SourceType.GetProperties()) // get property of source object
            {
                var ResultProperty = ResultType.GetProperty(PropertyInfo.Name); // get property of result
                if (ResultProperty == null) continue; // skip if a null property / nonexistent property
                ResultProperty.SetValue(result, PropertyInfo.GetValue(source, null), null); // cast memory
            }
        }
    }
}
