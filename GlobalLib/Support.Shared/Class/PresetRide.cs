using System;
using GlobalLib.Core;
using GlobalLib.Utils;
using GlobalLib.Reflection.Abstract;
using GlobalLib.Reflection.Attributes;
using GlobalLib.Support.Shared.Parts.PresetParts;



namespace GlobalLib.Support.Shared.Class
{
    public class PresetRide : Collectable
    {
        #region Private Fields

        private string _model = "SUPRA";
        private string _frontend = "supra";
        private string _pvehicle = "supra";

        #endregion

        #region Main Properties

        /// <summary>
        /// Collection name of the variable.
        /// </summary>
        public override string CollectionName { get; set; }

        /// <summary>
        /// Game to which the class belongs to.
        /// </summary>
        public override GameINT GameINT { get => GameINT.None; }

        /// <summary>
        /// Game string to which the class belongs to.
        /// </summary>
        public override string GameSTR { get => GameINT.None.ToString(); }

        /// <summary>
        /// Binary memory hash of the collection name.
        /// </summary>
        public virtual uint BinKey { get => Bin.Hash(this.CollectionName); }

        /// <summary>
        /// Vault memory hash of the collection name.
        /// </summary>
        public virtual uint VltKey { get => Vlt.Hash(this.CollectionName); }

        /// <summary>
        /// Vault memory hash of the frontend value.
        /// </summary>
        public virtual uint FrontendKey { get => Vlt.Hash(this._frontend); }

        /// <summary>
        /// Vault memory hash of the pvehicle value.
        /// </summary>
        public virtual uint PvehicleKey { get => Vlt.Hash(this._pvehicle); }

        /// <summary>
        /// Original model name of the preset ride.
        /// </summary>
        public string OriginalModel { get; protected set; }

        #endregion

        #region AccessModifiable Properties

        /// <summary>
        /// Represents model of the preset ride.
        /// </summary>
        [AccessModifiable()]
        public string MODEL
        {
            get => this._model;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("This value cannot be left empty.");
                else
                    this._model = value;
            }
        }

        /// <summary>
        /// Represents frontend name of the preset ride.
        /// </summary>
        public virtual string Frontend
        {
            get => this._frontend;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("This value cannot be left empty.");
                this._frontend = value;
            }
        }

        /// <summary>
        /// Represents pvehicle name of the preset ride.
        /// </summary>
        public virtual string Pvehicle
        {
            get => this._pvehicle;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("This value cannot be left empty.");
                this._pvehicle = value;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Assembles preset ride into a byte array.
        /// </summary>
        /// <returns>Byte array of the preset ride.</returns>
        public virtual unsafe byte[] Assemble() { return null; }

        /// <summary>
        /// Disassembles preset ride array into separate properties.
        /// </summary>
        /// <param name="byteptr_t">Pointer to the preset ride array.</param>
        protected virtual unsafe void Disassemble(byte* byteptr_t) { }

        /// <summary>
        /// Converts all preset parts into binary memory keys.
        /// </summary>
        /// <param name="parts">PresetParts concatenator class of all preset ride's parts.</param>
        /// <returns>Sorted array of all preset parts hashes.</returns>
        protected virtual unsafe uint[] StringToKey(Concatenator parts) { return null; }

        /// <summary>
        /// Casts all attributes from this object to another one.
        /// </summary>
        /// <param name="CName">CollectionName of the new created object.</param>
        /// <returns>Memory casted copy of the object.</returns>
        public override Collectable MemoryCast(string CName)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}