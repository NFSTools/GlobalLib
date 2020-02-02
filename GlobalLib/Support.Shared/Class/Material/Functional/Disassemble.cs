namespace GlobalLib.Support.Shared.Class
{
    public partial class Material : Reflection.Interface.IGetValue, Reflection.Interface.ISetValue
    {
        /// <summary>
        /// Disassembles material array into separate properties.
        /// </summary>
        /// <param name="byteptr_t">Pointer to the material array.</param>
        protected virtual unsafe void Disassemble(byte* byteptr_t) { }
    }
}