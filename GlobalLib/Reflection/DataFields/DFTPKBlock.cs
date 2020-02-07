namespace GlobalLib.Reflection.DataFields
{
    public static class DFTPKBlock
    {
        public const string CollectionName = "CollectionName";
        public const string TileableUV     = "TileableUV";

        public static bool Contains(string field)
        {
            var ThisType = typeof(DFTPKBlock);
            foreach (var ThisProperty in ThisType.GetFields())
            {
                if (ThisProperty.Name == field)
                    return true;
            }
            return false;
        }
    }
}