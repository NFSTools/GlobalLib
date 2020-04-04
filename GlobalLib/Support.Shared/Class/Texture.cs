using System;
using System.Drawing;
using GlobalLib.Core;
using GlobalLib.Utils;
using GlobalLib.Reflection.Enum;
using GlobalLib.Reflection.Abstract;
using GlobalLib.Reflection.Attributes;



namespace GlobalLib.Support.Shared.Class
{
    public class Texture : Collectable
    {
        #region Private Fields

        private short _width = 0;
        private short _height = 0;
        private byte _log_2_width = 0;
        private byte _log_2_height = 0;
        private byte _mipmaps = 0;
        private byte _mipmap_bias_type = 0;
        private byte _tileableuv = 0;

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
        public virtual uint BinKey { get; set; }

        /// <summary>
        /// Vault memory hash of the collection name.
        /// </summary>
        public virtual uint VltKey { get => Vlt.Hash(this.CollectionName); }

        /// <summary>
        /// Represents data offset of the block in Global data.
        /// </summary>
        public int Offset { get; protected set; } = 0;

        /// <summary>
        /// Represents data size of the block in Global data.
        /// </summary>
        public int Size { get; protected set; } = 0;

        /// <summary>
        /// Represents palette offset of the block in Global data.
        /// </summary>
        public int PaletteOffset { get; protected set; } = 0;

        /// <summary>
        /// Represents palette size of the block in Global data.
        /// </summary>
        public int PaletteSize { get; protected set; } = 0;

        #endregion

        #region Public Properties

        /// <summary>
        /// Represents height in pixels of the texture.
        /// </summary>
        public short Width
        {
            get => this._width;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Value passed should be a positive value.");
                else
                {
                    this._width = value;
                    this._log_2_width = (byte)Math.Log(value, 2);
                }
            }
        }

        /// <summary>
        /// Represents height in pixels of the texture.
        /// </summary>
        public short Height
        {
            get => this._height;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Value passed should be a positive value.");
                else
                {
                    this._height = value;
                    this._log_2_height = (byte)Math.Log(value, 2);
                }
            }
        }

        /// <summary>
        /// Represents base 2 value of the width of the texture.
        /// </summary>
        public byte Log_2_Width
        {
            get
            {
                byte b1 = this._log_2_width;
                byte b2 = (byte)Math.Log(this._width, 2);
                if (b1 == b2)
                    return b1;
                else
                {
                    this._log_2_width = b2;
                    return b2;
                }
            }
            protected set => this._log_2_width = value;
        }

        /// <summary>
        /// Represents base 2 value of the height of the texture.
        /// </summary>
        public byte Log_2_Height
        {
            get
            {
                byte b1 = this._log_2_height;
                byte b2 = (byte)Math.Log(this._height, 2);
                if (b1 == b2)
                    return b1;
                else
                {
                    this._log_2_height = b2;
                    return b2;
                }
            }
            protected set => this._log_2_height = value;
        }

        /// <summary>
        /// Represents number of mipmaps in the texture.
        /// </summary>
        public byte Mipmaps
        {
            get => this._mipmaps;
            set
            {
                if (value > 15)
                    throw new ArgumentOutOfRangeException("Value passed should be in range 0 to 15.");
                else
                    this._mipmaps = value;
            }
        }

        /// <summary>
        /// Represents mipmap bias type of the texture.
        /// </summary>
        public byte MipmapBiasType
        {
            get => this._mipmap_bias_type;
            set
            {
                if (Enum.IsDefined(typeof(eTextureMipmapBiasType), (int)value))
                    this._mipmap_bias_type = value;
                else
                    throw new ArgumentOutOfRangeException("Value passed falls out of range of possible values.");
            }
        }

        #endregion

        #region AccessModifiable Properties

        /// <summary>
        /// Represents tileable level of the texture.
        /// </summary>
        [AccessModifiable()]
        public byte TileableUV
        {
            get => this._tileableuv;
            set
            {
                if (value > 3)
                    throw new ArgumentOutOfRangeException("Value passed should be in range 0 to 3.");
                else
                    this._tileableuv = value;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Assembles texture header into a byte array.
        /// </summary>
        /// <param name="byteptr_t">Pointer to the tpk texture header data.</param>
        /// <param name="offheader">Current offset in the tpk texture header data.</param>
        /// <param name="offdata">Current offset in the tpk data.</param>
        public virtual unsafe void Assemble(byte* byteptr_t, ref int offheader, ref int offdata) { }

        /// <summary>
        /// Disassembles texture header array into separate properties.
        /// </summary>
        /// <param name="byteptr_t">Pointer to the texture header array.</param>
        protected virtual unsafe void Disassemble(byte* byteptr_t) { }

        /// <summary>
        /// Gets .dds texture data along with the .dds header.
        /// </summary>
        /// <returns>.dds texture as a byte array.</returns>
        public virtual unsafe byte[] GetDDSArray() { return null; }

        /// <summary>
        /// Gets .png format image of the .dds texture.
        /// </summary>
        /// <returns>.png format image of the .dds texture.</returns>
        public virtual unsafe Image GetImage() { return null; }

        /// <summary>
        /// Initializes all properties of the new texture.
        /// </summary>
        /// <param name="filename">Filename of the .dds texture passed.</param>
        protected virtual unsafe void Initialize(string filename) { }

        /// <summary>
        /// Reads .dds data from the tpk block.
        /// </summary>
        /// <param name="byteptr_t">Pointer to the tpk block.</param>
        /// <param name="offset">Data offset from where to read.</param>
        /// <param name="forced">If forced, ignores internal offset and reads data 
        /// starting at the pointer passed.</param>
        public virtual unsafe void ReadData(byte* byteptr_t, int offset, bool forced) { }

        /// <summary>
        /// Reloads texture properties based on the new texture passed.
        /// </summary>
        /// <param name="filename">Filename of .dds texture passed.</param>
        public virtual unsafe void Reload(string filename)
        {
            this.Initialize(filename);
        }

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