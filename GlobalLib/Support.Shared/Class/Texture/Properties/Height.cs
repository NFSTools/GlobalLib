namespace GlobalLib.Support.Shared.Class
{
    public partial class Texture : Reflection.Interface.IGetValue, Reflection.Interface.ISetValue
    {
        private short _height = 0;

        /// <summary>
        /// Represents height in pixels of the texture.
        /// </summary>
        public short Height
        {
            get => this._height;
            set
            {
                if (value <= 0)
                    throw new System.ArgumentOutOfRangeException("Value passed should be a positive value.");
                else
                {
                    this._height = value;
                    this._log_2_height = (byte)System.Math.Log(value, 2);
                }
            }
        }
    }
}