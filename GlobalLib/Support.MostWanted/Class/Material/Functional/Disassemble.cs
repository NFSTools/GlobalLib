namespace GlobalLib.Support.MostWanted.Class
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
            this._transparency = *(float*)(byteptr_t + 0x58);
            this._reflection1 = *(float*)(byteptr_t + 0x5C);
            this._reflection2 = *(float*)(byteptr_t + 0x60);
            this._reflection3 = *(float*)(byteptr_t + 0x64);
            this._unk1 = *(float*)(byteptr_t + 0x68);
            this._unk2 = *(float*)(byteptr_t + 0x6C);
            this._unk3 = *(float*)(byteptr_t + 0x70);
            this._strongcolor1_level = *(float*)(byteptr_t + 0x74);
            this._strongcolor1_red = *(float*)(byteptr_t + 0x78);
            this._strongcolor1_green = *(float*)(byteptr_t + 0x7C);
            this._strongcolor1_blue = *(float*)(byteptr_t + 0x80);
            this._shadowlevel = *(float*)(byteptr_t + 0x84);
            this._mattelevel = *(float*)(byteptr_t + 0x88);
            this._chromelevel = *(float*)(byteptr_t + 0x8C);
            this._unk4 = *(float*)(byteptr_t + 0x90);
            this._unk5 = *(float*)(byteptr_t + 0x94);
            this._linear_negative = *(float*)(byteptr_t + 0x98);
            this._gradient_negative = *(float*)(byteptr_t + 0x9C);
            this._unk6 = *(float*)(byteptr_t + 0xA0);
            this._unk7 = *(float*)(byteptr_t + 0xA4);
            this._unk8 = *(float*)(byteptr_t + 0xA8);
            this._unk9 = *(float*)(byteptr_t + 0xAC);
        }
    }
}