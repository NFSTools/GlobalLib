using GlobalLib.Reflection.ID;

namespace GlobalLib.Support.MostWanted.Class
{
    public partial class TPKBlock
    {
        /// <summary>
        /// Assembles partial 1 part5 of the tpk block.
        /// </summary>
        /// <returns>Byte array of the partial 1 part5.</returns>
        protected override unsafe byte[] Get1Part5()
        {
            var result = new byte[8 + this.keys.Count * 0x20];
            fixed (byte* byteptr_t = &result[0])
            {
                *(uint*)byteptr_t = TPK.INFO_PART5_BLOCKID; // write ID
                *(int*)(byteptr_t + 4) = this.keys.Count * 0x20; // write size
                for (int a1 = 0; a1 < this.keys.Count; ++a1)
                {
                    *(int*)(byteptr_t + 0x10 + a1 * 0x20) = this.compressions[a1].var1;
                    *(int*)(byteptr_t + 0x14 + a1 * 0x20) = this.compressions[a1].var2;
                    *(int*)(byteptr_t + 0x18 + a1 * 0x20) = this.compressions[a1].var3;
                    *(uint*)(byteptr_t + 0x1C + a1 * 0x20) = this.compressions[a1].comp;
                }
            }
            return result;
        }
    }
}