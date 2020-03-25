namespace GlobalLib.Support.Shared.Parts.CarParts
{
    public class Part0
    {
        /// <summary>
        /// Represents data of part0.
        /// </summary>
        public byte[] Data { get; set; }

        /// <summary>
        /// Sets total number of cartypeinfos.
        /// </summary>
        /// <param name="number">Total number of cartypeinfos.</param>
        public unsafe void SetCarsNumber(int number)
        {
            fixed (byte* byteptr_t = &this.Data[0])
            {
                *(int*)(byteptr_t + 0x30) = number;
            }
        }

        /// <summary>
        /// Sets total number of carparts in part6.
        /// </summary>
        /// <param name="number">Total number of carparts in part6.</param>
        public unsafe void SetPartsNumber(int number)
        {
            fixed (byte* byteptr_t = &this.Data[0])
            {
                *(int*)(byteptr_t + 0x40) = number;
            }
        }

        /// <summary>
        /// Sets total number of records in part3.
        /// </summary>
        /// <param name="number">Total number of records in part3.</param>
        public unsafe void SetRecordNumber(int number)
        {
            fixed (byte* byteptr_t = &this.Data[0])
            {
                *(int*)(byteptr_t + 0x28) = number;
            }
        }

        /// <summary>
        /// Sets total number of misc types in part4.
        /// </summary>
        /// <param name="number">Total number of misc types in part4.</param>
        public unsafe void SetMiscNumber(int number)
        {
            fixed (byte* byteptr_t = &this.Data[0])
            {
                *(int*)(byteptr_t + 0x38) = number;
            }
        }
    }
}
