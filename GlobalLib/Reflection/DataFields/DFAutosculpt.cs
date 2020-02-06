namespace GlobalLib.Reflection.DataFields
{
    public static class DFAutosculpt
    {
        public const string AutosculptZone1 = "AutosculptZone1";
        public const string AutosculptZone2 = "AutosculptZone2";
        public const string AutosculptZone3 = "AutosculptZone3";
        public const string AutosculptZone4 = "AutosculptZone4";
        public const string AutosculptZone5 = "AutosculptZone5";
        public const string AutosculptZone6 = "AutosculptZone6";
        public const string AutosculptZone7 = "AutosculptZone7";
        public const string AutosculptZone8 = "AutosculptZone8";
        public const string AutosculptZone9 = "AutosculptZone9";

        public static bool Contains(string field)
        {
            var ThisType = typeof(DFAutosculpt);
            foreach (var ThisProperty in ThisType.GetFields())
            {
                if (ThisProperty.Name == field)
                    return true;
            }
            return false;
        }
    }
}