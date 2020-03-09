namespace GlobalLib.Support.Underground2.Class
{
    public partial class Material : Shared.Class.Material, Reflection.Interface.ICastable<Material>
    {
        /// <summary>
        /// Checks if the property is of enumerable type.
        /// </summary>
        /// <param name="property">Name of the property to check.</param>
        /// <returns>True if property is enum; false otherwise.</returns>
        public override bool OfEnumerableType(string property)
        {
            return this.GetType().GetProperty(property).GetType().IsEnum;
        }
    }
}