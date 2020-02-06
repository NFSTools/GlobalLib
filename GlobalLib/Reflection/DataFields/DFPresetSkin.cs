namespace GlobalLib.Reflection.DataFields
{
    public static class DFPresetSkin
    {
        public const string CollectionName  = "CollectionName";
        public const string PaintType       = "PaintType";
        public const string PaintSwatch     = "PaintSwatch";
        public const string PaintSaturation = "PaintSaturation";
        public const string PaintBrightness = "PaintBrightness";
        public const string GenericVinyl    = "GenericVinyl";
        public const string VectorVinyl     = "VectorVinyl";
        public const string PositionY       = "PositionY";
        public const string PositionX       = "PositionX";
        public const string Rotation        = "Rotation";
        public const string Skew            = "Skew";
        public const string ScaleY          = "ScaleY";
        public const string ScaleX          = "ScaleX";
        public const string SwatchColor1    = "SwatchColor1";
        public const string Saturation1     = "Saturation1";
        public const string Brightness1     = "Brightness1";
        public const string SwatchColor2    = "SwatchColor2";
        public const string Saturation2     = "Saturation2";
        public const string Brightness2     = "Brightness2";
        public const string SwatchColor3    = "SwatchColor3";
        public const string Saturation3     = "Saturation3";
        public const string Brightness3     = "Brightness3";
        public const string SwatchColor4    = "SwatchColor4";
        public const string Saturation4     = "Saturation4";
        public const string Brightness4     = "Brightness4";

        public static bool Contains(string field)
        {
            var ThisType = typeof(DFPresetSkin);
            foreach (var ThisProperty in ThisType.GetFields())
            {
                if (ThisProperty.Name == field)
                    return true;
            }
            return false;
        }
    }
}