using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;



namespace GlobalLib.Utils
{
	public static class ReflectX
	{
        public static bool IsAssignableToGeneric(Type givenType, Type genericType)
        {
            var interfaceTypes = givenType.GetInterfaces();

            foreach (var it in interfaceTypes)
            {
                if (it.IsGenericType && it.GetGenericTypeDefinition() == genericType)
                    return true;
            }

            if (givenType.IsGenericType && givenType.GetGenericTypeDefinition() == genericType)
                return true;

            Type baseType = givenType.BaseType;
            if (baseType == null) return false;

            return IsAssignableToGeneric(baseType, genericType);
        }

        public static bool IsEnumerableType(PropertyInfo property)
        {
            return (!typeof(string).Equals(property.PropertyType) &&
                typeof(IEnumerable).IsAssignableFrom(property.PropertyType));
        }
        public static bool IsEnumerableType(FieldInfo field)
        {
            return (!typeof(string).Equals(field.FieldType) &&
                typeof(IEnumerable).IsAssignableFrom(field.FieldType));
        }

        public static IEnumerable<TypeID> GetEnumerableCopy<TypeID>(object obj)
        {
            var result = new List<TypeID>();
            var enumerator = obj as IEnumerable;
            foreach (var s in enumerator)
                result.Add((TypeID)s);
            return (IEnumerable<TypeID>)result;
        }

        public static TypeID[] GetArrayCopy<TypeID>(object obj)
        {
            var result = new List<TypeID>();
            var enumerator = obj as IEnumerable;
            foreach (var s in enumerator)
                result.Add((TypeID)s);
            return result.ToArray();
        }
    }
}