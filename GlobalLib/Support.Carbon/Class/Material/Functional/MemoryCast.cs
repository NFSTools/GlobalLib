namespace GlobalLib.Support.Carbon.Class
{
    public partial class Material : Shared.Class.Material, Reflection.Interface.ICastable<Material>
    {
        /// <summary>
        /// Casts all attributes from this object to another one.
        /// </summary>
        /// <param name="CName">CollectionName of the new created object.</param>
        /// <returns>Memory casted copy of the object.</returns>
        public Material MemoryCast(string CName)
        {
            var result = new Material(CName, this.Database);

            result._shadow_outer_radius = this._shadow_outer_radius;
            result._optimal_light_reflection = this._optimal_light_reflection;
            result._disable_reflection = this._disable_reflection;
            result._stronger_reflection = this._stronger_reflection;
            result._blend_strong_colors = this._blend_strong_colors;
            result._disable_strong_colors = this._disable_strong_colors;
            result._strongcolor1_level = this._strongcolor1_level;
            result._strongcolor1_red = this._strongcolor1_red;
            result._strongcolor1_green = this._strongcolor1_green;
            result._strongcolor1_blue = this._strongcolor1_blue;
            result._strongcolor2_level = this._strongcolor2_level;
            result._strongcolor2_red = this._strongcolor2_red;
            result._strongcolor2_green = this._strongcolor2_green;
            result._strongcolor2_blue = this._strongcolor2_blue;
            result._brightcolor2_level = this._brightcolor2_level;
            result._brightcolor2_red = this._brightcolor2_red;
            result._brightcolor2_green = this._brightcolor2_green;
            result._brightcolor2_blue = this._brightcolor2_blue;
            result._brightcolor1_level = this._brightcolor1_level;
            result._brightcolor1_red = this._brightcolor1_red;
            result._brightcolor1_green = this._brightcolor1_green;
            result._brightcolor1_blue = this._brightcolor1_blue;
            result._grayscale = this._grayscale;
            result._linear_negative = this._linear_negative;
            result._gradient_negative = this._gradient_negative;
            result._reflectioncolor_level = this._reflectioncolor_level;
            result._reflectioncolor_red = this._reflectioncolor_red;
            result._reflectioncolor_green = this._reflectioncolor_green;
            result._reflectioncolor_blue = this._reflectioncolor_blue;
            result._transparency1 = this._transparency1;
            result._transparency2 = this._transparency2;
            result._unk1 = this._unk1;
            result._unk2 = this._unk2;
            result._unk3 = this._unk3;
            result._unk4 = this._unk4;
            result._unk5 = this._unk5;
            result._unk6 = this._unk6;
            result._unk7 = this._unk7;

            Core.Map.BinKeys[result.BinKey] = CName;
            return result;
        }
    }
}