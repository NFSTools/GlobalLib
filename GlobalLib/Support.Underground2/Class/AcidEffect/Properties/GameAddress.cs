using GlobalLib.Core;



namespace GlobalLib.Support.Underground2.Class
{
    public partial class AcidEffect
    {
        /// <summary>
        /// Game to which the class belongs to.
        /// </summary>
        public override GameINT GameINT { get => GameINT.Underground2; }

        /// <summary>
        /// Game string to which the class belongs to.
        /// </summary>
        public override string GameSTR { get => GameINT.Underground2.ToString(); }

        /// <summary>
        /// Database to which the class belongs to.
        /// </summary>
        public Database.Underground2 Database { get; set; }

        public const int MaxCNameLength = 0x3F;
        public const int CNameOffsetAt = 0x90;
        public const int BaseClassSize = 0xD0;
    }
}