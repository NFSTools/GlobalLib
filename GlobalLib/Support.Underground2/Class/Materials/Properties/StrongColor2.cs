namespace GlobalLib.Support.Underground2.Class
{
    public partial class Material
    {
        private float _strongcolor2_level = 0;
        private float _strongcolor2_red = 0;
        private float _strongcolor2_green = 0;
        private float _strongcolor2_blue = 0;

        /// <summary>
        /// Level value of the second strong color of the material.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        public float StrongColor2Level
        {
            get => this._strongcolor2_level;
            set
            {
                if (value < 0)
                    throw new System.ArgumentOutOfRangeException("This value should be positive.");
                else
                    this._strongcolor2_level = value;
            }
        }

        /// <summary>
        /// Red value of the second strong color of the material.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        public float StrongColor2Red
        {
            get => this._strongcolor2_red;
            set
            {
                if (value < 0)
                    throw new System.ArgumentOutOfRangeException("This value should be positive.");
                else
                    this._strongcolor2_red = value;
            }
        }

        /// <summary>
        /// Green value of the second strong color of the material.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        public float StrongColor2Green
        {
            get => this._strongcolor2_green;
            set
            {
                if (value < 0)
                    throw new System.ArgumentOutOfRangeException("This value should be positive.");
                else
                    this._strongcolor2_green = value;
            }
        }

        /// <summary>
        /// Blue value of the second strong color of the material.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        public float StrongColor2Blue
        {
            get => this._strongcolor2_blue;
            set
            {
                if (value < 0)
                    throw new System.ArgumentOutOfRangeException("This value should be positive.");
                else
                    this._strongcolor2_blue = value;
            }
        }
    }
}