using GlobalLib.Reflection.Abstract;

namespace GlobalLib.Support.Underground1.Class
{
    public partial class Material
    {
        /// <summary>
        /// Casts all attributes from this object to another one.
        /// </summary>
        /// <param name="CName">CollectionName of the new created object.</param>
        /// <returns>Memory casted copy of the object.</returns>
        public override Collectable MemoryCast(string CName)
        {
            var result = new Material(CName, this.Database);

            result._brightcolor1_blue = this._brightcolor1_blue;
            result._brightcolor1_green = this._brightcolor1_green;
            result._brightcolor1_level = this._brightcolor1_level;
            result._brightcolor1_red = this._brightcolor1_red;
            result._brightcolor2_blue = this._brightcolor2_blue;
            result._brightcolor2_green = this._brightcolor2_green;
            result._brightcolor2_level = this._brightcolor2_level;
            result._brightcolor2_red = this._brightcolor2_red;
            result._strongcolor1_blue = this._strongcolor1_blue;
            result._strongcolor1_green = this._strongcolor1_green;
            result._strongcolor1_level = this._strongcolor1_level;
            result._strongcolor1_red = this._strongcolor1_red;
            result._strongcolor2_blue = this._strongcolor2_blue;
            result._strongcolor2_green = this._strongcolor2_green;
            result._strongcolor2_level = this._strongcolor2_level;
            result._strongcolor2_red = this._strongcolor2_red;
            result._strongcolor3_blue = this._strongcolor3_blue;
            result._strongcolor3_green = this._strongcolor3_green;
            result._strongcolor3_level = this._strongcolor3_level;
            result._strongcolor3_red = this._strongcolor3_red;
            result._strongcolor4_blue = this._strongcolor4_blue;
            result._strongcolor4_green = this._strongcolor4_green;
            result._strongcolor4_level = this._strongcolor4_level;
            result._strongcolor4_red = this._strongcolor4_red;
            result._strong_1_to_2_ratio = this._strong_1_to_2_ratio;
            result._strong_3_to_4_ratio = this._strong_3_to_4_ratio;
            result._transparency1 = this._transparency1;
            result._transparency2 = this._transparency2;

            return result;
        }
    }
}