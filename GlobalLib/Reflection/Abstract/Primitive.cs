using GlobalLib.Reflection.Enum;
using GlobalLib.Reflection.Interface;



namespace GlobalLib.Reflection.Abstract
{
    /// <summary>
    /// This is the ultimate base class of all classes in GlobalLib project. It includes 
    /// in itself all functions inherited from <see cref="IGetValue"/> and 
    /// <see cref="ISetValue"/> interfaces.
    /// </summary>
	public abstract class Primitive : IGetValue, ISetValue
	{
        /// <summary>
        /// Checks if the property is of <see cref="System.Enum"/> type.
        /// </summary>
        /// <param name="property">Name of the property to check.</param>
        /// <returns>True if property is enum; false otherwise.</returns>
        public virtual bool OfEnumerableType(string property)
        {
            return this.GetType().GetProperty(property).PropertyType.IsEnum;
        }

        /// <summary>
        /// Returns all <see cref="System.Enum"/> names of the property provided.
        /// </summary>
        /// <param name="property">Name of the enumerable property.</param>
        /// <returns>Array of strings.</returns>
        public virtual string[] GetPropertyEnumerableTypes(string property)
        {
            return this.GetType().GetProperty(property).PropertyType.GetEnumNames();
        }

        public abstract object[] GetAccessibles(eGetInfoType type);
        public abstract string GetValue(string PropertyName);
        public abstract bool SetValue(string PropertyName, object value);
        public abstract bool SetValue(string PropertyName, object value, ref string error);
    }
}
