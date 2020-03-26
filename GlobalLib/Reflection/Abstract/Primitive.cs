namespace GlobalLib.Reflection.Abstract
{
	public abstract class Primitive : Interface.IGetValue, Interface.ISetValue
	{
        /// <summary>
        /// Checks if the property is of enumerable type.
        /// </summary>
        /// <param name="property">Name of the property to check.</param>
        /// <returns>True if property is enum; false otherwise.</returns>
        public virtual bool OfEnumerableType(string property)
        {
            return this.GetType().GetProperty(property).PropertyType.IsEnum;
        }

        /// <summary>
        /// Returns all enumerable strings of the property.
        /// </summary>
        /// <param name="property">Name of the enumerable property.</param>
        /// <returns>Array of strings.</returns>
        public virtual string[] GetPropertyEnumerableTypes(string property)
        {
            return this.GetType().GetProperty(property).PropertyType.GetEnumNames();
        }

        public abstract object[] GetAccessibles(Database.Collection.eGetInfoType type);
        public abstract string GetValue(string PropertyName);
        public abstract bool SetValue(string PropertyName, object value);
        public abstract bool SetValue(string PropertyName, object value, ref string error);
    }
}
