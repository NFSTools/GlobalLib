namespace GlobalLib.Support.Shared.Class
{
    public partial class Texture : Reflection.Interface.IGetValue, Reflection.Interface.ISetValue
    {
        /// <summary>
        /// Assembles texture header into a byte array.
        /// </summary>
        /// <param name="byteptr_t">Pointer to the tpk texture header data.</param>
        /// <param name="offheader">Current offset in the tpk texture header data.</param>
        /// <param name="offdata">Current offset in the tpk data.</param>
        public virtual unsafe void Assemble(byte* byteptr_t, ref int offheader, ref int offdata) { }
    }
}