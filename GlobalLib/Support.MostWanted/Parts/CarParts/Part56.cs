namespace GlobalLib.Support.MostWanted.Parts.CarParts
{
    public class Part56
    {
        private uint _key = 0;
        private string _collection_name;
        public bool IsCar { get; set; } = false;
        public byte[] Data { get; private set; }
        public byte Index { get; private set; } = 0xFF;

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
                for (int a1 = 7; a1 < this.Data.Length; a1 += 0xE)
                    *(byteptr_t + a1) = index;
            }
        }

        // Default constructor: initialize new part56
        public unsafe Part56(string CName, byte index)
        {
            this._key = Utils.Bin.Hash(CName);
            this._collection_name = CName;
            this.Index = index;
            this.IsCar = true;
            this.Data = new byte[0xA72];
            fixed (byte* byteptr_t = &this.Data[0])
            {
                for (int a1 = 0, a2 = 0; a1 < 0xBF; ++a1, a2 += 14)
                {
                    *(uint*)(byteptr_t + a2) = Utils.Bin.Hash(CName + UsageType.PartName[a1]);
                    *(byteptr_t + a2 + 4) = UsageType.CarSlotID[a1];
                    *(ushort*)(byteptr_t + a2 + 5) = UsageType.Unknown1[a1];
                    *(byteptr_t + a2 + 7) = index;
                    *(ushort*)(byteptr_t + a2 + 8) = UsageType.CarPart1Offset[a1];
                    *(ushort*)(byteptr_t + a2 + 10) = UsageType.Unknown2[a1];
                    *(ushort*)(byteptr_t + a2 + 12) = UsageType.FeCustRecID[a1];
                }
            }
        }

        // Default constructor: initialize from Global data.
        public unsafe Part56(uint key, byte* part6ptr_t, int length, bool IsCar)
        {
            this.Data = new byte[length];
            this._key = key; // get part 5 key
            this.Index = *(part6ptr_t + 7); // get index of the part
            this.IsCar = IsCar;
            if (IsCar)
                this._collection_name = Core.Map.Lookup(key);

            // Copy part6 into memory
            fixed (byte* dataptr_t = &this.Data[0])
            {
                for (int a1 = 0; a1 < length; ++a1)
                    *(dataptr_t + a1) = *(part6ptr_t + a1);
            }
        }

        public override string ToString()
        {
            string str = this._collection_name == null ? string.Empty : this._collection_name;
            return $"BelongsTo: {str} | Index: {this.Index}";
        }
    }
}