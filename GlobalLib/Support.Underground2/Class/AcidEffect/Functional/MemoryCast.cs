using GlobalLib.Reflection.Abstract;

namespace GlobalLib.Support.Underground2.Class
{
    public partial class AcidEffect
    {
        /// <summary>
        /// Casts all attributes from this object to another one.
        /// </summary>
        /// <param name="CName">CollectionName of the new created object.</param>
        /// <returns>Memory casted copy of the object.</returns>
        public override Collectable MemoryCast(string CName)
        {
            var result = new AcidEffect(CName, this.Database);

            result.ClassKey = this.ClassKey;
            result.Flags = this.Flags;
            result.NumEmitters = this.NumEmitters;
            result.SectionNumber = this.SectionNumber;
            result.LocalWorld_Vec1_X = this.LocalWorld_Vec1_X;
            result.LocalWorld_Vec1_Y = this.LocalWorld_Vec1_Y;
            result.LocalWorld_Vec1_Z = this.LocalWorld_Vec1_Z;
            result.LocalWorld_Vec1_W = this.LocalWorld_Vec1_W;
            result.LocalWorld_Vec2_X = this.LocalWorld_Vec2_X;
            result.LocalWorld_Vec2_Y = this.LocalWorld_Vec2_Y;
            result.LocalWorld_Vec2_Z = this.LocalWorld_Vec2_Z;
            result.LocalWorld_Vec2_W = this.LocalWorld_Vec2_W;
            result.LocalWorld_Vec3_X = this.LocalWorld_Vec3_X;
            result.LocalWorld_Vec3_Y = this.LocalWorld_Vec3_Y;
            result.LocalWorld_Vec3_Z = this.LocalWorld_Vec3_Z;
            result.LocalWorld_Vec3_W = this.LocalWorld_Vec3_W;
            result.LocalWorld_Vec4_X = this.LocalWorld_Vec4_X;
            result.LocalWorld_Vec4_Y = this.LocalWorld_Vec4_Y;
            result.LocalWorld_Vec4_Z = this.LocalWorld_Vec4_Z;
            result.LocalWorld_Vec4_W = this.LocalWorld_Vec4_W;
            result._inheritance_key = this._inheritance_key;
            result.FarClip = this.FarClip;
            result.Intensity = this.Intensity;
            result.LastPositionX = this.LastPositionX;
            result.LastPositionY = this.LastPositionY;
            result.LastPositionZ = this.LastPositionZ;
            result.LastPositionW = this.LastPositionW;
            result.NumZeroParticleFrames = this.NumZeroParticleFrames;
            result.CreationTimeStamp = this.CreationTimeStamp;

            return result;
        }
    }
}