﻿namespace GlobalLib.Support.Shared.Class
{
    public partial class PresetRide : Reflection.Interface.IGetValue, Reflection.Interface.ISetValue
    {
        /// <summary>
        /// Binary memory hash of the collection name.
        /// </summary>
        public uint BinKey { get => Utils.Bin.Hash(this._collection_name); }

        /// <summary>
        /// Vault memory hash of the collection name.
        /// </summary>
        public uint VltKey { get => Utils.Vlt.Hash(this._collection_name); }

        /// <summary>
        /// Vault memory hash of the frontend value.
        /// </summary>
        public uint FrontendKey { get => Utils.Vlt.Hash(this._frontend); }

        /// <summary>
        /// Vault memory hash of the pvehicle value.
        /// </summary>
        public uint PvehicleKey { get => Utils.Vlt.Hash(this._pvehicle); }

        /// <summary>
        /// Original model name of the preset ride.
        /// </summary>
        public string OriginalModel { get; protected set; }
    }
}
