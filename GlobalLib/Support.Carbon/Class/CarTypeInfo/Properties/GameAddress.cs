namespace GlobalLib.Support.Carbon.Class
{
    public partial class CarTypeInfo
    {
        /// <summary>
        /// Game to which the class belongs to.
        /// </summary>
        public override Core.GameINT GameINT { get => Core.GameINT.Carbon; }

        /// <summary>
        /// Game string to which the class belongs to.
        /// </summary>
        public override string GameSTR { get => Core.GameINT.Carbon.ToString(); }

        /// <summary>
        /// Database to which the class belongs to.
        /// </summary>
        public Database.Carbon Database { get; set; }

        public const int MaxCNameLength = 0xD;
        public const int CNameOffsetAt = 0;
        public const int BaseClassSize = 0xD0;
    }
}