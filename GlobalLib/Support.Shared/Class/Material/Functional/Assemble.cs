namespace GlobalLib.Support.Shared.Class
{
    public partial class Material : Reflection.Interface.IGetValue, Reflection.Interface.ISetValue
    {
        /// <summary>
        /// Assembles material into a byte array.
        /// </summary>
        /// <returns>Byte array of the material.</returns>
        public virtual unsafe byte[] Assemble() { return null; }
    }
}