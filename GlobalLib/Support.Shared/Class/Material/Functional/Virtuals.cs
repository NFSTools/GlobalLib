namespace GlobalLib.Support.Shared.Class
{
    public partial class Material : Reflection.Interface.IGetValue, Reflection.Interface.ISetValue
    {
        /// <summary>
        /// Assembles material into a byte array.
        /// </summary>
        /// <returns>Byte array of the material.</returns>
        public virtual unsafe byte[] Assemble() { return null; }

        /// <summary>
        /// Disassembles material array into separate properties.
        /// </summary>
        /// <param name="byteptr_t">Pointer to the material array.</param>
        protected virtual unsafe void Disassemble(byte* byteptr_t) { }

        /// <summary>
        /// Returns array of all accessible and modifiable properties and fields.
        /// </summary>
        /// <returns>Array of strings.</returns>
        public override string[] GetAccessibles()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Returns all enumerable strings of the property.
        /// </summary>
        /// <param name="property">Name of the enumerable property.</param>
        /// <returns>Array of strings.</returns>
        public override string[] GetPropertyEnumerableTypes(string property)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Checks if the property is of enumerable type.
        /// </summary>
        /// <param name="property">Name of the property to check.</param>
        /// <returns>True if property is enum; false otherwise.</returns>
        public override bool OfEnumerableType(string property)
        {
            throw new System.NotImplementedException();
        }
    }
}