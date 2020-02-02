namespace GlobalLib.Support.Shared.Class
{
    public partial class FNGroup
    {
        /// <summary>
        /// Disassembles frontend group array into separate properties.
        /// </summary>
        /// <param name="byteptr_t">Pointer to the frontend group array.</param>
        protected virtual unsafe void Disassemble(byte[] data) { }
    }
}