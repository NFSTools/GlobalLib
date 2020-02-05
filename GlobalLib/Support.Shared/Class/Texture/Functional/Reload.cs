namespace GlobalLib.Support.Shared.Class
{
    public partial class Texture : Reflection.Interface.IGetValue, Reflection.Interface.ISetValue
    {
        /// <summary>
        /// Reloads texture properties based on the new texture passed.
        /// </summary>
        /// <param name="filename">Filename of .dds texture passed.</param>
        public virtual unsafe void Reload(string filename)
        {
            this.Initialize(filename);
        }
    }
}