﻿namespace GlobalLib.Support.MostWanted.Class
{
    public partial class Material
    {
        private float _unk1 = 0;
        private float _unk2 = 0;
        private float _unk3 = 0;
        private float _unk4 = 0;
        private float _unk5 = 0;
        private float _unk6 = 0;
        private float _unk7 = 0;
        private float _unk8 = 0;
        private float _unk9 = 0;

        /// <summary>
        /// Unknown 1 value of the material.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        public float Unknown1
        {
            get => this._unk1;
            set
            {
                if (value < 0)
                    throw new System.ArgumentOutOfRangeException("This value should be positive.");
                else
                    this._unk1 = value;
            }
        }

        /// <summary>
        /// Unknown 2 value of the material.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        public float Unknown2
        {
            get => this._unk2;
            set
            {
                if (value < 0)
                    throw new System.ArgumentOutOfRangeException("This value should be positive.");
                else
                    this._unk2 = value;
            }
        }

        /// <summary>
        /// Unknown 3 value of the material.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        public float Unknown3
        {
            get => this._unk3;
            set
            {
                if (value < 0)
                    throw new System.ArgumentOutOfRangeException("This value should be positive.");
                else
                    this._unk3 = value;
            }
        }

        /// <summary>
        /// Unknown 4 value of the material.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        public float Unknown4
        {
            get => this._unk4;
            set
            {
                if (value < 0)
                    throw new System.ArgumentOutOfRangeException("This value should be positive.");
                else
                    this._unk4 = value;
            }
        }

        /// <summary>
        /// Unknown 5 value of the material.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        public float Unknown5
        {
            get => this._unk5;
            set
            {
                if (value < 0)
                    throw new System.ArgumentOutOfRangeException("This value should be positive.");
                else
                    this._unk5 = value;
            }
        }

        /// <summary>
        /// Unknown 6 value of the material.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        public float Unknown6
        {
            get => this._unk6;
            set
            {
                if (value < 0)
                    throw new System.ArgumentOutOfRangeException("This value should be positive.");
                else
                    this._unk6 = value;
            }
        }

        /// <summary>
        /// Unknown 7 value of the material.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        public float Unknown7
        {
            get => this._unk7;
            set
            {
                if (value < 0)
                    throw new System.ArgumentOutOfRangeException("This value should be positive.");
                else
                    this._unk7 = value;
            }
        }

        /// <summary>
        /// Unknown 8 value of the material.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        public float Unknown8
        {
            get => this._unk8;
            set
            {
                if (value < 0)
                    throw new System.ArgumentOutOfRangeException("This value should be positive.");
                else
                    this._unk8 = value;
            }
        }

        /// <summary>
        /// Unknown 9 value of the material.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        public float Unknown9
        {
            get => this._unk9;
            set
            {
                if (value < 0)
                    throw new System.ArgumentOutOfRangeException("This value should be positive.");
                else
                    this._unk9 = value;
            }
        }
    }
}