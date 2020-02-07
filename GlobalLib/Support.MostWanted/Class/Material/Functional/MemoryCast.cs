namespace GlobalLib.Support.MostWanted.Class
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

            result._brightcolor1_level = this._brightcolor1_level;
            result._brightcolor1_red = this._brightcolor1_red;
            result._brightcolor1_green = this._brightcolor1_green;
            result._brightcolor1_blue = this._brightcolor1_blue;
            result._brightcolor2_level = this._brightcolor2_level;
            result._brightcolor2_red = this._brightcolor2_red;
            result._brightcolor2_green = this._brightcolor2_green;
            result._brightcolor2_blue = this._brightcolor2_blue;
            result._linear_negative = this._linear_negative;
            result._gradient_negative = this._gradient_negative;
            result._shadowlevel = this._shadowlevel;
            result._mattelevel = this._mattelevel;
            result._chromelevel = this._chromelevel;
            result._reflection1 = this._reflection1;
            result._reflection2 = this._reflection2;
            result._reflection3 = this._reflection3;
            result._strongcolor1_level = this._strongcolor1_level;
            result._strongcolor1_red = this._strongcolor1_red;
            result._strongcolor1_green = this._strongcolor1_green;
            result._strongcolor1_blue = this._strongcolor1_blue;
            result._transparency = this._transparency;
            result._unk1 = this._unk1;
            result._unk2 = this._unk2;
            result._unk3 = this._unk3;
            result._unk4 = this._unk4;
            result._unk5 = this._unk5;
            result._unk6 = this._unk6;
            result._unk7 = this._unk7;
            result._unk8 = this._unk8;
            result._unk9 = this._unk9;

            Core.Map.BinKeys[this.BinKey] = CName;
            return result;
        }
    }
}