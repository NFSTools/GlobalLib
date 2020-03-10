﻿namespace GlobalLib.Support.Underground2.Class
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

        /// <summary>
        /// Represents frontend name of the preset ride.
        /// </summary>
        public override string Frontend { get => Reflection.BaseArguments.NULL; }

        /// <summary>
        /// Represents pvehicle name of the preset ride.
        /// </summary>
        public override string Pvehicle { get => Reflection.BaseArguments.NULL; }

        /// <summary>
        /// Vault memory hash of the frontend value.
        /// </summary>
        public override uint FrontendKey => 0;

        /// <summary>
        /// Vault memory hash of the pvehicle value.
        /// </summary>
        public override uint PvehicleKey => 0;
    }
}