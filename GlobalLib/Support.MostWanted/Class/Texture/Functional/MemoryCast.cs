namespace GlobalLib.Support.MostWanted.Class
{
    public partial class Texture : Shared.Class.Texture, Reflection.Interface.ICastable<Texture>
    {
        /// <summary>
        /// Casts all attributes from this object to another one.
        /// </summary>
        /// <param name="CName">CollectionName of the new created object.</param>
        /// <returns>Memory casted copy of the object.</returns>
        public Texture MemoryCast(string CName)
        {
            var result = new Texture(CName);

            result._unknown0 = this._unknown0;
            result._unknown1 = this._unknown1;
            result._unknown2 = this._unknown2;
            result._unknown3 = this._unknown3;
            result._unknown4 = this._unknown4;
            result._unknown5 = this._unknown5;
            result._area = this._area;
            result._num_palettes = this._num_palettes;
            result._bias_level = this._bias_level;
            result._rendering_order = this._rendering_order;
            result._used_flag = this._used_flag;
            result._flags = this._flags;
            result._padding = this._padding;
            result._compression = this._compression;
            result._pal_comp = this._pal_comp;
            result._secretp8 = this._secretp8;
            result._offsetS = this._offsetS;
            result._offsetT = this._offsetT;
            result._scaleS = this._scaleS;
            result._scaleT = this._scaleT;
            result._class = this._class;
            result._scroll_type = this._scroll_type;
            result._scroll_timestep = this._scroll_timestep;
            result._scroll_speedS = this._scroll_speedS;
            result._scroll_speedT = this._scroll_speedT;
            result._apply_alpha_sort = this._apply_alpha_sort;
            result._alpha_usage_type = this._alpha_usage_type;
            result._alpha_blend_type = this._alpha_blend_type;
            result.CompVal1 = this.CompVal1;
            result.CompVal2 = this.CompVal2;
            result.CompVal3 = this.CompVal3;
            result.Mipmaps = this.Mipmaps;
            result.MipmapBiasType = this.MipmapBiasType;
            result.Height = this.Height;
            result.Width = this.Width;
            result.TileableUV = this.TileableUV;
            result.Offset = this.Offset;
            result.Size = this.Size;
            result.PaletteOffset = this.PaletteOffset;
            result.PaletteSize = this.PaletteSize;

            result.Data = new byte[this.Data.Length];
            System.Buffer.BlockCopy(this.Data, 0, result.Data, 0, this.Data.Length);

            return result;
        }
    }
}