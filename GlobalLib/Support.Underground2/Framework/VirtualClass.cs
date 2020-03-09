using System;
using System.Reflection;



namespace GlobalLib.Support.Underground2.Framework
{
	public class VirtualClass : Reflection.Interface.IGetValue, Reflection.Interface.ISetValue
	{
        /// <summary>
        /// Returns the value of a field name provided.
        /// </summary>
        /// <param name="PropertyName">Field name to get the value from.</param>
        /// <returns>String value of a field name.</returns>
        public virtual string GetValue(string PropertyName)
        {
            var ThisType = this.GetType();
            foreach (var ThisProperty in ThisType.GetProperties())
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
                var ThisType = this.GetType();
                foreach (var ThisProperty in ThisType.GetProperties())
                {
                    if (ThisProperty.Name == PropertyName)
                    {
                        ThisProperty.SetValue(this, Utils.Cast.RuntimeCast(value, ThisProperty.GetValue(this)));
                        return true;
                    }
                }
                return false;
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
                var ThisType = this.GetType();
                foreach (var ThisProperty in ThisType.GetProperties())
                {
                    if (ThisProperty.Name == PropertyName)
                    {
                        ThisProperty.SetValue(this, Utils.Cast.RuntimeCast(value, ThisProperty.GetValue(this)));
                        return true;
                    }
                }
                error = $"Field named {PropertyName} does not exist.";
                return false;
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
