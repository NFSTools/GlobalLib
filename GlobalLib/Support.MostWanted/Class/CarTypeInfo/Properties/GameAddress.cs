namespace GlobalLib.Support.MostWanted.Class
{
    public partial class CarTypeInfo
    {
        /// <summary>
        /// Game index to which the class belongs to.
        /// </summary>
        public int GameINT { get => (int)Core.GameINT.MostWanted; }

        /// <summary>
        /// Game string to which the class belongs to.
        /// </summary>
        public string GameSTR { get => Core.GameSTR.MostWanted; }

        /// <summary>
        /// Database to which the class belongs to.
        /// </summary>
        public Database.MostWanted Database { get; set; }

        public const int MaxCNameLength = 0xD;
        public const int CNameOffsetAt = 0;
        public const int BaseClassSize = 0xD0;
    }
}