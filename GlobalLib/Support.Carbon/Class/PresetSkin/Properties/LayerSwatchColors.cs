﻿namespace GlobalLib.Support.Carbon.Class
{
    public partial class PresetSkin
    {
        private byte _swatch1 = 0;
        private byte _swatch2 = 0;
        private byte _swatch3 = 0;
        private byte _swatch4 = 0;

        /// <summary>
        /// Swatch color value of the first color of the vector vinyl of the preset skin.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        [Reflection.Attributes.StaticModifiable()]
        public byte SwatchColor1
        {
            get => this._swatch1;
            set
            {
                if (value > 90)
                    throw new System.ArgumentOutOfRangeException("This value should be in range 0 to 90.");
                else
                    this._swatch1 = value;
            }
        }

        /// <summary>
        /// Swatch color value of the second color of the vector vinyl of the preset skin.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        [Reflection.Attributes.StaticModifiable()]
        public byte SwatchColor2
        {
            get => this._swatch2;
            set
            {
                if (value > 90)
                    throw new System.ArgumentOutOfRangeException("This value should be in range 0 to 90.");
                else
                    this._swatch2 = value;
            }
        }

        /// <summary>
        /// Swatch color value of the third color of the vector vinyl of the preset skin.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        [Reflection.Attributes.StaticModifiable()]
        public byte SwatchColor3
        {
            get => this._swatch3;
            set
            {
                if (value > 90)
                    throw new System.ArgumentOutOfRangeException("This value should be in range 0 to 90.");
                else
                    this._swatch3 = value;
            }
        }

        /// <summary>
        /// Swatch color value of the fourth color of the vector vinyl of the preset skin.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        [Reflection.Attributes.StaticModifiable()]
        public byte SwatchColor4
        {
            get => this._swatch4;
            set
            {
                if (value > 90)
                    throw new System.ArgumentOutOfRangeException("This value should be in range 0 to 90.");
                else
                    this._swatch4 = value;
            }
        }
    }
}