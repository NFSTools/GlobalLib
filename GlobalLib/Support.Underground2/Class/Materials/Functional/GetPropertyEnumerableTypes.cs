namespace GlobalLib.Support.Underground2.Class
{
    public partial class Material : Shared.Class.Material, Reflection.Interface.ICastable<Material>
    {
        /// <summary>
        /// Returns all enumerable strings of the property.
        /// </summary>
        /// <param name="property">Name of the enumerable property.</param>
        /// <returns>Array of strings.</returns>
        public override string[] GetPropertyEnumerableTypes(string property)
        {
            return this.GetType().GetProperty(property).GetType().GetEnumNames();
        }
    }
}