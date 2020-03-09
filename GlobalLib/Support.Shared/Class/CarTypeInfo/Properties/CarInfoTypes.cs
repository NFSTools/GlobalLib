namespace GlobalLib.Support.Shared.Class
{
    public partial class CarTypeInfo
    {
        private int _index = -1;
        private int _usagetype = (int)Reflection.Enum.CarTypeInfo.UsageType.Racer;
        private uint _memorytype = (uint)Reflection.Enum.CarTypeInfo.MemoryType.Racing;

        /// <summary>
        /// Represents index of the cartypeinfo in Global data.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        public int Index
        {
            get => this._index;
            set
            {
                if (value > byte.MaxValue || value < byte.MinValue)
                    throw new System.ArgumentOutOfRangeException("Value passed was outside of range of possible values.");
                else
                    this._index = value;
            }
        }

        /// <summary>
        /// Represents usage type of the cartypeinfo.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
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
                    throw new System.ArgumentOutOfRangeException("Value passed was outside of range of possible values.");
            }
        }

        /// <summary>
        /// Represents memory type of the cartypeinfo.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        public uint MemoryType
        {
            get => this._memorytype;
            set
            {
                if (System.Enum.IsDefined(typeof(Reflection.Enum.CarTypeInfo.MemoryType), value))
                    this._memorytype = value;
                else
                    throw new System.ArgumentOutOfRangeException("Value passed was outside of range of possible values.");
            }
        }

        /// <summary>
        /// Represents boolean as an int of whether cartypeinfo is skinnable.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        public bool IsSkinnable { get; set; } = true;
    }
}