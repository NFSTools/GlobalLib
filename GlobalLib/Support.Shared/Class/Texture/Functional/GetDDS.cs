namespace GlobalLib.Support.Shared.Class
{
    public partial class Texture : Reflection.Interface.IGetValue, Reflection.Interface.ISetValue
    {
        /// <summary>
        /// Gets .dds texture data along with the .dds header.
        /// </summary>
        /// <returns>.dds texture as a byte array.</returns>
        public virtual unsafe byte[] GetDDSArray() { return null; }
    }
}