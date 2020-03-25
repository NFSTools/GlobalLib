namespace GlobalLib.Support.Underground2.Parts.CarParts
{
    public class Part56
    {
        private uint _key = 0;
        private string _collection_name;
        public bool IsCar { get; set; } = false;
        public byte[] Data { get; private set; }
        public byte Index { get; private set; } = 0xFF;
        public Reflection.Enum.eUsageType Usage { get; set; } = Reflection.Enum.eUsageType.Racer;

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
            for (int a1 = 7; a1 < this.Data.Length; a1 += 0xE)
                this.Data[a1] = index;
        }

        public Part56() { }

        // Default constructor: initialize new part56
        public unsafe Part56(string CName, Reflection.Enum.eUsageType type, int entries, int racers, int trafs)
        {
            this._key = Utils.Bin.Hash(CName);
            this._collection_name = CName;
            this.IsCar = true;
            this.Usage = type;

            if (type == Reflection.Enum.eUsageType.Racer)
            {
                this.Data = new byte[0xEC4];
                fixed (byte* byteptr_t = &this.Data[0])
                {
                    for (int a1 = 0, a2 = 0; a1 < 0x10E; ++a1, a2 += 0xE)
                    {
                        *(uint*)(byteptr_t + a2) = Utils.Bin.Hash(CName + UsageType.PartName[a1]);
                        *(byteptr_t + a2 + 4) = UsageType.CarSlotID[a1];
                        *(ushort*)(byteptr_t + a2 + 5) = UsageType.Unknown1[a1];
                        *(byteptr_t + a2 + 7) = this.Index;
                        *(ushort*)(byteptr_t + a2 + 8) = UsageType.CarPart1Offset[a1];
                        *(ushort*)(byteptr_t + a2 + 10) = (a1 == 63 || (a1 >= 65 && a1 <= 68) ||
                            (a1 >= 94 && a1 <= 98) || (a1 >= 122 && a1 <= 126) || (a1 >= 160 && a1 <= 193))
                            ? (ushort)(UsageType.Unknown2[a1] + 0x8F * (racers + 1) + 1)
                            : UsageType.Unknown2[a1];
                        * (ushort*)(byteptr_t + a2 + 12) = (a1 == 232 || a1 > 264)
                            ? (ushort)(entries + UsageType.FeCustRecID[a1] + (trafs * 2) + (racers * 6))
                            : UsageType.FeCustRecID[a1];
                    }
                }
            }
            else if (type == Reflection.Enum.eUsageType.Traffic)
            {
                this.Data = new byte[0x2A];
                fixed (byte* byteptr_t = &this.Data[0])
                {
                    for (int a1 = 0, a2 = 0; a1 < 3; ++a1, a2 += 0xE)
                    {
                        *(uint*)(byteptr_t + a2) = Utils.Bin.Hash(CName + UsageType.TrafficPartName[a1]);
                        *(byteptr_t + a2 + 4) = UsageType.CarSlotID[a1];
                        *(ushort*)(byteptr_t + a2 + 5) = UsageType.TrafficUnknown1[a1];
                        *(byteptr_t + a2 + 7) = this.Index;
                        *(ushort*)(byteptr_t + a2 + 8) = UsageType.TrafficCarPart1Offset[a1];
                        *(ushort*)(byteptr_t + a2 + 10) = UsageType.TrafficUnknown2[a2];
                        *(ushort*)(byteptr_t + a2 + 12) = (a1 == 0)
                            ? UsageType.TrafficFeCustRecID[a1]
                            : (ushort)(entries + (trafs * 2) + (racers * 6) + UsageType.TrafficFeCustRecID[a1]);
                    }
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
                this._collection_name = Core.Map.Lookup(key, false);

            // Copy part6 into memory
            for (int a1 = 0; a1 < length; ++a1)
                this.Data[a1] = *(part6ptr_t + a1);

            if (length == 0x2A && IsCar) this.Usage = Reflection.Enum.eUsageType.Traffic;
            else if (length == 0xEC4 && IsCar) this.Usage = Reflection.Enum.eUsageType.Racer;
        }

        public override string ToString()
        {
            string str = this._collection_name ?? string.Empty;
            return $"BelongsTo: {str} | Index: {this.Index}";
        }

        /// <summary>
        /// Returns new class with casted memory of this class.
        /// </summary>
        /// <param name="CName">Collection Name of the classes, null by default.</param>
        /// <returns>Copy of this class.</returns>
        public unsafe Part56 MemoryCast(string CName = null)
        {
            var result = new Part56();
            result.Data = new byte[this.Data.Length];
            System.Buffer.BlockCopy(this.Data, 0, result.Data, 0, this.Data.Length);
            result._collection_name = this._collection_name;
            result._key = this._key;
            result.IsCar = this.IsCar;
            result.Index = this.Index;
            return result;
        }

        /// <summary>
        /// Casts all record and parts IDs of one carpart to another, while changing part hashes
        /// to have new collection name prefix and changing index of the part.
        /// </summary>
        /// <param name="CName">Collection Name of the new carpart.</param>
        /// <param name="index">Index of the new carpart.</param>
        /// <returns></returns>
        public unsafe Part56 SmartMemoryCast(string CName, int entries, int racers, int trafs)
        {
            var result = this.MemoryCast();
            result.BelongsTo = CName;

            fixed (byte* byteptr_t = &result.Data[0])
            {
                if (this.Usage == Reflection.Enum.eUsageType.Racer)
                {
                    for (int a1 = 0, a2 = 0; a1 < 0x10E; ++a1, a2 += 0xE)
                    {
                        *(uint*)(byteptr_t + a2) = Utils.Bin.Hash(CName + UsageType.PartName[a1]);
                        *(ushort*)(byteptr_t + a2 + 10) = (a1 == 63 || (a1 >= 65 && a1 <= 68) ||
                            (a1 >= 94 && a1 <= 98) || (a1 >= 122 && a1 <= 126) || (a1 >= 160 && a1 <= 193))
                            ? (ushort)(UsageType.Unknown2[a1] + 0x8F * (racers + 1) + 1)
                            : UsageType.Unknown2[a1];
                        *(ushort*)(byteptr_t + a2 + 12) = (a1 == 232 || a1 > 264)
                            ? (ushort)(entries + UsageType.FeCustRecID[a1] + (trafs * 2) + (racers * 6))
                            : UsageType.FeCustRecID[a1];
                    }
                }
                else if (this.Usage == Reflection.Enum.eUsageType.Traffic)
                {
                    for (int a1 = 0, a2 = 0; a1 < 3; ++a1, a2 += 0xE)
                    {
                        *(uint*)(byteptr_t + a2) = Utils.Bin.Hash(CName + UsageType.TrafficPartName[a1]);
                        *(ushort*)(byteptr_t + a2 + 12) = (a1 == 0)
                            ? UsageType.TrafficFeCustRecID[a1]
                            : (ushort)(entries + (trafs * 2) + (racers * 6) + UsageType.TrafficFeCustRecID[a1]);
                    }
                }
            }
            return result;
        }
    }
}