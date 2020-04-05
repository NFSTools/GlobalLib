using GlobalLib.Reflection.Attributes;
using System;

namespace GlobalLib.Support.Underground2.Class
{
    public partial class Material
    {
        private float _brightcolor2_level = 0;
        private float _brightcolor2_red = 0;
        private float _brightcolor2_green = 0;
        private float _brightcolor2_blue = 0;

        /// <summary>
        /// Level value of the second bright color of the material.
        /// </summary>
        [AccessModifiable()]
        [StaticModifiable()]
        public float BrightColor2Level
        {
            get => this._brightcolor2_level;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("This value should be positive.");
                else
                    this._brightcolor2_level = value;
            }
        }

        /// <summary>
        /// Red value of the second bright color of the material.
        /// </summary>
        [AccessModifiable()]
        [StaticModifiable()]
        public float BrightColor2Red
        {
            get => this._brightcolor2_red;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("This value should be positive.");
                else
                    this._brightcolor2_red = value;
            }
        }

        /// <summary>
        /// Green value of the second bright color of the material.
        /// </summary>
        [AccessModifiable()]
        [StaticModifiable()]
        public float BrightColor2Green
        {
            get => this._brightcolor2_green;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("This value should be positive.");
                else
                    this._brightcolor2_green = value;
            }
        }

        /// <summary>
        /// Blue value of the second bright color of the material.
        /// </summary>
        [AccessModifiable()]
        [StaticModifiable()]
        public float BrightColor2Blue
        {
            get => this._brightcolor2_blue;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("This value should be positive.");
                else
                    this._brightcolor2_blue = value;
            }
        }
    }
}