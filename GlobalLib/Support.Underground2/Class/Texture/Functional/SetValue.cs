namespace GlobalLib.Support.Underground2.Class
{
    public partial class Texture : Shared.Class.Texture, Reflection.Interface.ICastable<Texture>
    {
        /// <summary>
        /// Sets value at a field specified.
        /// </summary>
        /// <param name="PropertyName">Name of the field to be modified.</param>
        /// <param name="value">Value to be set at the field specified.</param>
        public override bool SetValue(string PropertyName, object value)
        {
            return base.SetValue(PropertyName, value);
        }
    }
}