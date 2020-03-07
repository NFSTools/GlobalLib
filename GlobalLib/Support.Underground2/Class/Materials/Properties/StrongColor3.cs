namespace GlobalLib.Support.Underground2.Class
{
    public partial class Material : Shared.Class.Material, Reflection.Interface.ICastable<Material>
    {
        private float _strongcolor3_level = 0;
        private float _strongcolor3_red = 0;
        private float _strongcolor3_green = 0;
        private float _strongcolor3_blue = 0;

        /// <summary>
        /// Level value of the third strong color of the material.
        /// </summary>
        public float StrongColor3Level
        {
            get => this._strongcolor3_level;
            set
            {
                if (value < 0)
                    throw new System.ArgumentOutOfRangeException("This value should be positive.");
                else
                    this._strongcolor3_level = value;
            }
        }

        /// <summary>
        /// Red value of the third strong color of the material.
        /// </summary>
        public float StrongColor3Red
        {
            get => this._strongcolor3_red;
            set
            {
                if (value < 0)
                    throw new System.ArgumentOutOfRangeException("This value should be positive.");
                else
                    this._strongcolor3_red = value;
            }
        }

        /// <summary>
        /// Green value of the third strong color of the material.
        /// </summary>
        public float StrongColor3Green
        {
            get => this._strongcolor3_green;
            set
            {
                if (value < 0)
                    throw new System.ArgumentOutOfRangeException("This value should be positive.");
                else
                    this._strongcolor3_green = value;
            }
        }

        /// <summary>
        /// Blue value of the third strong color of the material.
        /// </summary>
        public float StrongColor3Blue
        {
            get => this._strongcolor3_blue;
            set
            {
                if (value < 0)
                    throw new System.ArgumentOutOfRangeException("This value should be positive.");
                else
                    this._strongcolor3_blue = value;
            }
        }
    }
}