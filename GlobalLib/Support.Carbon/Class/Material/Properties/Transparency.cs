namespace GlobalLib.Support.Carbon.Class
{
    public partial class Material : Shared.Class.Material, Reflection.Interface.ICastable<Material>
    {
        private float _transparency1 = 0;
        private float _transparency2 = 0;

        /// <summary>
        /// First alpha value of the material colors.
        /// </summary>
        public float AlphaValue1
        {
            get => this._transparency1;
            set
            {
                if (value < 0)
                    throw new System.ArgumentOutOfRangeException();
                else
                    this._transparency1 = value;
            }
        }

        /// <summary>
        /// Second alpha value of the material colors.
        /// </summary>
        public float AlphaValue2
        {
            get => this._transparency2;
            set
            {
                if (value < 0)
                    throw new System.ArgumentOutOfRangeException();
                else
                    this._transparency2 = value;
            }
        }
    }
}