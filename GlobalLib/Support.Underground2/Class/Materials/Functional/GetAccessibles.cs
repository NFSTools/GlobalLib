namespace GlobalLib.Support.Underground2.Class
{
    public partial class Material : Shared.Class.Material, Reflection.Interface.ICastable<Material>
    {
        /// <summary>
        /// Returns array of all accessible and modifiable properties and fields.
        /// </summary>
        /// <returns>Array of strings.</returns>
        public override string[] GetAccessibles()
        {
            var list = new System.Collections.Generic.List<string>();
            foreach (var property in this.GetType().GetProperties())
            {
                if (System.Attribute.IsDefined(property, typeof(Reflection.Attributes.AccessModifiableAttribute)))
                    list.Add(property.Name);
            }
            list.Sort();
            return list.ToArray();
        }
    }
}