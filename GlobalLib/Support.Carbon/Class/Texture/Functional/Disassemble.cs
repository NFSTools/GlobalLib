namespace GlobalLib.Support.Carbon.Class
{
    public partial class Texture : Shared.Class.Texture, Reflection.Interface.ICastable<Texture>
    {
        /// <summary>
        /// Disassembles texture header array into separate properties.
        /// </summary>
        /// <param name="byteptr_t">Pointer to the texture header array.</param>
        protected override unsafe void Disassemble(byte* byteptr_t)
        {
            this._cube_environment = *(uint*)(byteptr_t + this._located_at);
            this.BinKey = *(uint*)(byteptr_t + this._located_at + 0xC);
            this._class = *(uint*)(byteptr_t + this._located_at + 0x10);
            this.Offset = *(int*)(byteptr_t + this._located_at + 0x14);
            this.PaletteOffset = *(int*)(byteptr_t + this._located_at + 0x18);
            this.Size = *(int*)(byteptr_t + this._located_at + 0x1C);
            this.PaletteSize = *(int*)(byteptr_t + this._located_at + 0x20);
            this._area = *(int*)(byteptr_t + this._located_at + 0x24);
            this.Width = *(short*)(byteptr_t + this._located_at + 0x28);
            this.Height = *(short*)(byteptr_t + this._located_at + 0x2A);
            this.Log_2_Width = *(byteptr_t + this._located_at + 0x2C);
            this.Log_2_Height = *(byteptr_t + this._located_at + 0x2D);
            this._compression = *(byteptr_t + this._located_at + 0x2E);
            this._pal_comp = *(byteptr_t + this._located_at + 0x2F);
            this._num_palettes = *(short*)(byteptr_t + this._located_at + 0x30);
            this.Mipmaps = *(byteptr_t + this._located_at + 0x32);
            this.TileableUV = *(byteptr_t + this._located_at + 0x33);
            this._bias_level = *(byteptr_t + this._located_at + 0x34);
            this._rendering_order = *(byteptr_t + this._located_at + 0x35);
            this._scroll_type = *(byteptr_t + this._located_at + 0x36);
            this._used_flag = *(byteptr_t + this._located_at + 0x37);
            this._apply_alpha_sort = *(byteptr_t + this._located_at + 0x38);
            this._alpha_usage_type = *(byteptr_t + this._located_at + 0x39);
            this._alpha_blend_type = *(byteptr_t + this._located_at + 0x3A);
            this._flags = *(byteptr_t + this._located_at + 0x3B);
            this.MipmapBiasType = *(byteptr_t + this._located_at + 0x3C);
            this._padding = *(byteptr_t + this._located_at + 0x3D);
            this._scroll_timestep = *(short*)(byteptr_t + this._located_at + 0x3E);
            this._scroll_speedS = *(short*)(byteptr_t + this._located_at + 0x40);
            this._scroll_speedT = *(short*)(byteptr_t + this._located_at + 0x42);
            this._offsetS = *(short*)(byteptr_t + this._located_at + 0x44);
            this._offsetT = *(short*)(byteptr_t + this._located_at + 0x46);
            this._scaleS = *(short*)(byteptr_t + this._located_at + 0x48);
            this._scaleT = *(short*)(byteptr_t + this._located_at + 0x4A);
            this._unknown1 = *(int*)(byteptr_t + this._located_at + 0x4C);
            this._unknown2 = *(int*)(byteptr_t + this._located_at + 0x50);
            this._unknown3 = *(int*)(byteptr_t + this._located_at + 0x54);

            // Get texture name
            for (byte i = 0; i < *(byteptr_t + 0x58); ++i)
            {
                if (0x59 + i > this._size_of_block) break; // do not run ahead of ending
                if (*(byteptr_t + this._located_at + 0x59 + i) == 0) break; // skip null termination
                this._collection_name += ((char)*(byteptr_t + this._located_at + 0x59 + i)).ToString();
            }
        }
    }
}