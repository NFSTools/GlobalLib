namespace GlobalLib.Support.Carbon.Class
{
    public partial class PresetSkin : Shared.Class.PresetSkin, Reflection.Interface.ICastable<PresetSkin>
    {
        /// <summary>
        /// Casts all attributes from this object to another one.
        /// </summary>
        /// <param name="CName">CollectionName of the new created object.</param>
        /// <returns>Memory casted copy of the object.</returns>
        public PresetSkin MemoryCast(string CName)
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
            result.SwatchColor1 = this.SwatchColor1;
            result.SwatchColor2 = this.SwatchColor2;
            result.SwatchColor3 = this.SwatchColor3;
            result.SwatchColor4 = this.SwatchColor4;
            result.GenericVinyl = this.GenericVinyl;
            result.VectorVinyl = this.VectorVinyl;
            result.PaintSwatch = this.PaintSwatch;
            result.PaintBrightness = this.PaintBrightness;
            result.PaintSaturation = this.PaintSaturation;
            result.PaintType = this.PaintType;

            Core.Map.BinKeys[result.BinKey] = CName;
            return result;
        }
    }
}