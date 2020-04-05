using GlobalLib.Reflection.Abstract;

namespace GlobalLib.Support.Carbon.Class
{
    public partial class PresetSkin
    {
        /// <summary>
        /// Casts all attributes from this object to another one.
        /// </summary>
        /// <param name="CName">CollectionName of the new created object.</param>
        /// <returns>Memory casted copy of the object.</returns>
        public override Collectable MemoryCast(string CName)
        {
            var result = new PresetSkin(CName, this.Database);

            result.PositionY = this.PositionY;
            result.PositionX = this.PositionX;
            result.Rotation = this.Rotation;
            result.Skew = this.Skew;
            result.ScaleY = this.ScaleY;
            result.ScaleX = this.ScaleX;
            result.Saturation1 = this.Saturation1;
            result.Saturation2 = this.Saturation2;
            result.Saturation3 = this.Saturation3;
            result.Saturation4 = this.Saturation4;
            result.Brightness1 = this.Brightness1;
            result.Brightness2 = this.Brightness2;
            result.Brightness3 = this.Brightness3;
            result.Brightness4 = this.Brightness4;
            result._swatch1 = this._swatch1;
            result._swatch2 = this._swatch2;
            result._swatch3 = this._swatch3;
            result._swatch4 = this._swatch4;
            result._genericvinyl = this._genericvinyl;
            result._vectorvinyl = this._vectorvinyl;
            result.PaintSwatch = this.PaintSwatch;
            result.PaintBrightness = this.PaintBrightness;
            result.PaintSaturation = this.PaintSaturation;
            result.PaintType = this.PaintType;
            
            return result;
        }
    }
}