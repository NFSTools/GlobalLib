using GlobalLib.Utils;

namespace GlobalLib.Support.Underground2.Class
{
    public partial class AcidEffect
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
                *(int*)byteptr_t = _Localizer;
                *(int*)(byteptr_t + 0x04) = _Localizer;
                *(uint*)(byteptr_t + 0x08) = this.BinKey;
                *(uint*)(byteptr_t + 0x0C) = this.BinKey;
                *(uint*)(byteptr_t + 0x10) = this.ClassKey;
                *(uint*)(byteptr_t + 0x18) = this.Flags;
                *(ushort*)(byteptr_t + 0x1C) = this.NumEmitters;
                *(ushort*)(byteptr_t + 0x1E) = this.SectionNumber;
                *(float*)(byteptr_t + 0x20) = this.LocalWorld_Vec1_X;
                *(float*)(byteptr_t + 0x24) = this.LocalWorld_Vec1_Y;
                *(float*)(byteptr_t + 0x28) = this.LocalWorld_Vec1_Z;
                *(float*)(byteptr_t + 0x2C) = this.LocalWorld_Vec1_W;
                *(float*)(byteptr_t + 0x30) = this.LocalWorld_Vec2_X;
                *(float*)(byteptr_t + 0x34) = this.LocalWorld_Vec2_Y;
                *(float*)(byteptr_t + 0x38) = this.LocalWorld_Vec2_Z;
                *(float*)(byteptr_t + 0x3C) = this.LocalWorld_Vec2_W;
                *(float*)(byteptr_t + 0x40) = this.LocalWorld_Vec3_X;
                *(float*)(byteptr_t + 0x44) = this.LocalWorld_Vec3_Y;
                *(float*)(byteptr_t + 0x48) = this.LocalWorld_Vec3_Z;
                *(float*)(byteptr_t + 0x4C) = this.LocalWorld_Vec3_W;
                *(float*)(byteptr_t + 0x50) = this.LocalWorld_Vec4_X;
                *(float*)(byteptr_t + 0x54) = this.LocalWorld_Vec4_Y;
                *(float*)(byteptr_t + 0x58) = this.LocalWorld_Vec4_Z;
                *(float*)(byteptr_t + 0x5C) = this.LocalWorld_Vec4_W;
                *(uint*)(byteptr_t + 0x60) = Bin.SmartHash(this._inheritance_key);
                *(float*)(byteptr_t + 0x64) = this.FarClip;
                *(float*)(byteptr_t + 0x68) = this.Intensity;
                *(float*)(byteptr_t + 0x70) = this.LastPositionX;
                *(float*)(byteptr_t + 0x74) = this.LastPositionY;
                *(float*)(byteptr_t + 0x78) = this.LastPositionZ;
                *(float*)(byteptr_t + 0x7C) = this.LastPositionW;
                *(uint*)(byteptr_t + 0x84) = this.NumZeroParticleFrames;
                *(uint*)(byteptr_t + 0x88) = this.CreationTimeStamp;

                // Write CollectionName
                for (int a1 = 0; a1 < this._collection_name.Length; ++a1)
                    *(byteptr_t + 0x90 + a1) = (byte)this._collection_name[a1];
            }
            return result;
        }
    }
}