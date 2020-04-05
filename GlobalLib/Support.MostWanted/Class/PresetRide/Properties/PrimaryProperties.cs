using GlobalLib.Reflection.Attributes;

namespace GlobalLib.Support.MostWanted.Class
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

        /// <summary>
        /// Represents frontend name of the preset ride.
        /// </summary>
        [AccessModifiable()]
        public override string Frontend { get => base.Frontend; set => base.Frontend = value; }

        /// <summary>
        /// Represents pvehicle name of the preset ride.
        /// </summary>
        [AccessModifiable()]
        public override string Pvehicle { get => base.Pvehicle; set => base.Pvehicle = value; }
    }
}