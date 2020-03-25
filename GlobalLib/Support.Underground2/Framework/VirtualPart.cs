namespace GlobalLib.Support.Underground2.Framework
{
	public class VirtualPart : Reflection.Interface.IGetValue, Reflection.Interface.ISetValue
	{
        /// <summary>
        /// Returns array of all accessible and modifiable properties and fields.
        /// </summary>
        /// <returns>Array of strings.</returns>
        public string[] GetAccessibles()
        {
            var list = new System.Collections.Generic.List<string>();
            foreach (var property in this.GetType().GetProperties())
                list.Add(property.Name);
            list.Sort();
            return list.ToArray();
        }

        /// <summary>
        /// Returns the value of a field name provided.
        /// </summary>
        /// <param name="PropertyName">Field name to get the value from.</param>
        /// <returns>String value of a field name.</returns>
        public virtual string GetValue(string PropertyName)
        {
            var property = this.GetType().GetProperty(PropertyName);
            return (property == null) ? null : property.GetValue(this).ToString();
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
                property.SetValue(this, Utils.Cast.RuntimeCast(value, property.PropertyType));
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
        /// <param name="error">Error occured in case setting value fails.</param>
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
                property.SetValue(this, Utils.Cast.RuntimeCast(value, property.PropertyType));
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
