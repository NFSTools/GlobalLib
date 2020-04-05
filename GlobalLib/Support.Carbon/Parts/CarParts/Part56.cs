using GlobalLib.Core;
using GlobalLib.Reflection.Enum;
using GlobalLib.Reflection.Exception;
using GlobalLib.Reflection.Interface;
using GlobalLib.Utils;
using System;

namespace GlobalLib.Support.Carbon.Parts.CarParts
{
    public class Part56 : ICastable<Part56>
    {
        private uint _key = 0;
        private string _collection_name;
        public bool IsCar { get; set; } = false;
        public byte[] Data { get; private set; }
        public byte Index { get; private set; } = 0xFF;
        public eUsageType Usage { get; private set; } = eUsageType.Racer;

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
                if (!Map.BinKeys.ContainsKey(_key))
                    throw new MappingFailException();
                else
                {
                    this._key = value;
                    this._collection_name = Map.BinKeys[value];
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
                    throw new ArgumentNullException();
                else
                {
                    this._collection_name = value;
                    uint temp = Bin.Hash(value);
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
        public unsafe void SetUsage(eUsageType usage)
        {
            if (this.Usage == usage) return;
            this.Usage = usage;
            this.Data = null;
            switch (usage)
            {
                case eUsageType.Cop:
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

                case eUsageType.Traffic:
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

        public Part56() { }

        // Default constructor: initialize new part56
        public unsafe Part56(string CName, byte index, eUsageType usage)
        {
            this._key = Bin.Hash(CName);
            this._collection_name = CName;
            this.Index = index;
            this.Usage = usage;
            this.IsCar = true;
            switch (usage)
            {
                case eUsageType.Cop:
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

                case eUsageType.Traffic:
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
                this._collection_name = Map.Lookup(key, false);

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
                    this.Usage = eUsageType.Cop;
                    break;
                case 128:
                    this.Usage = eUsageType.Traffic;
                    break;
                case 1108:
                    this.Usage = eUsageType.Racer;
                    break;
                default:
                    this.Usage = eUsageType.Universal;
                    break;
            }
        }

        public override string ToString()
        {
            string str = this._collection_name == null ? string.Empty : this._collection_name;
            return $"BelongsTo: {str} | Index: {this.Index}";
        }

        /// <summary>
        /// Returns new class with casted memory of this class.
        /// </summary>
        /// <param name="CName">Collection Name of the classes, null by default.</param>
        /// <returns>Copy of this class.</returns>
        public Part56 MemoryCast(string CName = null)
        {
            var result = new Part56();
            result.Data = new byte[this.Data.Length];
            Buffer.BlockCopy(this.Data, 0, result.Data, 0, this.Data.Length);
            result._collection_name = this._collection_name;
            result._key = this._key;
            result.IsCar = this.IsCar;
            result.Index = this.Index;
            result.Usage = this.Usage;
            return result;
        }
    }
}