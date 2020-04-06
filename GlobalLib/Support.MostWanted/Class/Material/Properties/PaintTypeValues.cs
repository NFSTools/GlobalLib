using GlobalLib.Reflection.Attributes;
using System;

namespace GlobalLib.Support.MostWanted.Class
{
    public partial class Material
    {
        private float _shadowlevel = 0;
        private float _mattelevel = 0;
        private float _chromelevel = 0;

        /// <summary>
        /// Shadow level value of the material.
        /// </summary>
        [AccessModifiable()]
        [StaticModifiable()]
        public float ShadowLevel
        {
            get => this._shadowlevel;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("This value should be positive.");
                else
                    this._shadowlevel = value;
            }
        }

        /// <summary>
        /// Matte level value of the material.
        /// </summary>
        [AccessModifiable()]
        [StaticModifiable()]
        public float MatteLevel
        {
            get => this._mattelevel;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("This value should be positive.");
                else
                    this._mattelevel = value;
            }
        }

        /// <summary>
        /// Chrome level value of the material.
        /// </summary>
        [AccessModifiable()]
        [StaticModifiable()]
        public float ChromeLevel
        {
            get => this._chromelevel;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("This value should be positive.");
                else
                    this._chromelevel = value;
            }
        }
    }
}