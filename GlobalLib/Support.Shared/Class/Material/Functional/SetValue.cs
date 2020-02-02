namespace GlobalLib.Support.Shared.Class
{
    public partial class Material : Reflection.Interface.IGetValue, Reflection.Interface.ISetValue
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
                if (Core.Process.MessageShow)
                    System.Windows.Forms.MessageBox.Show(e.Message);
                else
                    System.Console.WriteLine($"{e.Message}");
                return false;
            }
        }
    }
}