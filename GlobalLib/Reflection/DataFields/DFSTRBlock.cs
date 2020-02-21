namespace GlobalLib.Reflection.DataFields
{
    public static class DFSTRBlock
    {
        public const string Hash  = "Hash";
        public const string Label = "Label";
        public const string Text  = "Text";

        public static bool Contains(string field)
        {
            var ThisType = typeof(DFSTRBlock);
            foreach (var ThisProperty in ThisType.GetFields())
            {
                if (ThisProperty.Name == field)
                    return true;
            }
            return false;
        }
    }
}