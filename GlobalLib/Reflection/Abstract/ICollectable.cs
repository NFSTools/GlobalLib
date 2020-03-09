namespace GlobalLib.Reflection.Abstract
{
	public abstract class ICollectable
	{
        /// <summary>
        /// Collection name of the variable.
        /// </summary>
        public abstract string CollectionName { get; set; }

        /// <summary>
        /// Returns array of all accessible and modifiable properties and fields.
        /// </summary>
        /// <returns>Array of strings.</returns>
        public virtual string[] GetAccessibles()
        {
            var list = new System.Collections.Generic.List<string>();
            foreach (var property in this.GetType().GetProperties())
            {
                if (System.Attribute.IsDefined(property, typeof(Attributes.AccessModifiableAttribute)))
                    list.Add(property.Name);
            }
            list.Sort();
            return list.ToArray();
        }

        /// <summary>
        /// Checks if the property is of enumerable type.
        /// </summary>
        /// <param name="property">Name of the property to check.</param>
        /// <returns>True if property is enum; false otherwise.</returns>
        public virtual bool OfEnumerableType(string property)
        {
            return this.GetType().GetProperty(property).GetType().IsEnum;
        }

        /// <summary>
        /// Returns all enumerable strings of the property.
        /// </summary>
        /// <param name="property">Name of the enumerable property.</param>
        /// <returns>Array of strings.</returns>
        public virtual string[] GetPropertyEnumerableTypes(string property)
        {
            return this.GetType().GetProperty(property).GetType().GetEnumNames();
        }

        /// <summary>
        /// Returns the value of a field name provided.
        /// </summary>
        /// <param name="PropertyName">Field name to get the value from.</param>
        /// <returns>String value of a field name.</returns>
        public virtual string GetValue(string PropertyName)
        {
            foreach (var ThisProperty in this.GetType().GetProperties())
            {
                if (ThisProperty.Name == PropertyName)
                    return ThisProperty.GetValue(this).ToString();
            }
            return null;
        }

        /// <summary>
        /// Sets value at a field specified.
        /// </summary>
        /// <param name="PropertyName">Name of the field to be modified.</param>
        /// <param name="value">Value to be set at the field specified.</param>
        public virtual bool SetValue(string PropertyName, object value)
        {
            try
            {
                var property = this.GetType().GetProperty(PropertyName);
                if (property == null) return false;
                if (!System.Attribute.IsDefined(property, typeof(Attributes.AccessModifiableAttribute)))
                    throw new System.FieldAccessException("This field is either non-modifiable or non-accessible");
                if (property.PropertyType == typeof(bool))
                {
                    if (value.ToString() == BaseArguments.TRUE || (int)value != 0)
                        property.SetValue(this, true);
                    else if (value.ToString() == BaseArguments.FALSE || (int)value == 0)
                        property.SetValue(this, false);
                    else
                        throw new System.InvalidCastException();
                }
                else
                {
                    property.SetValue(this, typeof(Utils.Cast).
                        GetMethod("StaticCast").
                        MakeGenericMethod(property.PropertyType)
                        .Invoke(null, new object[1] { value }));
                }
                return true;
            }
            catch (System.Exception e)
            {
                while (e.InnerException != null) e = e.InnerException;
                if (Core.Process.MessageShow)
                    System.Windows.Forms.MessageBox.Show(e.Message);
                else
                    System.Console.WriteLine($"{e.Message}");
                return false;
            }
        }

        /// <summary>
        /// Sets value at a field specified.
        /// </summary>
        /// <param name="PropertyName">Name of the field to be modified.</param>
        /// <param name="value">Value to be set at the field specified.</param>
        public virtual bool SetValue(string PropertyName, object value, ref string error)
        {
            try
            {
                var property = this.GetType().GetProperty(PropertyName);
                if (property == null)
                {
                    error = $"Field named {PropertyName} does not exist.";
                    return false;
                }
                if (!System.Attribute.IsDefined(property, typeof(Attributes.AccessModifiableAttribute)))
                    throw new System.FieldAccessException("This field is either non-modifiable or non-accessible");
                var type = property.GetType();
                if (type == typeof(bool))
                {
                    if (value.ToString() == BaseArguments.TRUE || (int)value != 0)
                        property.SetValue(this, true);
                    else if (value.ToString() == BaseArguments.FALSE || (int)value == 0)
                        property.SetValue(this, false);
                    else
                        throw new System.InvalidCastException();
                }
                else
                {
                    property.SetValue(this, typeof(Utils.Cast).
                        GetMethod("StaticCast").
                        MakeGenericMethod(value.GetType())
                        .Invoke(null, new object[1] { value }));
                }
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