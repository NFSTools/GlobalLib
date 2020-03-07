namespace GlobalLib.Support.Underground2.Class
{
    public partial class Material : Shared.Class.Material, Reflection.Interface.ICastable<Material>
    {
        /// <summary>
        /// Returns the value of a field name provided.
        /// </summary>
        /// <param name="PropertyName">Field name to get the value from.</param>
        /// <returns>String value of a field name.</returns>
        public override string GetValue(string PropertyName)
        {
            return base.GetValue(PropertyName);
        }
    }
}