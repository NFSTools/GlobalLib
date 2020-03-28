namespace GlobalLib.Support.Shared.Class
{
    public partial class PresetSkin : Reflection.Abstract.Collectable
    {
        #region Private Fields

        private Reflection.Enum.eCarbonPaint _painttype = Reflection.Enum.eCarbonPaint.GLOSS;
        private byte _paintswatch = 1;
        private float _paintsaturation = 0;
        private float _paintbrightness = 0;

        #endregion

        #region Main Properties

        /// <summary>
        /// Collection name of the variable.
        /// </summary>
        public override string CollectionName { get; set; }

        /// <summary>
        /// Binary memory hash of the collection name.
        /// </summary>
        public virtual uint BinKey { get => Utils.Bin.Hash(this.CollectionName); }

        /// <summary>
        /// Vault memory hash of the collection name.
        /// </summary>
        public virtual uint VltKey { get => Utils.Vlt.Hash(this.CollectionName); }

        #endregion

        #region AccessModifiable Properties

        /// <summary>
        /// Paint type value of the preset skin.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        [Reflection.Attributes.StaticModifiable()]
        public Reflection.Enum.eCarbonPaint PaintType
        {
            get => this._painttype;
            set
            {
                if (System.Enum.IsDefined(typeof(Reflection.Enum.eCarbonPaint), value))
                    this._painttype = value;
                else
                    throw new Reflection.Exception.MappingFailException();
            }
        }

        /// <summary>
        /// Gradient color value of the paint of the preset skin. Range: 0-90.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        [Reflection.Attributes.StaticModifiable()]
        public byte PaintSwatch
        {
            get => this._paintswatch;
            set
            {
                if (value > 90)
                    throw new System.ArgumentOutOfRangeException("Value passed should be in range 0 to 90.");
                else
                    this._paintswatch = value;
            }
        }

        /// <summary>
        /// Saturation value of the paint of the preset skin. Range: (float)0-1.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        [Reflection.Attributes.StaticModifiable()]
        public float PaintSaturation
        {
            get => this._paintsaturation;
            set
            {
                if (value > 1 || value < 0)
                    throw new System.ArgumentOutOfRangeException("Value passed should be in range 0 to 1.");
                else
                    this._paintsaturation = value;
            }
        }

        /// <summary>
        /// Brightness value of the paint of the preset skin. Range: (float)0-1.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        [Reflection.Attributes.StaticModifiable()]
        public float PaintBrightness
        {
            get => this._paintbrightness;
            set
            {
                if (value > 1 || value < 0)
                    throw new System.ArgumentOutOfRangeException("Value passed should be in range 0 to 1.");
                else
                    this._paintbrightness = value;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Assembles preset skin into a byte array.
        /// </summary>
        /// <returns>Byte array of the preset skin.</returns>
        public virtual unsafe byte[] Assemble() { return null; }

        /// <summary>
        /// Disassembles preset skin array into separate properties.
        /// </summary>
        /// <param name="byteptr_t">Pointer to the preset skin array.</param>
        protected virtual unsafe void Disassemble(byte* byteptr_t) { }

        /// <summary>
        /// Casts all attributes from this object to another one.
        /// </summary>
        /// <param name="CName">CollectionName of the new created object.</param>
        /// <returns>Memory casted copy of the object.</returns>
        public override Reflection.Abstract.Collectable MemoryCast(string CName)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}