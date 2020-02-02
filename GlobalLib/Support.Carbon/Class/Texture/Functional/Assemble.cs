namespace GlobalLib.Support.Carbon.Class
{
    public partial class Texture : Shared.Class.Texture, Reflection.Interface.ICastable<Texture>
    {
        /// <summary>
        /// Assembles texture header into a byte array.
        /// </summary>
        /// <param name="byteptr_t">Pointer to the tpk texture header data.</param>
        /// <param name="offheader">Current offset in the tpk texture header data.</param>
        /// <param name="offdata">Current offset in the tpk data.</param>
        public override unsafe void Assemble(byte* byteptr_t, ref int offheader, ref int offdata)
        {
            int a1 = this._collection_name.Length; // size of the collection name
            int a2 = 0x5D + a1 - ((1 + a1) % 4); // size of the texture header

            this.Offset = offdata;

            // Write all settings
            *(uint*)(byteptr_t + offheader) = this._cube_environment;
            *(uint*)(byteptr_t + offheader + 0xC) = this.BinKey;
            *(uint*)(byteptr_t + offheader + 0x10) = this._class;
            *(uint*)(byteptr_t + offheader + 0x14) = (uint)this.Offset;
            *(uint*)(byteptr_t + offheader + 0x18) = (uint)this.PaletteOffset;
            *(int*)(byteptr_t + offheader + 0x1C) = this.Size;
            *(int*)(byteptr_t + offheader + 0x20) = this.PaletteSize;
            *(int*)(byteptr_t + offheader + 0x24) = this._area;
            *(short*)(byteptr_t + offheader + 0x28) = this.Width;
            *(short*)(byteptr_t + offheader + 0x2A) = this.Height;
            *(byteptr_t + offheader + 0x2C) = this.Log_2_Width;
            *(byteptr_t + offheader + 0x2D) = this.Log_2_Height;
            *(byteptr_t + offheader + 0x2E) = this._compression;
            *(byteptr_t + offheader + 0x2F) = this._pal_comp;
            *(short*)(byteptr_t + offheader + 0x30) = this._num_palettes;
            *(byteptr_t + offheader + 0x32) = this.Mipmaps;
            *(byteptr_t + offheader + 0x33) = this.TileableUV;
            *(byteptr_t + offheader + 0x34) = this._bias_level;
            *(byteptr_t + offheader + 0x35) = this._rendering_order;
            *(byteptr_t + offheader + 0x36) = this._scroll_type;
            *(byteptr_t + offheader + 0x37) = this._used_flag;
            *(byteptr_t + offheader + 0x38) = this._apply_alpha_sort;
            *(byteptr_t + offheader + 0x39) = this._alpha_usage_type;
            *(byteptr_t + offheader + 0x3A) = this._alpha_blend_type;
            *(byteptr_t + offheader + 0x3B) = this._flags;
            *(byteptr_t + offheader + 0x3C) = this.MipmapBiasType;
            *(byteptr_t + offheader + 0x3D) = this._padding;
            *(short*)(byteptr_t + offheader + 0x3E) = this._scroll_timestep;
            *(short*)(byteptr_t + offheader + 0x40) = this._scroll_speedS;
            *(short*)(byteptr_t + offheader + 0x42) = this._scroll_speedT;
            *(short*)(byteptr_t + offheader + 0x44) = this._offsetS;
            *(short*)(byteptr_t + offheader + 0x46) = this._offsetT;
            *(short*)(byteptr_t + offheader + 0x48) = this._scaleS;
            *(short*)(byteptr_t + offheader + 0x4A) = this._scaleT;
            *(int*)(byteptr_t + offheader + 0x4C) = this._unknown1;
            *(int*)(byteptr_t + offheader + 0x50) = this._unknown2;
            *(int*)(byteptr_t + offheader + 0x54) = this._unknown3;
            *(byteptr_t + offheader + 0x58) = (byte)(a2 - 0x59);

            // Write CollectionName
            for (a1 = 0; a1 < this.CollectionName.Length; ++a1)
                *(byteptr_t + offheader + 0x59 + a1) = (byte)this.CollectionName[a1];

            // Precalculate next offsets
            offheader += a2; // set next header offset
            offdata = (int)this.Offset + this.Size; // set next data offset
            a1 = 0x80 - (offdata % 0x80);
            if (a1 != 0x80)
                offdata += a1;
        }
    }
}