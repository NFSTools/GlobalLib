namespace GlobalLib.Support.Shared.Class
{
    public partial class Texture : Reflection.Interface.IGetValue, Reflection.Interface.ISetValue
    {
        private byte _tileableuv = 0;

        /// <summary>
        /// Represents tileable level of the texture.
        /// </summary>
        public byte TileableUV
        {
            get => this._tileableuv;
            set
            {
                if (value > 3)
                    throw new System.ArgumentOutOfRangeException();
                else
                    this._tileableuv = value;
            }
        }
    }
}