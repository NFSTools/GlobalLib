using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;



namespace GlobalLib.Utils
{
	public static class ReflectX
	{
        public static bool IsAssignableToGeneric(Type giventype, Type generictype)
        {
            var interfaceTypes = giventype.GetInterfaces();

            foreach (var inter in interfaceTypes)
            {
                if (inter.IsGenericType && inter.GetGenericTypeDefinition() == generictype)
                    return true;
            }

            if (giventype.IsGenericType && giventype.GetGenericTypeDefinition() == generictype)
                return true;

            var basetype = giventype.BaseType;
            if (basetype == null) return false;

            return IsAssignableToGeneric(basetype, generictype);
        }
        public static bool IsFromGenericClass(Type giventype, Type generictype)
        {
            var basetype = giventype.BaseType;
            if (basetype == null) return false;

            if (basetype.IsGenericType && basetype.GetGenericTypeDefinition() == generictype)
                return true;
            else
                return IsFromGenericClass(basetype, generictype);
        }
        public static bool IsGenericDefinition(Type giventype, Type generictype)
        {
            return giventype.IsGenericType && giventype.GetGenericTypeDefinition() == generictype;
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