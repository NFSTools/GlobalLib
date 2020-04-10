using GlobalLib.Utils;

namespace GlobalLib.Support.Underground1.Class
{
    public partial class Texture
    {
        private uint _class = 0x001A93CF; // default; sometimes 0x6B6D3253

        /// <summary>
        /// DDS data of the texture.
        /// </summary>
        public byte[] Data { get; private set; }

        /// <summary>
        /// Binary memory hash of the collection name.
        /// </summary>
        public override uint BinKey { get; set; }

        /// <summary>
        /// Vault memory hash of the collection name.
        /// </summary>
        public override uint VltKey { get => Vlt.Hash(this._collection_name); }
    }
}