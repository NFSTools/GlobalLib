namespace GlobalLib.Support.MostWanted.Class
{
    public partial class Material
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

        public const int MaxCNameLength = 0x1B;
        public const int CNameOffsetAt = 0x1C;
        public const int BaseClassSize = 0xB0;
    }
}