namespace GlobalLib.Support.Underground2.Class
{
    public partial class XenonEffect
    {
        /// <summary>
        /// Assembles xenon effect into a byte array.
        /// </summary>
        /// <returns>Byte array of the xenon effect.</returns>
        public override unsafe byte[] Assemble()
        {
            byte[] result = new byte[0xD0];
            fixed (byte* byteptr_t = &result[0])
            {
                // Write all settings
                *(int*)byteptr_t = _Primary;
                *(int*)(byteptr_t + 0x04) = _Primary;
                *(uint*)(byteptr_t + 0x08) = this.BinKey;
                *(uint*)(byteptr_t + 0x0C) = this.BinKey;
                *(int*)(byteptr_t + 0x10) = _Localizer;
                *(float*)(byteptr_t + 0x40) = this.Matrix_Vector1_X;
                *(float*)(byteptr_t + 0x44) = this.Matrix_Vector1_Y;
                *(float*)(byteptr_t + 0x48) = this.Matrix_Vector1_Z;
                *(float*)(byteptr_t + 0x4C) = this.Matrix_Vector1_W;
                *(float*)(byteptr_t + 0x50) = this.Matrix_Vector2_X;
                *(float*)(byteptr_t + 0x54) = this.Matrix_Vector2_Y;
                *(float*)(byteptr_t + 0x58) = this.Matrix_Vector2_Z;
                *(float*)(byteptr_t + 0x5C) = this.Matrix_Vector2_W;
                *(float*)(byteptr_t + 0x60) = this.Matrix_Vector3_X;
                *(float*)(byteptr_t + 0x64) = this.Matrix_Vector3_Y;
                *(float*)(byteptr_t + 0x68) = this.Matrix_Vector3_Z;
                *(float*)(byteptr_t + 0x6C) = this.Matrix_Vector3_W;
                *(float*)(byteptr_t + 0x70) = this.Matrix_Vector4_X;
                *(float*)(byteptr_t + 0x74) = this.Matrix_Vector4_Y;
                *(float*)(byteptr_t + 0x78) = this.Matrix_Vector4_Z;
                *(float*)(byteptr_t + 0x7C) = this.Matrix_Vector4_W;

                // Write CollectionName
                for (int a1 = 0; a1 < this._collection_name.Length; ++a1)
                    *(byteptr_t + 0x90 + a1) = (byte)this._collection_name[a1];
            }
            return result;
        }
    }
}