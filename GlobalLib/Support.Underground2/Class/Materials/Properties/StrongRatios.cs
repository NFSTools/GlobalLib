namespace GlobalLib.Support.Underground2.Class
{
    public partial class Material
    {
        private float _strong_1_to_2_ratio = 0;
        private float _strong_3_to_4_ratio = 0;

        /// <summary>
        /// Ratio between first and second strong colors of the material
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        public float Strong1to2Ratio
        {
            get => this._strong_1_to_2_ratio;
            set
            {
                if (value < 0)
                    throw new System.ArgumentOutOfRangeException("This value should be positive.");
                else
                    this._strong_1_to_2_ratio = value;
            }
        }

        /// <summary>
        /// Ratio between third and fourth strong colors of the material
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        public float Strong3to4Ratio
        {
            get => this._strong_3_to_4_ratio;
            set
            {
                if (value < 0)
                    throw new System.ArgumentOutOfRangeException("This value should be positive.");
                else
                    this._strong_3_to_4_ratio = value;
            }
        }
    }
}