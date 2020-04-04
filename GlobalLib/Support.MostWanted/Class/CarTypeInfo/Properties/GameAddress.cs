using GlobalLib.Core;



namespace GlobalLib.Support.MostWanted.Class
{
    public partial class CarTypeInfo
    {
        /// <summary>
        /// Game to which the class belongs to.
        /// </summary>
        public override GameINT GameINT { get => GameINT.MostWanted; }

        /// <summary>
        /// Game string to which the class belongs to.
        /// </summary>
        public override string GameSTR { get => GameINT.MostWanted.ToString(); }

        /// <summary>
        /// Database to which the class belongs to.
        /// </summary>
        public Database.MostWanted Database { get; set; }

        public const int MaxCNameLength = 0xD;
        public const int CNameOffsetAt = 0;
        public const int BaseClassSize = 0xD0;
    }
}