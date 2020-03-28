namespace GlobalLib.Support.Underground2.Class
{
    public partial class Material
    {
        private float _strongcolor4_level = 0;
        private float _strongcolor4_red = 0;
        private float _strongcolor4_green = 0;
        private float _strongcolor4_blue = 0;

        /// <summary>
        /// Level value of the fourth strong color of the material.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        [Reflection.Attributes.StaticModifiable()]
        public float StrongColor4Level
        {
            get => this._strongcolor4_level;
            set
            {
                if (value < 0)
                    throw new System.ArgumentOutOfRangeException("This value should be positive.");
                else
                    this._strongcolor4_level = value;
            }
        }

        /// <summary>
        /// Red value of the fourth strong color of the material.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        [Reflection.Attributes.StaticModifiable()]
        public float StrongColor4Red
        {
            get => this._strongcolor4_red;
            set
            {
                if (value < 0)
                    throw new System.ArgumentOutOfRangeException("This value should be positive.");
                else
                    this._strongcolor4_red = value;
            }
        }

        /// <summary>
        /// Green value of the fourth strong color of the material.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        [Reflection.Attributes.StaticModifiable()]
        public float StrongColor4Green
        {
            get => this._strongcolor4_green;
            set
            {
                if (value < 0)
                    throw new System.ArgumentOutOfRangeException("This value should be positive.");
                else
                    this._strongcolor4_green = value;
            }
        }

        /// <summary>
        /// Blue value of the fourth strong color of the material.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        [Reflection.Attributes.StaticModifiable()]
        public float StrongColor4Blue
        {
            get => this._strongcolor4_blue;
            set
            {
                if (value < 0)
                    throw new System.ArgumentOutOfRangeException("This value should be positive.");
                else
                    this._strongcolor4_blue = value;
            }
        }
    }
}