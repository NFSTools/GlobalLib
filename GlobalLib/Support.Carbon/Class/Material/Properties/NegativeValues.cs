namespace GlobalLib.Support.Carbon.Class
{
    public partial class Material
    {
        private float _grayscale = 0;
        private float _linear_negative = 0;
        private float _gradient_negative = 0;

        /// <summary>
        /// Main grayscale value of the material.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        public float Grayscale
        {
            get => this._grayscale;
            set
            {
                if (value < 0)
                    throw new System.ArgumentOutOfRangeException("This value should be positive.");
                else
                    this._grayscale = value;
            }
        }

        /// <summary>
        /// Linear negativity of the material colors.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        public float LinearNegative
        {
            get => this._linear_negative;
            set
            {
                if (value < 0)
                    throw new System.ArgumentOutOfRangeException("This value should be positive.");
                else
                    this._linear_negative = value;
            }
        }

        /// <summary>
        /// Gradient negativity of the material colors.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        public float GradientNegative
        {
            get => this._gradient_negative;
            set
            {
                if (value < 0)
                    throw new System.ArgumentOutOfRangeException("This value should be positive.");
                else
                    this._gradient_negative = value;
            }
        }
    }
}