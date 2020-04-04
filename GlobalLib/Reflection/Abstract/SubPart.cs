using System.Collections.Generic;
using GlobalLib.Utils;
using GlobalLib.Reflection.Enum;
using GlobalLib.Reflection.Attributes;



namespace GlobalLib.Reflection.Abstract
{
    /// <summary>
    /// <see cref="SubPart"/> is a class that any <see cref="Collectable"/> may include in itself. 
    /// This class is not allowed to have any <see cref="AccessModifiableAttribute"/> 
    /// because all properties should be public, accessible and modifiable from the outside.
    /// </summary>
    public abstract class SubPart : Primitive
    {
        /// <summary>
        /// Optionable <see cref="Collectable"/> parent of this <see cref="SubPart"/> class.
        /// </summary>
        Collectable Parent { get; set; }

        /// <summary>
        /// Returns object array of all accessible and modifiable properties and fields.
        /// </summary>
        /// <param name="type"><see cref="eGetInfoType"/> enum value 
        /// that tells what objects type should be returned.</param>
        /// <returns>Array of strings.</returns>
        public override object[] GetAccessibles(eGetInfoType type)
        {
            var list = new List<object>();
            foreach (var property in this.GetType().GetProperties())
            {
                if (type == eGetInfoType.PROPERTY_NAMES)
                    list.Add(property.Name);
                else if (type == eGetInfoType.PROPERTY_INFOS)
                    list.Add(property);
            }
            return list.ToArray();
        }

        /// <summary>
        /// Returns the value of a field name provided.
        /// </summary>
        /// <param name="PropertyName">Field name to get the value from.</param>
        public override string GetValue(string PropertyName)
        {
            var property = this.GetType().GetProperty(PropertyName);
            return (property == null) ? null : property.GetValue(this).ToString();
        }

        /// <summary>
        /// Sets value at a field specified.
        /// </summary>
        /// <param name="PropertyName">Name of the field to be modified.</param>
        /// <param name="value">Value to be set at the field specified.</param>
        public override bool SetValue(string PropertyName, object value)
        {
            try
            {
                var property = this.GetType().GetProperty(PropertyName);
                if (property == null) return false;
                property.SetValue(this, Cast.ReinterpretCast(value, property.PropertyType));
                return true;
            }
            catch (System.Exception) { return false; }
        }

        /// <summary>
        /// Sets value at a field specified.
        /// </summary>
        /// <param name="PropertyName">Name of the field to be modified.</param>
        /// <param name="value">Value to be set at the field specified.</param>
        /// <param name="error">Error occured in case setting value fails.</param>
        public override bool SetValue(string PropertyName, object value, ref string error)
        {
            try
            {
                var property = this.GetType().GetProperty(PropertyName);
                if (property == null)
                {
                    error = $"Field named {PropertyName} does not exist.";
                    return false;
                }
                property.SetValue(this, Cast.ReinterpretCast(value, property.PropertyType));
                return true;
            }
            catch (System.Exception e)
            {
                while (e.InnerException != null) e = e.InnerException;
                error = e.Message;
                return false;
            }
        }
    }
}
