namespace GlobalLib.Support.Underground2.Class
{
    public partial class Texture : Shared.Class.Texture, Reflection.Interface.ICastable<Texture>
    {
        private byte _compression = Reflection.ID.EAComp.DXT5_08;
        private byte _pal_comp = 0;
        private bool _secretp8 = false; // true of _compression = 0x81 at disassembly

        /// <summary>
        /// Compression type value of the texture.
        /// </summary>
        public string Compression
        {
            get => Utils.EA.Comp.GetString(this._compression);
            private set => this._compression = Utils.EA.Comp.GetByte(value);
        }

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