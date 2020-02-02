namespace GlobalLib.Support.Shared.Class
{
    public partial class Texture : Reflection.Interface.IGetValue, Reflection.Interface.ISetValue
    {
        /// <summary>
        /// Gets .png format image of the .dds texture.
        /// </summary>
        /// <returns>.png format image of the .dds texture.</returns>
        public virtual unsafe System.Drawing.Image GetImage() { return null; }
    }
}