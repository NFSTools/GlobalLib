namespace GlobalLib.Support.Underground2.Class
{
    public partial class Texture : Shared.Class.Texture, Reflection.Interface.ICastable<Texture>
    {
        /// <summary>
        /// Initializes all properties of the new texture.
        /// </summary>
        /// <param name="filename">Filename of the .dds texture passed.</param>
        protected override unsafe void Initialize(string filename)
        {
            var data = System.IO.File.ReadAllBytes(filename);
            byte[] cdata;
            fixed (byte* byteptr_t = &data[0])
            {
                this.Height = (short)*(uint*)(byteptr_t + 0xC);
                this.Width = (short)*(uint*)(byteptr_t + 0x10);
                this.Mipmaps = (byte)*(uint*)(byteptr_t + 0x1C);
                if (*(uint*)(byteptr_t + 0x50) == Utils.DDS.DDS_TYPE.RGBA)
                {
                    cdata = Utils.Palette.RGBAtoP8(data);
                    if (cdata == null)
                    {
                        this._compression = Reflection.ID.EAComp.RGBA_08;
                        this._area = this.Width * this.Height * 4;
                        this.Size = data.Length - 0x80;
                        this.PaletteSize = 0;
                        this.Data = new byte[this.Size];
                        System.Buffer.BlockCopy(data, 0, this.Data, 0, this.Size);
                    }
                    else
                    {
                        this._compression = Reflection.ID.EAComp.P8_08;
                        this._area = this.Width * this.Height * 4;
                        this.Size = (data.Length - 0x80) / 4;
                        this.PaletteSize = 0x400;
                        this.Data = new byte[cdata.Length];
                        System.Buffer.BlockCopy(cdata, 0, this.Data, 0, this.Size + this.PaletteSize);
                    }
                }
                else
                {
                    this._compression = Utils.EA.Comp.GetByte(*(uint*)(byteptr_t + 0x54));
                    this.Size = data.Length - 0x80;
                    this._area = Utils.EA.Comp.FlipToBase(this.Size);
                    this.Data = new byte[this.Size];
                    System.Buffer.BlockCopy(data, 0x80, this.Data, 0, this.Size);
                }

                // Default all other values
                this._num_palettes = (short)(this.PaletteSize / 4);
                this.TileableUV = 0;
                this._bias_level = 0;
                this._rendering_order = 5;
                this._scroll_type = 0;
                this._used_flag = 0;
                this._apply_alpha_sort = 0;
                this._alpha_usage_type = (byte)Reflection.Enum.TPK.AlphaUsageType.TEXUSAGE_MODULATED;
                this._alpha_blend_type = (byte)Reflection.Enum.TPK.TextureAlphaBlendType.TEXBLEND_BLEND;
                this._flags = 0;
                this.MipmapBiasType = (byte)Reflection.Enum.TPK.TextureMipmapBiasType.TEXBIAS_DEFAULT;
                this._scroll_timestep = 0;
                this._scroll_speedS = 0;
                this._scroll_speedT = 0;
                this._offsetS = 0;
                this._offsetT = 0x100;
                this._scaleS = 0x100;
                this._scaleT = 0;
            }
        }
    }
}