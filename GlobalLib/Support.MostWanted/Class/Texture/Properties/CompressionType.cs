using GlobalLib.Reflection.ID;
using GlobalLib.Utils.EA;

namespace GlobalLib.Support.MostWanted.Class
{
    public partial class Texture
    {
        private byte _compression = EAComp.DXT5_08;
        private byte _pal_comp = 0;
        private bool _secretp8 = false; // true of _compression = 0x81 at disassembly

        /// <summary>
        /// Compression type value of the texture.
        /// </summary>
        public string Compression
        {
            get => Comp.GetString(this._compression);
            private set => this._compression = Comp.GetByte(value);
        }

        /// <summary>
        /// Gets compression type of the texture.
        /// </summary>
        /// <returns>Compression type as a string.</returns>
        public override string GetCompression() => this.Compression;

        /// <summary>
        /// Used in TPK compression blocks.
        /// </summary>
        public int CompVal1 { get; set; } = 1;

        /// <summary>
        /// Used in TPK compression blocks.
        /// </summary>
        public int CompVal2 { get; set; } = 5;

        /// <summary>
        /// Used in TPK compression blocks.
        /// </summary>
        public int CompVal3 { get; set; } = 6;
    }
}