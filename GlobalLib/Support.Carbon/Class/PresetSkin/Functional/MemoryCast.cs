namespace GlobalLib.Support.Carbon.Class
{
    public partial class PresetSkin
    {
        /// <summary>
        /// Casts all attributes from this object to another one.
        /// </summary>
        /// <param name="CName">CollectionName of the new created object.</param>
        /// <returns>Memory casted copy of the object.</returns>
        public new PresetSkin MemoryCast(string CName)
        {
            var result = new PresetSkin(CName, this.Database);

            var flags = System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance
                | System.Reflection.BindingFlags.NonPublic;
            var args = new object[0] { };

            foreach (var property in this.GetType().GetProperties(flags))
            {
                if (property.Name == "CollectionName" || property.Name == "BinKey") continue;
                if (Utils.ReflectX.IsAssignableToGeneric(property.PropertyType, typeof(Reflection.Interface.ICopyable<>)))
                    result.GetType().GetProperty(property.Name, flags)
                        .SetValue(result, property.PropertyType
                        .GetMethod("PlainCopy")
                        .Invoke(property.GetValue(this), args));
                else if (Utils.ReflectX.IsEnumerableType(property))
                    result.GetType().GetProperty(property.Name, flags)
                        .SetValue(result, property.PropertyType.IsArray
                        ? typeof(Utils.ReflectX).GetMethod("GetArrayCopy")
                            .MakeGenericMethod(property.PropertyType.GetElementType())
                            .Invoke(null, new object[1] { property.GetValue(this) }) ?? default
                        : typeof(Utils.ReflectX).GetMethod("GetEnumerableCopy")
                            .MakeGenericMethod(property.PropertyType.GetGenericArguments()[0])
                            .Invoke(null, new object[1] { property.GetValue(this) }) ?? default);
                else if (result.GetType().GetProperty(property.Name, flags).GetSetMethod() != null)
                    result.GetType().GetProperty(property.Name, flags)
                        .SetValue(result, property.GetValue(this));
            }
            return result;
        }
    }
}