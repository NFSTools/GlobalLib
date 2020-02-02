namespace GlobalLib.Support.Shared.Class
{
    public partial class TPKBlock
    {
        /// <summary>
        /// Assembles tpk block into a byte array.
        /// </summary>
        /// <returns>Byte array of the tpk block.</returns>
        public virtual unsafe byte[] Assemble() { return null; }

        /// <summary>
        /// Sorts textures by their binary memory hashes.
        /// </summary>
        protected virtual unsafe void TextureSort() { }

        /// <summary>
        /// Checks texture keys and tpk keys for matching.
        /// </summary>
        protected virtual unsafe void CheckKeys() { }

        /// <summary>
        /// Checks texture compressions and tpk compressions for matching.
        /// </summary>
        protected virtual unsafe void CheckComps() { }

        /// <summary>
        /// Assembles partial 1 part1 of the tpk block.
        /// </summary>
        /// <returns>Byte array of the partial 1 part1.</returns>
        protected virtual unsafe byte[] Get1Part1() { return null; }

        /// <summary>
        /// Assembles partial 1 part2 of the tpk block.
        /// </summary>
        /// <returns>Byte array of the partial 1 part2.</returns>
        protected virtual unsafe byte[] Get1Part2() { return null; }

        /// <summary>
        /// Assembles partial 1 part4 of the tpk block.
        /// </summary>
        /// <returns>Byte array of the partial 1 part4.</returns>
        protected virtual unsafe byte[] Get1Part4() { return null; }

        /// <summary>
        /// Assembles partial 1 part5 of the tpk block.
        /// </summary>
        /// <returns>Byte array of the partial 1 part5.</returns>
        protected virtual unsafe byte[] Get1Part5() { return null; }

        /// <summary>
        /// Assembles partial 2 part1 of the tpk block.
        /// </summary>
        /// <returns>Byte array of the partial 2 part1.</returns>
        protected virtual unsafe byte[] Get2Part1() { return null; }

        /// <summary>
        /// Assembles partial 2 part2 of the tpk block.
        /// </summary>
        /// <returns>Byte array of the partial 2 part2.</returns>
        protected virtual unsafe byte[] Get2Part2() { return null; }
    }
}