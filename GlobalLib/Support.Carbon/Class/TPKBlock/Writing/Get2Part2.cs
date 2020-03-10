namespace GlobalLib.Support.Carbon.Class
{
    public partial class TPKBlock
    {
        /// <summary>
        /// Assembles partial 2 part2 of the tpk block.
        /// </summary>
        /// <returns>Byte array of the partial 2 part2.</returns>
        protected override unsafe byte[] Get2Part2()
        {
            int size = this.Textures[this.Textures.Count - 1].Offset;
            size += this.Textures[this.Textures.Count - 1].Size;
            int difference = 0x80 - (size % 0x80);
            if (difference != 0x80) // last padding
                size += difference;

            var result = new byte[size + 0x80];

            // Copy all data to the array
            for (int a1 = 0; a1 < this.keys.Count; ++a1)
            {
                if (this.Textures[a1].Compression == Utils.EA.Comp.GetString(Reflection.ID.EAComp.P8_08))
                    System.Buffer.BlockCopy(this.Textures[a1].Data, 0, result, this.Textures[a1].PaletteOffset + 0x80, this.Textures[a1].PaletteSize + this.Textures[a1].Size);
                else
                    System.Buffer.BlockCopy(this.Textures[a1].Data, 0, result, this.Textures[a1].Offset + 0x80, this.Textures[a1].Size);
            }

            fixed (byte* byteptr_t = &result[8])
            {
                *(uint*)(byteptr_t - 8) = Reflection.ID.TPK.DATA_PART2_BLOCKID; // write ID
                *(int*)(byteptr_t - 4) = size + 0x78; // write size
                for (int a1 = 0; a1 < 30; ++a1)
                    *(uint*)(byteptr_t + a1 * 4) = 0x11111111;
            }
            return result;
        }
    }
}