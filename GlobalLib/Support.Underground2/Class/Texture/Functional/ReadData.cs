namespace GlobalLib.Support.Underground2.Class
{
    public partial class Texture : Shared.Class.Texture, Reflection.Interface.ICastable<Texture>
    {
        /// <summary>
        /// Reads .dds data from the tpk block.
        /// </summary>
        /// <param name="byteptr_t">Pointer to the tpk block.</param>
        /// <param name="offset">Data offset from where to read.</param>
        public override unsafe void ReadData(byte* byteptr_t, int offset)
        {
            // Initialize data
            int total = this.PaletteSize + this.Size;
            this.Data = new byte[total];
            fixed (byte* dataptr_t = &this.Data[0])
            {
                // Copy data using pointers
                for (int a1 = 0; a1 < this.PaletteSize; ++a1)
                    *(dataptr_t + a1) = *(byteptr_t + offset + this.PaletteOffset + a1);
                for (int a1 = 0; a1 < this.Size; ++a1)
                    *(dataptr_t + this.PaletteSize + a1) = *(byteptr_t + offset + this.Offset + a1);
            }
        }
    }
}