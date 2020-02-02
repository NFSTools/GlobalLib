namespace GlobalLib.Support.Shared.Class
{
    public partial class Texture : Reflection.Interface.IGetValue, Reflection.Interface.ISetValue
    {
        /// <summary>
        /// Initializes all properties of the new texture.
        /// </summary>
        /// <param name="filename">Filename of the .dds texture passed.</param>
        protected virtual unsafe void Initialize(string filename) { }
    }
}