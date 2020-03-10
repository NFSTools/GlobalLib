namespace GlobalLib.Support.Underground2.Class
{
    public partial class Material
    {
        /// <summary>
        /// Disassembles material array into separate properties.
        /// </summary>
        /// <param name="byteptr_t">Pointer to the material array.</param>
        protected override unsafe void Disassemble(byte* byteptr_t)
        {
            this._brightcolor1_level = *(float*)(byteptr_t + 0x38);
            this._brightcolor1_red = *(float*)(byteptr_t + 0x3C);
            this._brightcolor1_green = *(float*)(byteptr_t + 0x40);
            this._brightcolor1_blue = *(float*)(byteptr_t + 0x44);
            this._brightcolor2_level = *(float*)(byteptr_t + 0x48);
            this._brightcolor2_red = *(float*)(byteptr_t + 0x4C);
            this._brightcolor2_green = *(float*)(byteptr_t + 0x50);
            this._brightcolor2_blue = *(float*)(byteptr_t + 0x54);
            this._transparency1 = *(float*)(byteptr_t + 0x58);
            this._transparency2 = *(float*)(byteptr_t + 0x5C);
            this._strong_1_to_2_ratio = *(float*)(byteptr_t + 0x60);
            this._strongcolor1_level = *(float*)(byteptr_t + 0x64);
            this._strongcolor1_red = *(float*)(byteptr_t + 0x68);
            this._strongcolor1_green = *(float*)(byteptr_t + 0x6C);
            this._strongcolor1_blue = *(float*)(byteptr_t + 0x70);
            this._strongcolor2_level = *(float*)(byteptr_t + 0x74);
            this._strongcolor2_red = *(float*)(byteptr_t + 0x78);
            this._strongcolor2_green = *(float*)(byteptr_t + 0x7C);
            this._strongcolor2_blue = *(float*)(byteptr_t + 0x80);
            this._strong_3_to_4_ratio = *(float*)(byteptr_t + 0x84);
            this._strongcolor3_level = *(float*)(byteptr_t + 0x88);
            this._strongcolor3_red = *(float*)(byteptr_t + 0x8C);
            this._strongcolor3_green = *(float*)(byteptr_t + 0x90);
            this._strongcolor3_blue = *(float*)(byteptr_t + 0x94);
            this._strongcolor4_level = *(float*)(byteptr_t + 0x98);
            this._strongcolor4_red = *(float*)(byteptr_t + 0x9C);
            this._strongcolor4_green = *(float*)(byteptr_t + 0xA0);
            this._strongcolor4_blue = *(float*)(byteptr_t + 0xA4);
        }
    }
}