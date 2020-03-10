namespace GlobalLib.Support.Carbon.Class
{
    public partial class Texture
    {
        private byte _compression = Reflection.ID.EAComp.DXT5_08;
        private byte _pal_comp = 0;

        /// <summary>
        /// Compression type value of the texture.
        /// </summary>
        public string Compression
        {
            get => Utils.EA.Comp.GetString(this._compression);
            private set => this._compression = Utils.EA.Comp.GetByte(value);
        }
    }
}