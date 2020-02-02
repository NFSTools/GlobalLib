namespace GlobalLib.Support.Shared.Class
{
    public partial class Texture : Reflection.Interface.IGetValue, Reflection.Interface.ISetValue
    {
        private short _width = 0;

        /// <summary>
        /// Represents height in pixels of the texture.
        /// </summary>
        public short Width
        {
            get => this._width;
            set
            {
                if (value <= 0)
                    throw new System.ArgumentOutOfRangeException();
                else
                {
                    this._width = value;
                    this._log_2_width = (byte)System.Math.Log(value, 2);
                }
            }
        }
    }
}