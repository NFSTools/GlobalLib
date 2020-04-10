using GlobalLib.Reflection.Attributes;
using System;

namespace GlobalLib.Support.Underground1.Class
{
    public partial class Material
    {
        private float _transparency1 = 0;
        private float _transparency2 = 0;

        /// <summary>
        /// First alpha value of the material colors.
        /// </summary>
        [AccessModifiable()]
        [StaticModifiable()]
        public float AlphaValue1
        {
            get => this._transparency1;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("This value should be positive.");
                else
                    this._transparency1 = value;
            }
        }

        /// <summary>
        /// Second alpha value of the material colors.
        /// </summary>
        [AccessModifiable()]
        [StaticModifiable()]
        public float AlphaValue2
        {
            get => this._transparency2;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("This value should be positive.");
                else
                    this._transparency2 = value;
            }
        }
    }
}