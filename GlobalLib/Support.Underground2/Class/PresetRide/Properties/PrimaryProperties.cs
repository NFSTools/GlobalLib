namespace GlobalLib.Support.Underground2.Class
{
    public partial class PresetRide : Shared.Class.PresetRide, Reflection.Interface.ICastable<PresetRide>
    {
        private byte[] data;
        private int uversion = 2;

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