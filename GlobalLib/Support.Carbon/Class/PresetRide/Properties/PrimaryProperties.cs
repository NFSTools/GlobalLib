namespace GlobalLib.Support.Carbon.Class
{
    public partial class PresetRide
    {
        private byte[] data;
        private uint _Frontend_Hash = 0;
        private uint _Pvehicle_Hash = 0;

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