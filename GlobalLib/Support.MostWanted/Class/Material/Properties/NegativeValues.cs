namespace GlobalLib.Support.MostWanted.Class
{
    public partial class Material : Shared.Class.Material, Reflection.Interface.ICastable<Material>
    {
        private float _linear_negative = 0;
        private float _gradient_negative = 0;

        /// <summary>
        /// Linear negativity of the material colors.
        /// </summary>
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