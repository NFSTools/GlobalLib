namespace GlobalLib.Support.Carbon.Class
{
    public partial class Material : Shared.Class.Material, Reflection.Interface.ICastable<Material>
    {
        /// <summary>
        /// Disassembles material array into separate properties.
        /// </summary>
        /// <param name="byteptr_t">Pointer to the material array.</param>
        protected override unsafe void Disassemble(byte* byteptr_t)
        {
            this._shadow_outer_radius = *(float*)(byteptr_t + 0x5C);
            this._optimal_light_reflection = *(float*)(byteptr_t + 0x60);
            this._unk1 = *(float*)(byteptr_t + 0x64);
            this._grayscale = *(float*)(byteptr_t + 0x68);
            this._brightcolor1_level = *(float*)(byteptr_t + 0x6C);
            this._brightcolor1_red = *(float*)(byteptr_t + 0x70);
            this._brightcolor1_green = *(float*)(byteptr_t + 0x74);
            this._brightcolor1_blue = *(float*)(byteptr_t + 0x78);
            this._brightcolor2_level = *(float*)(byteptr_t + 0x7C);
            this._brightcolor2_red = *(float*)(byteptr_t + 0x80);
            this._brightcolor2_green = *(float*)(byteptr_t + 0x84);
            this._brightcolor2_blue = *(float*)(byteptr_t + 0x88);
            this._transparency1 = *(float*)(byteptr_t + 0x8C);
            this._transparency2 = *(float*)(byteptr_t + 0x90);
            this._disable_reflection = *(float*)(byteptr_t + 0x94);
            this._unk2 = *(float*)(byteptr_t + 0x98);
            this._unk3 = *(float*)(byteptr_t + 0x9C);
            this._unk4 = *(float*)(byteptr_t + 0xA0);
            this._unk5 = *(float*)(byteptr_t + 0xA4);
            this._unk6 = *(float*)(byteptr_t + 0xA8);
            this._unk7 = *(float*)(byteptr_t + 0xAC);
            this._reflectioncolor_level = *(float*)(byteptr_t + 0xB0);
            this._reflectioncolor_red = *(float*)(byteptr_t + 0xB4);
            this._reflectioncolor_green = *(float*)(byteptr_t + 0xB8);
            this._reflectioncolor_blue = *(float*)(byteptr_t + 0xBC);
            this._stronger_reflection = *(float*)(byteptr_t + 0xC0);
            this._blend_strong_colors = *(float*)(byteptr_t + 0xC4);
            this._disable_strong_colors = *(float*)(byteptr_t + 0xC8);
            this._strongcolor1_level = *(float*)(byteptr_t + 0xCC);
            this._strongcolor1_red = *(float*)(byteptr_t + 0xD0);
            this._strongcolor1_green = *(float*)(byteptr_t + 0xD4);
            this._strongcolor1_blue = *(float*)(byteptr_t + 0xD8);
            this._strongcolor2_level = *(float*)(byteptr_t + 0xDC);
            this._strongcolor2_red = *(float*)(byteptr_t + 0xE0);
            this._strongcolor2_green = *(float*)(byteptr_t + 0xE4);
            this._strongcolor2_blue = *(float*)(byteptr_t + 0xE8);
            this._linear_negative = *(float*)(byteptr_t + 0xEC);
            this._gradient_negative = *(float*)(byteptr_t + 0xF0);
        }
    }
}