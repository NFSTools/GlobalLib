namespace GlobalLib.Support.Carbon.Class
{
    public partial class Material
    {
        private float _reflectioncolor_level = 0;
        private float _reflectioncolor_red = 0;
        private float _reflectioncolor_green = 0;
        private float _reflectioncolor_blue = 0;

        /// <summary>
        /// Level value of the reflection color of the material.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        public float ReflectionColorLevel
        {
            get => this._reflectioncolor_level;
            set
            {
                if (value < 0)
                    throw new System.ArgumentOutOfRangeException("This value should be positive.");
                else
                    this._reflectioncolor_level = value;
            }
        }

        /// <summary>
        /// Red value of the reflection color of the material.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        public float ReflectionColorRed
        {
            get => this._reflectioncolor_red;
            set
            {
                if (value < 0)
                    throw new System.ArgumentOutOfRangeException("This value should be positive.");
                else
                    this._reflectioncolor_red = value;
            }
        }

        /// <summary>
        /// Green value of the reflection color of the material.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        public float ReflectionColorGreen
        {
            get => this._reflectioncolor_green;
            set
            {
                if (value < 0)
                    throw new System.ArgumentOutOfRangeException("This value should be positive.");
                else
                    this._reflectioncolor_green = value;
            }
        }

        /// <summary>
        /// Blue value of the reflection color of the material.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        public float ReflectionColorBlue
        {
            get => this._reflectioncolor_blue;
            set
            {
                if (value < 0)
                    throw new System.ArgumentOutOfRangeException("This value should be positive.");
                else
                    this._reflectioncolor_blue = value;
            }
        }
    }
}