namespace GlobalLib.Support.Carbon.Class
{
    public partial class Material : Shared.Class.Material, Reflection.Interface.ICastable<Material>
    {
        private float _disable_reflection = 0;
        private float _stronger_reflection = 0;
        private float _blend_strong_colors = 0;
        private float _disable_strong_colors = 0;

        /// <summary>
        /// Disable value of reflection colors of the material.
        /// </summary>
        public float DisableReflection
        {
            get => this._disable_reflection;
            set
            {
                if (value < 0)
                    throw new System.ArgumentOutOfRangeException("This value should be positive.");
                else
                    this._disable_reflection = value;
            }
        }

        /// <summary>
        /// Increment value of reflection colors of the material.
        /// </summary>
        public float StrongerReflection
        {
            get => this._stronger_reflection;
            set
            {
                if (value < 0)
                    throw new System.ArgumentOutOfRangeException("This value should be positive.");
                else
                    this._stronger_reflection = value;
            }
        }

        /// <summary>
        /// Blend value of strong colors of the material.
        /// </summary>
        public float BlendStrongColors
        {
            get => this._blend_strong_colors;
            set
            {
                if (value < 0)
                    throw new System.ArgumentOutOfRangeException("This value should be positive.");
                else
                    this._blend_strong_colors = value;
            }
        }

        /// <summary>
        /// Disable value of strong colors of the material.
        /// </summary>
        public float DisableStrongColors
        {
            get => this._disable_strong_colors;
            set
            {
                if (value < 0)
                    throw new System.ArgumentOutOfRangeException("This value should be positive.");
                else
                    this._disable_strong_colors = value;
            }
        }
    }
}