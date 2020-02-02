namespace GlobalLib.Support.Shared.Class
{
    public partial class TPKBlock
    {
        /// <summary>
        /// Disassembles tpk block array into separate properties.
        /// </summary>
        /// <param name="byteptr_t">Pointer to the tpk block array.</param>
        protected virtual unsafe void Disassemble(byte* byteptr_t) { }

        /// <summary>
        /// Finds offsets of all partials and its parts in the tpk block.
        /// </summary>
        /// <param name="byteptr_t">Pointer to the tpk block array.</param>
        /// <returns>Array of all offsets.</returns>
        protected virtual unsafe int[] FindOffsets(byte* byteptr_t) { return null; }

        /// <summary>
        /// Gets amount of textures in the tpk block.
        /// </summary>
        /// <param name="byteptr_t">Pointer to the tpk block array.</param>
        /// <param name="offset">Partial 1 part2 offset in the tpk block array.</param>
        /// <returns>Number of textures in the tpk block.</returns>
        protected virtual unsafe int GetTextureCount(byte* byteptr_t, int offset) { return 0; }

        /// <summary>
        /// Gets tpk header information.
        /// </summary>
        /// <param name="byteptr_t">Pointer to the tpk block array.</param>
        /// <param name="offset">Partial 1 part1 offset in the tpk block array.</param>
        protected virtual unsafe void GetHeaderInfo(byte* byteptr_t, int offset) { }

        /// <summary>
        /// Gets list of keys of the textures in the tpk block array.
        /// </summary>
        /// <param name="byteptr_t">Pointer to the tpk block array.</param>
        /// <param name="offset">Partial 1 part2 offset in the tpk block array.</param>
        protected virtual unsafe void GetKeyList(byte* byteptr_t, int offset) { }

        /// <summary>
        /// Gets list of compressions of the textures in the tpk block array.
        /// </summary>
        /// <param name="byteptr_t">Pointer to the tpk block array.</param>
        /// <param name="offset">Partial 1 part5 offset in the tpk block array.</param>
        protected virtual unsafe void GetCompressionList(byte* byteptr_t, int offset) { }

        /// <summary>
        /// Gets list of offsets and sizes of the texture headers in the tpk block array.
        /// </summary>
        /// <param name="byteptr_t">Pointer to the tpk block array.</param>
        /// <param name="offset">Partial 1 part4 offset in the tpk block array.</param>
        /// <returns>Array of offsets and sizes of texture headers.</returns>
        protected virtual unsafe int[,] GetTextureHeaders(byte* byteptr_t, int offset) { return null; }
    }
}