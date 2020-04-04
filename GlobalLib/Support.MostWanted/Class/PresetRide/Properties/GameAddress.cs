using GlobalLib.Core;



namespace GlobalLib.Support.MostWanted.Class
{
    public partial class PresetRide
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

        public const int MaxCNameLength = 0x1F;
        public const int CNameOffsetAt = 0x28;
        public const int BaseClassSize = 0x290;
    }
}