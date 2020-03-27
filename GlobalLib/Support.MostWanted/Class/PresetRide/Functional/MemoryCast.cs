namespace GlobalLib.Support.MostWanted.Class
{
    public partial class PresetRide
    {
        /// <summary>
        /// Casts all attributes from this object to another one.
        /// </summary>
        /// <param name="CName">CollectionName of the new created object.</param>
        /// <returns>Memory casted copy of the object.</returns>
        public override Reflection.Abstract.Collectable MemoryCast(string CName)
        {
            var result = new PresetRide(CName, this.Database);

            result._hood_style = this._hood_style;
            result._is_carbonfibre_hood = this._is_carbonfibre_hood;
            result._spoiler_style = this._spoiler_style;
            result._spoiler_type = this._spoiler_type;
            result._is_carbonfibre_spoiler = this._is_carbonfibre_spoiler;
            result._roofscoop_style = this._roofscoop_style;
            result._is_offset_roofscoop = this._is_offset_roofscoop;
            result._is_dual_roofscoop = this._is_dual_roofscoop;
            result.IsCarbonfibreRoofScoop = this._is_carbonfibre_roofscoop;
            result._rim_brand = this._rim_brand;
            result._rim_style = this._rim_style;
            result._rim_size = this._rim_size;
            result._window_tint_type = this._window_tint_type;
            result._aftermarket_bodykit = this._aftermarket_bodykit;
            result._body_paint = this._body_paint;
            result._rim_paint = this._rim_paint;
            result._vinylname = this._vinylname;
            result._vinylcolor1 = this._vinylcolor1;
            result._vinylcolor2 = this._vinylcolor2;
            result._vinylcolor3 = this._vinylcolor3;
            result._vinylcolor4 = this._vinylcolor4;
            result.MODEL = this.MODEL;
            result.Pvehicle = this.Pvehicle;
            result.Frontend = this.Frontend;

            System.Buffer.BlockCopy(this.data, 0, result.data, 0, this.data.Length);

            return result;
        }
    }
}