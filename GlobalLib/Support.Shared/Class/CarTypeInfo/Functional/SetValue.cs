namespace GlobalLib.Support.Shared.Class
{
    public partial class CarTypeInfo : Reflection.Interface.IGetValue, Reflection.Interface.ISetValue
    {
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
                if (PropertyName == Reflection.DataFields.DFCarTypeInfo.UsageType)
                {
                    var usage = (int)System.Enum.Parse(typeof(Reflection.Enum.CarTypeInfo.UsageType), value.ToString());
                    this.UsageType = usage;
                    return true;
                }
                else if (PropertyName == Reflection.DataFields.DFCarTypeInfo.MemoryType)
                {
                    var memory = (uint)System.Enum.Parse(typeof(Reflection.Enum.CarTypeInfo.MemoryType), value.ToString());
                    this.MemoryType = memory;
                    return true;
                }
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
                if (PropertyName == Reflection.DataFields.DFCarTypeInfo.UsageType)
                {
                    var usage = (int)System.Enum.Parse(typeof(Reflection.Enum.CarTypeInfo.UsageType), value.ToString());
                    this.UsageType = usage;
                    return true;
                }
                else if (PropertyName == Reflection.DataFields.DFCarTypeInfo.MemoryType)
                {
                    var memory = (uint)System.Enum.Parse(typeof(Reflection.Enum.CarTypeInfo.MemoryType), value.ToString());
                    this.MemoryType = memory;
                    return true;
                }
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