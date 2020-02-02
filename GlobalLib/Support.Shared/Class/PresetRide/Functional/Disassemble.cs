namespace GlobalLib.Support.Shared.Class
{
    public partial class PresetRide : Reflection.Interface.IGetValue, Reflection.Interface.ISetValue
    {
        /// <summary>
        /// Disassembles preset ride array into separate properties.
        /// </summary>
        /// <param name="byteptr_t">Pointer to the preset ride array.</param>
        protected virtual unsafe void Disassemble(byte* byteptr_t) { }
    }
}