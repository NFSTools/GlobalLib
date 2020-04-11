using GlobalLib.Reflection.Abstract;

namespace GlobalLib.Support.Underground2.Class
{
    public partial class XenonEffect
    {
        /// <summary>
        /// Casts all attributes from this object to another one.
        /// </summary>
        /// <param name="CName">CollectionName of the new created object.</param>
        /// <returns>Memory casted copy of the object.</returns>
        public override Collectable MemoryCast(string CName)
        {
            var result = new XenonEffect(CName, this.Database);

            result.Matrix_Vector1_X = this.Matrix_Vector1_X;
            result.Matrix_Vector1_Y = this.Matrix_Vector1_Y;
            result.Matrix_Vector1_Z = this.Matrix_Vector1_Z;
            result.Matrix_Vector1_W = this.Matrix_Vector1_W;
            result.Matrix_Vector2_X = this.Matrix_Vector2_X;
            result.Matrix_Vector2_Y = this.Matrix_Vector2_Y;
            result.Matrix_Vector2_Z = this.Matrix_Vector2_Z;
            result.Matrix_Vector2_W = this.Matrix_Vector2_W;
            result.Matrix_Vector3_X = this.Matrix_Vector3_X;
            result.Matrix_Vector3_Y = this.Matrix_Vector3_Y;
            result.Matrix_Vector3_Z = this.Matrix_Vector3_Z;
            result.Matrix_Vector3_W = this.Matrix_Vector3_W;
            result.Matrix_Vector4_X = this.Matrix_Vector4_X;
            result.Matrix_Vector4_Y = this.Matrix_Vector4_Y;
            result.Matrix_Vector4_Z = this.Matrix_Vector4_Z;
            result.Matrix_Vector4_W = this.Matrix_Vector4_W;

            return result;
        }
    }
}