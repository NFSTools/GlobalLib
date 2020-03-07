namespace GlobalLib.Support.Underground2.Class
{
    public partial class Material : Shared.Class.Material, Reflection.Interface.ICastable<Material>
    {
        private float _strongcolor1_level = 0;
        private float _strongcolor1_red = 0;
        private float _strongcolor1_green = 0;
        private float _strongcolor1_blue = 0;

        /// <summary>
        /// Level value of the first strong color of the material.
        /// </summary>
        public float StrongColor1Level
        {
            get => this._strongcolor1_level;
            set
            {
                if (value < 0)
                    throw new System.ArgumentOutOfRangeException("This value should be positive.");
                else
                    this._strongcolor1_level = value;
            }
        }

        /// <summary>
        /// Red value of the first strong color of the material.
        /// </summary>
        public float StrongColor1Red
        {
            get => this._strongcolor1_red;
            set
            {
                if (value < 0)
                    throw new System.ArgumentOutOfRangeException("This value should be positive.");
                else
                    this._strongcolor1_red = value;
            }
        }

        /// <summary>
        /// Green value of the first strong color of the material.
        /// </summary>
        public float StrongColor1Green
        {
            get => this._strongcolor1_green;
            set
            {
                if (value < 0)
                    throw new System.ArgumentOutOfRangeException("This value should be positive.");
                else
                    this._strongcolor1_green = value;
            }
        }

        /// <summary>
        /// Blue value of the first strong color of the material.
        /// </summary>
        public float StrongColor1Blue
        {
            get => this._strongcolor1_blue;
            set
            {
                if (value < 0)
                    throw new System.ArgumentOutOfRangeException("This value should be positive.");
                else
                    this._strongcolor1_blue = value;
            }
        }
    }
}