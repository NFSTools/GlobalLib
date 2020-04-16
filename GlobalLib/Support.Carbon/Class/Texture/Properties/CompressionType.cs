using GlobalLib.Reflection.ID;
using GlobalLib.Utils.EA;

namespace GlobalLib.Support.Carbon.Class
{
    public partial class Texture
    {
        private byte _compression = EAComp.DXT5_08;
        private byte _pal_comp = 0;

        /// <summary>
        /// Compression type value of the texture.
        /// </summary>
        public string Compression
        {
            get => Comp.GetString(this._compression);
            set => this._compression = Comp.GetByte(value);
        }

        /// <summary>
        /// Gets compression type of the texture.
        /// </summary>
        /// <returns>Compression type as a string.</returns>
        public override string GetCompression() => this.Compression;
    }
}