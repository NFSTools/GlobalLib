namespace GlobalLib.Support.Underground2.Class
{
    public partial class Texture : Shared.Class.Texture, Reflection.Interface.ICastable<Texture>
    {
        /// <summary>
        /// Disassembles texture header array into separate properties.
        /// </summary>
        /// <param name="byteptr_t">Pointer to the texture header array.</param>
        protected override unsafe void Disassemble(byte* byteptr_t)
        {
            this._collection_name = Utils.ScriptX.NullTerminatedString(byteptr_t + 0xC , 0x18);

            this.BinKey = *(uint*)(byteptr_t  + 0x24);
            this._class = *(uint*)(byteptr_t  + 0x28);
            this._unknown0 = *(int*)(byteptr_t  + 0x2C);
            this.Offset = *(int*)(byteptr_t  + 0x30);
            this.PaletteOffset = *(int*)(byteptr_t  + 0x34);
            this.Size = *(int*)(byteptr_t  + 0x38);
            this.PaletteSize = *(int*)(byteptr_t  + 0x3C);
            this._area = *(int*)(byteptr_t  + 0x40);
            this.Width = *(short*)(byteptr_t  + 0x44);
            this.Height = *(short*)(byteptr_t  + 0x46);
            this.Log_2_Width = *(byteptr_t  + 0x48);
            this.Log_2_Height = *(byteptr_t  + 0x49);
            this._compression = *(byteptr_t  + 0x4A);
            this._pal_comp = *(byteptr_t  + 0x4B);
            this._num_palettes = *(short*)(byteptr_t  + 0x4C);
            this.Mipmaps = *(byteptr_t  + 0x4E);
            this.TileableUV = *(byteptr_t  + 0x4F);
            this._bias_level = *(byteptr_t  + 0x50);
            this._rendering_order = *(byteptr_t  + 0x51);
            this._scroll_type = *(byteptr_t  + 0x52);
            this._used_flag = *(byteptr_t  + 0x53);
            this._apply_alpha_sort = *(byteptr_t  + 0x54);
            this._alpha_usage_type = *(byteptr_t  + 0x55);
            this._alpha_blend_type = *(byteptr_t  + 0x56);
            this._flags = *(byteptr_t  + 0x57);
            this.MipmapBiasType = *(byteptr_t  + 0x58);
            this._padding = *(byteptr_t  + 0x59);
            this._scroll_timestep = *(short*)(byteptr_t  + 0x5A);
            this._scroll_speedS = *(short*)(byteptr_t  + 0x5C);
            this._scroll_speedT = *(short*)(byteptr_t  + 0x5E);
            this._offsetS = *(short*)(byteptr_t  + 0x60);
            this._offsetT = *(short*)(byteptr_t  + 0x62);
            this._scaleS = *(short*)(byteptr_t  + 0x64);
            this._scaleT = *(short*)(byteptr_t  + 0x66);
            this._unknown1 = *(int*)(byteptr_t  + 0x68);
            this._unknown2 = *(int*)(byteptr_t  + 0x6C);
            this._unknown3 = *(int*)(byteptr_t  + 0x70);
            this._unknown4 = *(int*)(byteptr_t  + 0x74);
            this._unknown5 = *(int*)(byteptr_t  + 0x78);

            // Get compression name
            if (this._compression == Reflection.ID.EAComp.SECRET)
            {
                this._compression = Reflection.ID.EAComp.P8_08;
                this._secretp8 = true;
            }
        }
    }
}