namespace GlobalLib.Reflection.DataFields
{
    public static class DFMaterial
    {
        public const string CollectionName         = "CollectionName";
        public const string ShadowOuterRadius      = "ShadowOuterRadius";
        public const string OptimalLightReflection = "OptimalLightReflection";
        public const string Grayscale              = "Grayscale";
        public const string BrightColor1Level      = "BrightColor1Level";
        public const string BrightColor1Red        = "BrightColor1Red";
        public const string BrightColor1Green      = "BrightColor1Green";
        public const string BrightColor1Blue       = "BrightColor1Blue";
        public const string BrightColor2Level      = "BrightColor2Level";
        public const string BrightColor2Red        = "BrightColor2Red";
        public const string BrightColor2Green      = "BrightColor2Green";
        public const string BrightColor2Blue       = "BrightColor2Blue";
        public const string AlphaValue             = "AlphaValue";
        public const string AlphaValue1            = "AlphaValue1";
        public const string AlphaValue2            = "AlphaValue2";
        public const string Reflection1            = "Reflection1";
        public const string Reflection2            = "Reflection2";
        public const string Reflection3            = "Reflection3";
        public const string DisableReflection      = "DisableReflection";
        public const string Unknown1               = "Unknown1";
        public const string Unknown2               = "Unknown2";
        public const string Unknown3               = "Unknown3";
        public const string Unknown4               = "Unknown4";
        public const string Unknown5               = "Unknown5";
        public const string Unknown6               = "Unknown6";
        public const string Unknown7               = "Unknown7";
        public const string Unknown8               = "Unknown7";
        public const string Unknown9               = "Unknown7";
        public const string ShadowLevel            = "ShadowLevel";
        public const string MatteLevel             = "MatteLevel";
        public const string ChromeLevel            = "ChromeLevel";
        public const string ReflectionColorLevel   = "ReflectionColorLevel";
        public const string ReflectionColorRed     = "ReflectionColorRed";
        public const string ReflectionColorGreen   = "ReflectionColorGreen";
        public const string ReflectionColorBlue    = "ReflectionColorBlue";
        public const string StrongerReflection     = "StrongerReflection";
        public const string BlendStrongColors      = "BlendStrongColors";
        public const string DisableStrongColors    = "DisableStrongColors";
        public const string StrongColor1Level      = "StrongColor1Level";
        public const string StrongColor1Red        = "StrongColor1Red";
        public const string StrongColor1Green      = "StrongColor1Green";
        public const string StrongColor1Blue       = "StrongColor1Blue";
        public const string StrongColor2Level      = "StrongColor2Level";
        public const string StrongColor2Red        = "StrongColor2Red";
        public const string StrongColor2Green      = "StrongColor2Green";
        public const string StrongColor2Blue       = "StrongColor2Blue";
        public const string LinearNegative         = "LinearNegative";
        public const string GradientNegative       = "GradientNegative";

        public static bool Contains(string field)
        {
            var ThisType = typeof(DFMaterial);
            foreach (var ThisProperty in ThisType.GetFields())
            {
                if (ThisProperty.Name == field)
                    return true;
            }
            return false;
        }
    }
}