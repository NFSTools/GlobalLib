namespace GlobalLib.Support.Underground2.Class
{
    public partial class TPKBlock
    {
        /// <summary>
        /// Gets list of compressions of the textures in the tpk block array.
        /// </summary>
        /// <param name="byteptr_t">Pointer to the tpk block array.</param>
        /// <param name="offset">Partial 1 part5 offset in the tpk block array.</param>
        protected override unsafe void GetCompressionList(byte* byteptr_t, int offset)
        {
            if (offset == -1) return;  // if Part5 does not exist
            if (*(uint*)(byteptr_t + offset) != Reflection.ID.TPK.INFO_PART5_BLOCKID)
                return; // check Part5 ID

            int ReaderSize = 8 + *(int*)(byteptr_t + offset + 4);
            int current = 0x10;
            while (current < ReaderSize)
            {
                uint comp = *(uint*)(byteptr_t + offset + current + 12);
                if (Utils.EA.Comp.IsComp(comp))
                {
                    var Slot = new Shared.Parts.TPKParts.CompSlot();
                    Slot.var1 = *(int*)(byteptr_t + offset + current);
                    Slot.var2 = *(int*)(byteptr_t + offset + current + 4);
                    Slot.var3 = *(int*)(byteptr_t + offset + current + 8);
                    Slot.comp = comp;
                    this.compressions.Add(Slot);
                }
                current += 0x20;
            }
        }
    }
}