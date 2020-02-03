namespace GlobalLib.Support.Shared.Class
{
    public partial class CarTypeInfo : Reflection.Interface.IGetValue, Reflection.Interface.ISetValue
    {
        private int _index = -1;
        private int _usagetype = (int)Reflection.Enum.CarTypeInfo.UsageType.Racer;
        private uint _memorytype = (uint)Reflection.Enum.CarTypeInfo.MemoryType.Racing;
        private byte _skinnable = 1;

        /// <summary>
        /// Represents index of the cartypeinfo in Global data.
        /// </summary>
        public int Index
        {
            get => this._index;
            set
            {
                if (value > byte.MaxValue || value < byte.MinValue)
                    throw new System.ArgumentOutOfRangeException();
                else
                    this._index = value;
            }
        }

        /// <summary>
        /// Represents usage type of the cartypeinfo.
        /// </summary>
        public int UsageType
        {
            get => this._usagetype;
            set
            {
                if (System.Enum.IsDefined(typeof(Reflection.Enum.CarTypeInfo.UsageType), value))
                {
                    if (this._usagetype != value)
                        this.Modified = true;
                    this._usagetype = value;
                }
                else
                    throw new System.ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Represents memory type of the cartypeinfo.
        /// </summary>
        public uint MemoryType
        {
            get => this._memorytype;
            set
            {
                if (System.Enum.IsDefined(typeof(Reflection.Enum.CarTypeInfo.MemoryType), value))
                    this._memorytype = value;
                else
                    throw new System.ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Represents boolean as an int of whether cartypeinfo is skinnable.
        /// </summary>
        public byte IsSkinnable
        {
            get => this._skinnable;
            set
            {
                if (value > byte.MaxValue || value < byte.MinValue)
                    throw new System.ArgumentOutOfRangeException();
                else
                    this._skinnable = value;
            }
        }
    }
}