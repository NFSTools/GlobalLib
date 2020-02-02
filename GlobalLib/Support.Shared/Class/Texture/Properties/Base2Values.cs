namespace GlobalLib.Support.Shared.Class
{
    public partial class Texture : Reflection.Interface.IGetValue, Reflection.Interface.ISetValue
    {
        private byte _log_2_width = 0;
        private byte _log_2_height = 0;

        /// <summary>
        /// Represents base 2 value of the width of the texture.
        /// </summary>
        public byte Log_2_Width
        {
            get
            {
                byte b1 = this._log_2_width;
                byte b2 = (byte)System.Math.Log(this._width, 2);
                if (b1 == b2)
                    return b1;
                else
                {
                    this._log_2_width = b2;
                    return b2;
                }
            }
            protected set => this._log_2_width = value;
        }

        /// <summary>
        /// Represents base 2 value of the height of the texture.
        /// </summary>
        public byte Log_2_Height
        {
            get
            {
                byte b1 = this._log_2_height;
                byte b2 = (byte)System.Math.Log(this._height, 2);
                if (b1 == b2)
                    return b1;
                else
                {
                    this._log_2_height = b2;
                    return b2;
                }
            }
            protected set => this._log_2_height = value;
        }

    }
}