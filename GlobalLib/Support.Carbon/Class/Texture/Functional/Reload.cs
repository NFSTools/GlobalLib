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
        /// Reloads texture properties based on the new texture passed.
        /// </summary>
        /// <param name="filename">Filename of .dds texture passed.</param>
        public override unsafe void Reload(string filename)
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

                // Default palette
                this._num_palettes = 0;
                this.PaletteOffset = -1;
                this.PaletteSize = 0;
            }

            // Copy data to the memory
            this.Data = new byte[this.Size];
            Buffer.BlockCopy(data, 0x80, this.Data, 0, this.Size);
        }
    }
}