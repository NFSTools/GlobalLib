using GlobalLib.Reflection.ID;

namespace GlobalLib.Support.Underground1.Class
{
    public partial class Texture
    {
        /// <summary>
        /// Assembles texture header into a byte array.
        /// </summary>
        /// <param name="byteptr_t">Pointer to the tpk texture header data.</param>
        /// <param name="offheader">Current offset in the tpk texture header data.</param>
        /// <param name="offdata">Current offset in the tpk data.</param>
        public override unsafe void Assemble(byte* byteptr_t, ref int offheader, ref int offdata)
        {
            // Get offset data
            if (this._compression == EAComp.P8_08)
            {
                this.PaletteOffset = offdata;
                this.Offset = offdata + this.PaletteSize;
            }
            else
                this.Offset = offdata;

            // Write CollectionName
            int a3 = (this._collection_name.Length > 0x17) ? 0x17 : this._collection_name.Length;
            for (int a1 = 0; a1 < a3; ++a1)
                *(byteptr_t + offheader + 0xC + a1) = (byte)this._collection_name[a1];

            // Write all settings
            *(uint*)(byteptr_t + offheader + 0x24) = this.BinKey;
            *(uint*)(byteptr_t + offheader + 0x28) = this._class;
            *(int*)(byteptr_t + offheader + 0x2C) = this._unknown0;
            *(uint*)(byteptr_t + offheader + 0x30) = (uint)this.Offset;
            *(uint*)(byteptr_t + offheader + 0x34) = (uint)this.PaletteOffset;
            *(int*)(byteptr_t + offheader + 0x38) = this.Size;
            *(int*)(byteptr_t + offheader + 0x3C) = this.PaletteSize;
            *(int*)(byteptr_t + offheader + 0x40) = this._area;
            *(short*)(byteptr_t + offheader + 0x44) = this.Width;
            *(short*)(byteptr_t + offheader + 0x46) = this.Height;
            *(byteptr_t + offheader + 0x48) = this.Log_2_Width;
            *(byteptr_t + offheader + 0x49) = this.Log_2_Height;
            *(byteptr_t + offheader + 0x4A) = this._compression;
            *(byteptr_t + offheader + 0x4B) = this._pal_comp;
            *(short*)(byteptr_t + offheader + 0x4C) = this._num_palettes;
            *(byteptr_t + offheader + 0x4E) = this.Mipmaps;
            *(byteptr_t + offheader + 0x4F) = this.TileableUV;
            *(byteptr_t + offheader + 0x50) = this._bias_level;
            *(byteptr_t + offheader + 0x51) = this._rendering_order;
            *(byteptr_t + offheader + 0x52) = this._scroll_type;
            *(byteptr_t + offheader + 0x53) = this._used_flag;
            *(byteptr_t + offheader + 0x54) = this._apply_alpha_sort;
            *(byteptr_t + offheader + 0x55) = this._alpha_usage_type;
            *(byteptr_t + offheader + 0x56) = this._alpha_blend_type;
            *(byteptr_t + offheader + 0x57) = this._flags;
            *(byteptr_t + offheader + 0x58) = this.MipmapBiasType;
            *(byteptr_t + offheader + 0x59) = this._padding;
            *(short*)(byteptr_t + offheader + 0x5A) = this._scroll_timestep;
            *(short*)(byteptr_t + offheader + 0x5C) = this._scroll_speedS;
            *(short*)(byteptr_t + offheader + 0x5E) = this._scroll_speedT;
            *(short*)(byteptr_t + offheader + 0x60) = this._offsetS;
            *(short*)(byteptr_t + offheader + 0x62) = this._offsetT;
            *(short*)(byteptr_t + offheader + 0x64) = this._scaleS;
            *(short*)(byteptr_t + offheader + 0x66) = this._scaleT;
            *(int*)(byteptr_t + offheader + 0x68) = this._unknown1;
            *(int*)(byteptr_t + offheader + 0x6C) = this._unknown2;
            *(int*)(byteptr_t + offheader + 0x70) = this._unknown3;
            *(int*)(byteptr_t + offheader + 0x74) = this._unknown4;
            *(int*)(byteptr_t + offheader + 0x78) = this._unknown5;

            // Check secret compression
            if (this._secretp8)
                *(byteptr_t + offheader + 0x4A) = EAComp.SECRET;

            // Precalculate next offsets
            offheader += 0x7C; // set next header offset
            offdata = this.Offset + this.Size; // set next data offset
            int a2 = 0x80 - (offdata % 0x80);
            if (a2 != 0x80)
                offdata += a2;
        }
    }
}