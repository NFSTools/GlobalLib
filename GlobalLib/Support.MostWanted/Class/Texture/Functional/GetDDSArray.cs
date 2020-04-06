using GlobalLib.Reflection.ID;
using GlobalLib.Utils;
using GlobalLib.Utils.DDS;
using GlobalLib.Utils.EA;
using System;

namespace GlobalLib.Support.MostWanted.Class
{
    public partial class Texture
    {
        /// <summary>
        /// Gets .dds texture data along with the .dds header.
        /// </summary>
        /// <returns>.dds texture as a byte array.</returns>
        public override unsafe byte[] GetDDSArray()
        {
            byte[] data;
            if (this._compression == EAComp.P8_08)
            {
                data = new byte[this.Size * 4 + 0x80];
                var copy = Palette.P8toRGBA(this.Data);
                Buffer.BlockCopy(copy, 0, data, 0x80, copy.Length);
            }
            else
            {
                data = new byte[this.Data.Length + 0x80];
                Buffer.BlockCopy(this.Data, 0, data, 0x80, this.Data.Length);
            }

            // Initialize header first
            var DDSHeader = new DDS_HEADER();
            DDSHeader.dwFlags = DDS_HEADER_FLAGS.TEXTURE; // add texture definition
            DDSHeader.dwFlags += DDS_HEADER_FLAGS.MIPMAP; // add mipmap definition
            if (this._compression == EAComp.RGBA_08 || this._compression == EAComp.P8_08)
                DDSHeader.dwFlags += DDS_HEADER_FLAGS.PITCH; // add pitch for uncompressed
            else
                DDSHeader.dwFlags += DDS_HEADER_FLAGS.LINEARSIZE; // add linearsize for compressed

            DDSHeader.dwHeight = (uint)this.Height;
            DDSHeader.dwWidth = (uint)this.Width;

            DDSHeader.dwDepth = 1; // considering it is not a cubic texture
            DDSHeader.dwMipMapCount = (uint)this.Mipmaps;

            Comp.GetPixelFormat(ref DDSHeader.ddspf, this._compression);
            DDSHeader.dwCaps = DDSCAPS.SURFACE_FLAGS_TEXTURE; // by default is a texture
            DDSHeader.dwCaps += DDSCAPS.SURFACE_FLAGS_MIPMAP; // mipmaps should be included
            DDSHeader.dwPitchOrLinearSize = Comp.PitchLinearSize(this._compression, this.Width, this.Height, DDSHeader.ddspf.dwRGBBitCount);

            // Write header using ptr
            fixed (byte* byteptr_t = &data[0])
            {
                *(uint*)(byteptr_t + 0) = DDS_MAIN.MAGIC;
                *(uint*)(byteptr_t + 4) = DDSHeader.dwSize;
                *(uint*)(byteptr_t + 8) = DDSHeader.dwFlags;
                *(uint*)(byteptr_t + 0xC) = DDSHeader.dwHeight;
                *(uint*)(byteptr_t + 0x10) = DDSHeader.dwWidth;
                *(uint*)(byteptr_t + 0x14) = DDSHeader.dwPitchOrLinearSize;
                *(uint*)(byteptr_t + 0x18) = DDSHeader.dwDepth;
                *(uint*)(byteptr_t + 0x1C) = DDSHeader.dwMipMapCount;
                for (int a1 = 0; a1 < 11; ++a1)
                    *(uint*)(byteptr_t + 0x20 + a1 * 4) = DDSHeader.dwReserved1[a1];
                *(uint*)(byteptr_t + 0x4C) = DDSHeader.ddspf.dwSize;
                *(uint*)(byteptr_t + 0x50) = DDSHeader.ddspf.dwFlags;
                *(uint*)(byteptr_t + 0x54) = DDSHeader.ddspf.dwFourCC;
                *(uint*)(byteptr_t + 0x58) = DDSHeader.ddspf.dwRGBBitCount;
                *(uint*)(byteptr_t + 0x5C) = DDSHeader.ddspf.dwRBitMask;
                *(uint*)(byteptr_t + 0x60) = DDSHeader.ddspf.dwGBitMask;
                *(uint*)(byteptr_t + 0x64) = DDSHeader.ddspf.dwBBitMask;
                *(uint*)(byteptr_t + 0x68) = DDSHeader.ddspf.dwABitMask;
                *(uint*)(byteptr_t + 0x6C) = DDSHeader.dwCaps;
                *(uint*)(byteptr_t + 0x70) = DDSHeader.dwCaps2;
                *(uint*)(byteptr_t + 0x74) = DDSHeader.dwCaps3;
                *(uint*)(byteptr_t + 0x78) = DDSHeader.dwCaps4;
                *(uint*)(byteptr_t + 0x7C) = DDSHeader.dwReserved2;
            }

            return data;
        }
    }
}