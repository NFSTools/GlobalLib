using GlobalLib.Reflection.Enum;
using GlobalLib.Reflection.ID;
using GlobalLib.Utils.DDS;
using GlobalLib.Utils.EA;
using System;
using System.IO;

namespace GlobalLib.Support.Carbon.Class
{
    public partial class Texture
    {
        /// <summary>
        /// Initializes all properties of the new texture.
        /// </summary>
        /// <param name="filename">Filename of the .dds texture passed.</param>
        protected override unsafe void Initialize(string filename)
        {
            var data = File.ReadAllBytes(filename);
            fixed (byte* byteptr_t = &data[0])
            {
                this.Size = data.Length - 0x80;
                this.Height = (short)*(uint*)(byteptr_t + 0xC);
                this.Width = (short)*(uint*)(byteptr_t + 0x10);
                this.Mipmaps = (byte)*(uint*)(byteptr_t + 0x1C);
                if (*(uint*)(byteptr_t + 0x50) == DDS_TYPE.RGBA)
                {
                    this._compression = EAComp.RGBA_08;
                    this._area = this.Width * this.Height * 4;
                }
                else
                {
                    this._compression = Comp.GetByte(*(uint*)(byteptr_t + 0x54));
                    this._area = Comp.FlipToBase(this.Size);
                }

                // Default all other values
                this._num_palettes = 0;
                this.TileableUV = 0;
                this._bias_level = 0;
                this._rendering_order = 5;
                this._scroll_type = 0;
                this._used_flag = 0;
                this._apply_alpha_sort = 0;
                this._alpha_usage_type = (byte)eAlphaUsageType.TEXUSAGE_MODULATED;
                this._alpha_blend_type = (byte)eTextureAlphaBlendType.TEXBLEND_BLEND;
                this._flags = 0;
                this.MipmapBiasType = (byte)eTextureMipmapBiasType.TEXBIAS_DEFAULT;
                this._scroll_timestep = 0;
                this._scroll_speedS = 0;
                this._scroll_speedT = 0;
                this._offsetS = 0;
                this._offsetT = 0x100;
                this._scaleS = 0x100;
                this._scaleT = 0;
            }

            // Copy data to the memory
            this.Data = new byte[this.Size];
            Buffer.BlockCopy(data, 0x80, this.Data, 0, this.Size);
        }
    }
}