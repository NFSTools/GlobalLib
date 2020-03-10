namespace GlobalLib.Support.MostWanted.Class
{
    public partial class Material
    {
        private float _transparency = 0;

        /// <summary>
        /// First alpha value of the material colors.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        public float AlphaValue
        {
            get => this._transparency;
            set
            {
                if (value < 0)
                    throw new System.ArgumentOutOfRangeException("This value should be positive.");
                else
                    this._transparency = value;
            }
        }
    }
}