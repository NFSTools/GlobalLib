using GlobalLib.Core;

namespace GlobalLib.Support.Underground2.Class
{
    public partial class AcidEffect
    {
        /// <summary>
        /// Disassembles acid effect array into separate properties.
        /// </summary>
        /// <param name="byteptr_t">Pointer to the acid effect array.</param>
        protected override unsafe void Disassemble(byte* byteptr_t)
        {
            this.ClassKey = *(uint*)(byteptr_t + 0x10);
            this.Flags = *(uint*)(byteptr_t + 0x18);
            this.NumEmitters = *(ushort*)(byteptr_t + 0x1C);
            this.SectionNumber = *(ushort*)(byteptr_t + 0x1E);
            this.LocalWorld_Vec1_X = *(float*)(byteptr_t + 0x20);
            this.LocalWorld_Vec1_Y = *(float*)(byteptr_t + 0x24);
            this.LocalWorld_Vec1_Z = *(float*)(byteptr_t + 0x28);
            this.LocalWorld_Vec1_W = *(float*)(byteptr_t + 0x2C);
            this.LocalWorld_Vec2_X = *(float*)(byteptr_t + 0x30);
            this.LocalWorld_Vec2_Y = *(float*)(byteptr_t + 0x34);
            this.LocalWorld_Vec2_Z = *(float*)(byteptr_t + 0x38);
            this.LocalWorld_Vec2_W = *(float*)(byteptr_t + 0x3C);
            this.LocalWorld_Vec3_X = *(float*)(byteptr_t + 0x40);
            this.LocalWorld_Vec3_Y = *(float*)(byteptr_t + 0x44);
            this.LocalWorld_Vec3_Z = *(float*)(byteptr_t + 0x48);
            this.LocalWorld_Vec3_W = *(float*)(byteptr_t + 0x4C);
            this.LocalWorld_Vec4_X = *(float*)(byteptr_t + 0x50);
            this.LocalWorld_Vec4_Y = *(float*)(byteptr_t + 0x54);
            this.LocalWorld_Vec4_Z = *(float*)(byteptr_t + 0x58);
            this.LocalWorld_Vec4_W = *(float*)(byteptr_t + 0x5C);

            uint key = *(uint*)(byteptr_t + 0x60);
            this._inheritance_key = Map.Lookup(key, true) ?? $"0x{key:X8}";

            this.FarClip = *(float*)(byteptr_t + 0x64);
            this.Intensity = *(float*)(byteptr_t + 0x68);
            this.LastPositionX = *(float*)(byteptr_t + 0x70);
            this.LastPositionY = *(float*)(byteptr_t + 0x74);
            this.LastPositionZ = *(float*)(byteptr_t + 0x78);
            this.LastPositionW = *(float*)(byteptr_t + 0x7C);
            this.NumZeroParticleFrames = *(uint*)(byteptr_t + 0x84);
            this.CreationTimeStamp = *(uint*)(byteptr_t + 0x88);
        }
    }
}