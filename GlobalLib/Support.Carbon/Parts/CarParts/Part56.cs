namespace GlobalLib.Support.Carbon.Parts.CarParts
{
    public class Part56
    {
        private uint _key = 0;
        private string _collection_name;
        public bool IsCar { get; set; } = false;
        public byte[] Data { get; private set; }
        public byte Index { get; private set; } = 0xFF;
        public int Usage { get; private set; } = (int)Reflection.Enum.CarTypeInfo.UsageType.Racer;

        /// <summary>
        /// Game index to which the class belongs to.
        /// </summary>
        public int GameINT { get => (int)Core.GameINT.Carbon; }

        /// <summary>
        /// Game string to which the class belongs to.
        /// </summary>
        public string GameSTR { get => Core.GameSTR.Carbon; }
        
        /// <summary>
        /// Key of the cartypeinfo of the carpart.
        /// </summary>
        public uint Key
        {
            get => this._key;
            set
            {
                if (!Core.Map.BinKeys.ContainsKey(_key))
                    throw new Reflection.Exception.MappingFailException();
                else
                {
                    this._key = value;
                    this._collection_name = Core.Map.BinKeys[value];
                }
            }
        }

        /// <summary>
        /// CarTypeInfo to which the carpart belongs to.
        /// </summary>
        public string BelongsTo
        {
            get => this._collection_name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new System.ArgumentNullException();
                else
                {
                    this._collection_name = value;
                    uint temp = Utils.Bin.Hash(value);
                    this._key = temp;
                }
            }
        }

        /// <summary>
        /// Sets new index in the part56.
        /// </summary>
        /// <param name="index">New index to be set.</param>
        public unsafe void SetIndex(byte index)
        {
            this.Index = index;
            fixed (byte* byteptr_t = &this.Data[0])
            {
                for (int a1 = 1; a1 < this.Data.Length; a1 += 4)
                    *(byteptr_t + a1) = index;
            }
        }

        /// <summary>
        /// Sets new usage in the part56.
        /// </summary>
        /// <param name="usage">New usage to be set.</param>
        public unsafe void SetUsage(int usage)
        {
            if (this.Usage == usage) return;
            this.Usage = usage;
            this.Data = null;
            switch (usage)
            {
                case 1:
                    this.Data = new byte[204];
                    fixed (byte* byteptr_t = &this.Data[0])
                    {
                        for (int a1 = 0; a1 < 51; ++a1)
                        {
                            *(byteptr_t + a1 * 4) = 0;
                            *(byteptr_t + a1 * 4 + 1) = (byte)Index;
                            *(ushort*)(byteptr_t + a1 * 4 + 2) = UsageType.Cop[a1];
                        }
                    }
                    break;

                case 2:
                    this.Data = new byte[128];
                    fixed (byte* byteptr_t = &this.Data[0])
                    {
                        for (int a1 = 0; a1 < 32; ++a1)
                        {
                            *(byteptr_t + a1 * 4) = 0;
                            *(byteptr_t + a1 * 4 + 1) = (byte)Index;
                            *(ushort*)(byteptr_t + a1 * 4 + 2) = UsageType.Trafs[a1];
                        }
                    }
                    break;

                default:
                    this.Data = new byte[1108];
                    fixed (byte* byteptr_t = &this.Data[0])
                    {
                        for (int a1 = 0; a1 < 277; ++a1)
                        {
                            *(byteptr_t + a1 * 4) = 0;
                            *(byteptr_t + a1 * 4 + 1) = (byte)Index;
                            *(ushort*)(byteptr_t + a1 * 4 + 2) = UsageType.Racer[a1];
                        }
                    }
                    break;
            }
        }

        // Default constructor: initialize new part56
        public unsafe Part56(string CName, byte index, int usage)
        {
            this._key = Utils.Bin.Hash(CName);
            this._collection_name = CName;
            this.Index = index;
            this.Usage = usage;
            this.IsCar = true;
            switch (usage)
            {
                case 1:
                    this.Data = new byte[204];
                    fixed (byte* byteptr_t = &this.Data[0])
                    {
                        for (int a1 = 0, a2 = 0; a1 < 51; ++a1, a2 += 4)
                        {
                            *(byteptr_t + a2) = 0;
                            *(byteptr_t + a2 + 1) = index;
                            *(ushort*)(byteptr_t + a2 + 2) = UsageType.Cop[a1];
                        }
                    }
                    break;

                case 2:
                    this.Data = new byte[128];
                    fixed (byte* byteptr_t = &this.Data[0])
                    {
                        for (int a1 = 0, a2 = 0; a1 < 32; ++a1, a2 += 4)
                        {
                            *(byteptr_t + a2) = 0;
                            *(byteptr_t + a2 + 1) = index;
                            *(ushort*)(byteptr_t + a2 + 2) = UsageType.Trafs[a1];
                        }
                    }
                    break;

                default:
                    this.Data = new byte[1108];
                    fixed (byte* byteptr_t = &this.Data[0])
                    {
                        for (int a1 = 0, a2 = 0; a1 < 277; ++a1, a2 += 4)
                        {
                            *(byteptr_t + a2) = 0;
                            *(byteptr_t + a2 + 1) = index;
                            *(ushort*)(byteptr_t + a2 + 2) = UsageType.Racer[a1];
                        }
                    }
                    break;
            }
        }

        // Default constructor: initialize from Global data.
        public unsafe Part56(uint key, byte* part6ptr_t, int length, bool IsCar)
        {
            this.Data = new byte[length];
            this._key = key; // get part 5 key
            this.Index = *(part6ptr_t + 1); // get index of the part
            this.IsCar = IsCar;
            if (IsCar)
                this._collection_name = Core.Map.Lookup(key);

            // Copy part6 data into memory
            fixed (byte* dataptr_t = &this.Data[0])
            {
                for (int a1 = 0; a1 < length; ++a1)
                    *(dataptr_t + a1) = *(part6ptr_t + a1);
            }

            // Get UsageType
            switch (Data.Length)
            {
                case 204:
                    this.Usage = (int)Reflection.Enum.CarTypeInfo.UsageType.Cop;
                    break;
                case 128:
                    this.Usage = (int)Reflection.Enum.CarTypeInfo.UsageType.Traffic;
                    break;
                case 1108:
                    this.Usage = (int)Reflection.Enum.CarTypeInfo.UsageType.Racer;
                    break;
                default:
                    this.Usage = -1;
                    break;
            }
        }
    }
}