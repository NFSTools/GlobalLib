namespace GlobalLib.Support.Shared.Class
{
    public partial class CarTypeInfo
    {
        /// <summary>
        /// Disassembles cartypeinfo array into separate properties.
        /// </summary>
        /// <param name="byteptr_t">Pointer to the cartypeinfo array.</param>
        protected virtual unsafe void Disassemble(byte* byteptr_t) { }
    }
}