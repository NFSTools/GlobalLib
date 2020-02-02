namespace GlobalLib.Support.Shared.Class
{
    public partial class Texture : Reflection.Interface.IGetValue, Reflection.Interface.ISetValue
    {
        private byte _mipmaps = 0;
        private byte _mipmap_bias_type = 0;

        /// <summary>
        /// Represents number of mipmaps in the texture.
        /// </summary>
        public byte Mipmaps
        {
            get => this._mipmaps;
            set
            {
                if (value > 15)
                    throw new System.ArgumentOutOfRangeException();
                else
                    this._mipmaps = value;
            }
        }

        /// <summary>
        /// Represents mipmap bias type of the texture.
        /// </summary>
        public byte MipmapBiasType
        {
            get => this._mipmap_bias_type;
            set
            {
                if (System.Enum.IsDefined(typeof(Reflection.Enum.TPK.TextureMipmapBiasType), (int)value))
                    this._mipmap_bias_type = value;
                else
                    throw new System.ArgumentOutOfRangeException();
            }
        }
    }
}