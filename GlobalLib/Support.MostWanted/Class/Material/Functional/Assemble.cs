namespace GlobalLib.Support.MostWanted.Class
{
    public partial class Material
    {
        /// <summary>
        /// Assembles material into a byte array.
        /// </summary>
        /// <returns>Byte array of the material.</returns>
        public override unsafe byte[] Assemble()
        {
            byte[] result = new byte[0xB0];
            fixed (byte* byteptr_t = &result[0])
            {
                // Write header of the material
                *(uint*)(byteptr_t + 0) = this.ID;
                *(int*)(byteptr_t + 4) = this.Size;
                *(int*)(byteptr_t + 8) = _Unknown1;
                *(int*)(byteptr_t + 0xC) = _Localizer;
                *(int*)(byteptr_t + 0x10) = _Localizer;
                *(uint*)(byteptr_t + 0x14) = this.BinKey;
                *(int*)(byteptr_t + 0x18) = _Localizer;

                // Write CollectionName
                for (int a1 = 0; a1 < this.CollectionName.Length; ++a1)
                    *(byteptr_t + 0x1C + a1) = (byte)this.CollectionName[a1];

                // Write all settings
                *(float*)(byteptr_t + 0x38) = this._brightcolor1_level;
                *(float*)(byteptr_t + 0x3C) = this._brightcolor1_red;
                *(float*)(byteptr_t + 0x40) = this._brightcolor1_green;
                *(float*)(byteptr_t + 0x44) = this._brightcolor1_blue;
                *(float*)(byteptr_t + 0x48) = this._brightcolor2_level;
                *(float*)(byteptr_t + 0x4C) = this._brightcolor2_red;
                *(float*)(byteptr_t + 0x50) = this._brightcolor2_green;
                *(float*)(byteptr_t + 0x54) = this._brightcolor2_blue;
                *(float*)(byteptr_t + 0x58) = this._transparency;
                *(float*)(byteptr_t + 0x5C) = this._reflection1;
                *(float*)(byteptr_t + 0x60) = this._reflection2;
                *(float*)(byteptr_t + 0x64) = this._reflection3;
                *(float*)(byteptr_t + 0x68) = this._unk1;
                *(float*)(byteptr_t + 0x6C) = this._unk2;
                *(float*)(byteptr_t + 0x70) = this._unk3;
                *(float*)(byteptr_t + 0x74) = this._strongcolor1_level;
                *(float*)(byteptr_t + 0x78) = this._strongcolor1_red;
                *(float*)(byteptr_t + 0x7C) = this._strongcolor1_green;
                *(float*)(byteptr_t + 0x80) = this._strongcolor1_blue;
                *(float*)(byteptr_t + 0x84) = this._shadowlevel;
                *(float*)(byteptr_t + 0x88) = this._mattelevel;
                *(float*)(byteptr_t + 0x8C) = this._chromelevel;
                *(float*)(byteptr_t + 0x90) = this._unk4;
                *(float*)(byteptr_t + 0x94) = this._unk5;
                *(float*)(byteptr_t + 0x98) = this._linear_negative;
                *(float*)(byteptr_t + 0x9C) = this._gradient_negative;
                *(float*)(byteptr_t + 0xA0) = this._unk6;
                *(float*)(byteptr_t + 0xA4) = this._unk7;
                *(float*)(byteptr_t + 0xA8) = this._unk8;
                *(float*)(byteptr_t + 0xAC) = this._unk9;
            }
            return result;
        }
    }
}