namespace GlobalLib.Support.Underground2.Class
{
    public partial class PresetRide
    {
        private byte[] data;
        private uint _unknown1 = 0;
        private uint _unknown2 = 0;
        private int uversion_ = 2;

        /// <summary>
        /// Provides info on whether this preset ride already exists in Global data.
        /// </summary>
        public bool Exists { get; } = false;

        /// <summary>
        /// Provides info on whether this cartypeinfo was modified.
        /// </summary>
        public bool Modified { get; private set; } = false;
    }
}