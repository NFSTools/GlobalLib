namespace GlobalLib.Reflection.DataFields
{
    public static class DFCarTypeInfo
    {
        public const string CollectionName        = "CollectionName";
        public const string ManufacturerName      = "ManufacturerName";
        public const string UsageType             = "UsageType";
        public const string MemoryType            = "MemoryType";
        public const string IsSkinnable           = "IsSkinnable";
        public const string DefaultBasePaint      = "DefaultBasePaint";
        public const string Spoiler               = "Spoiler";
        public const string SpoilerAS             = "SpoilerAS";
        public const string CollisionExternalName = "CollisionExternalName";
        public const string CollisionInternalName = "CollisionInternalName";

        public static bool Contains(string field)
        {
            var ThisType = typeof(DFCarTypeInfo);
            foreach (var ThisProperty in ThisType.GetFields())
            {
                if (ThisProperty.Name == field)
                    return true;
            }
            return false;
        }
    }
}