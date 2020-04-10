namespace GlobalLib.Support.Underground1.Class
{
    public partial class Texture
    {
        /// <summary>
        /// Reads .dds data from the tpk block.
        /// </summary>
        /// <param name="byteptr_t">Pointer to the tpk block.</param>
        /// <param name="offset">Data offset from where to read.</param>
        /// <param name="forced">If forced, ignores internal offset and reads data 
        /// starting at the pointer passed.</param>
        public override unsafe void ReadData(byte* byteptr_t, int offset, bool forced)
        {
            // Initialize data
            int total = this.PaletteSize + this.Size;
            this.Data = new byte[total];
            fixed (byte* dataptr_t = &this.Data[0])
            {
                // Copy data using pointers
                if (forced)
                {
                    for (int a1 = 0; a1 < total; ++a1)
                        *(dataptr_t + a1) = *(byteptr_t + offset + a1);
                }
                else
                {
                    for (int a1 = 0; a1 < this.PaletteSize; ++a1)
                        *(dataptr_t + a1) = *(byteptr_t + offset + this.PaletteOffset + a1);
                    for (int a1 = 0; a1 < this.Size; ++a1)
                        *(dataptr_t + this.PaletteSize + a1) = *(byteptr_t + offset + this.Offset + a1);
                }
            }
        }
    }
}