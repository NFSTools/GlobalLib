namespace GlobalLib.Support.Carbon.Class
{
    public partial class Material
    {
        private float _shadow_outer_radius = 0;
        private float _optimal_light_reflection = 0;

        /// <summary>
        /// Outer radius of the shadow fading.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        public float ShadowOuterRadius
        {
            get => this._shadow_outer_radius;
            set
            {
                if (value < 0)
                    throw new System.ArgumentOutOfRangeException("This value should be positive.");
                else
                    this._shadow_outer_radius = value;
            }
        }

        /// <summary>
        /// Value of the optimal light reflection on the material.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        public float OptimalLightReflection
        {
            get => this._optimal_light_reflection;
            set
            {
                if (value < 0)
                    throw new System.ArgumentOutOfRangeException("This value should be positive.");
                else
                    this._optimal_light_reflection = value;
            }
        }
    }
}