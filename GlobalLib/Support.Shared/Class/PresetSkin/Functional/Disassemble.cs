namespace GlobalLib.Support.Shared.Class
{
    public partial class PresetSkin : Reflection.Interface.IGetValue, Reflection.Interface.ISetValue
    {
        /// <summary>
        /// Disassembles preset skin array into separate properties.
        /// </summary>
        /// <param name="byteptr_t">Pointer to the preset skin array.</param>
        protected virtual unsafe void Disassemble(byte* byteptr_t) { }
    }
}