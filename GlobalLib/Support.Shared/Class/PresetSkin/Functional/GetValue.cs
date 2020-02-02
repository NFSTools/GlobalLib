namespace GlobalLib.Support.Shared.Class
{
    public partial class PresetSkin : Reflection.Interface.IGetValue, Reflection.Interface.ISetValue
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
    }
}