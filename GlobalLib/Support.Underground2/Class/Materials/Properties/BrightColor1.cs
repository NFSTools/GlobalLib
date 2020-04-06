using GlobalLib.Reflection.Attributes;
using System;

namespace GlobalLib.Support.Underground2.Class
{
    public partial class Material
    {
        private float _brightcolor1_level = 0;
        private float _brightcolor1_red = 0;
        private float _brightcolor1_green = 0;
        private float _brightcolor1_blue = 0;

        /// <summary>
        /// Level value of the first bright color of the material.
        /// </summary>
        [AccessModifiable()]
        [StaticModifiable()]
        public float BrightColor1Level
        {
            get => this._brightcolor1_level;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("This value should be positive.");
                else
                    this._brightcolor1_level = value;
            }
        }

        /// <summary>
        /// Red value of the first bright color of the material.
        /// </summary>
        [AccessModifiable()]
        [StaticModifiable()]
        public float BrightColor1Red
        {
            get => this._brightcolor1_red;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("This value should be positive.");
                else
                    this._brightcolor1_red = value;
            }
        }

        /// <summary>
        /// Green value of the first bright color of the material.
        /// </summary>
        [AccessModifiable()]
        [StaticModifiable()]
        public float BrightColor1Green
        {
            get => this._brightcolor1_green;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("This value should be positive.");
                else
                    this._brightcolor1_green = value;
            }
        }

        /// <summary>
        /// Blue value of the first bright color of the material.
        /// </summary>
        [AccessModifiable()]
        [StaticModifiable()]
        public float BrightColor1Blue
        {
            get => this._brightcolor1_blue;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("This value should be positive.");
                else
                    this._brightcolor1_blue = value;
            }
        }
    }
}