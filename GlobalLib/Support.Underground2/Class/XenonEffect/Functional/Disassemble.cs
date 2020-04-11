namespace GlobalLib.Support.Underground2.Class
{
    public partial class XenonEffect
    {
        /// <summary>
        /// Disassembles xenon effect array into separate properties.
        /// </summary>
        /// <param name="byteptr_t">Pointer to the xenon effect array.</param>
        protected override unsafe void Disassemble(byte* byteptr_t)
        {
            this.Matrix_Vector1_X = *(float*)(byteptr_t + 0x40);
            this.Matrix_Vector1_Y = *(float*)(byteptr_t + 0x44);
            this.Matrix_Vector1_Z = *(float*)(byteptr_t + 0x48);
            this.Matrix_Vector1_W = *(float*)(byteptr_t + 0x4C);
            this.Matrix_Vector2_X = *(float*)(byteptr_t + 0x40);
            this.Matrix_Vector2_Y = *(float*)(byteptr_t + 0x44);
            this.Matrix_Vector2_Z = *(float*)(byteptr_t + 0x48);
            this.Matrix_Vector2_W = *(float*)(byteptr_t + 0x4C);
            this.Matrix_Vector3_X = *(float*)(byteptr_t + 0x40);
            this.Matrix_Vector3_Y = *(float*)(byteptr_t + 0x44);
            this.Matrix_Vector3_Z = *(float*)(byteptr_t + 0x48);
            this.Matrix_Vector3_W = *(float*)(byteptr_t + 0x4C);
            this.Matrix_Vector4_X = *(float*)(byteptr_t + 0x40);
            this.Matrix_Vector4_Y = *(float*)(byteptr_t + 0x44);
            this.Matrix_Vector4_Z = *(float*)(byteptr_t + 0x48);
            this.Matrix_Vector4_W = *(float*)(byteptr_t + 0x4C);
        }
    }
}