using GlobalLib.Reflection.ID;

namespace GlobalLib.Support.MostWanted
{
    public static partial class LoadData
    {
        /// <summary>
        /// Decompile entire carparts block into separate elements.
        /// </summary>
        /// <param name="byteptr_t">Pointer to the beginning of carparts block in Global data.</param>
        /// <param name="length">Length of the block to be read.</param>
        /// <param name="db">Database to which add classes.</param>
        private static unsafe void E_CarParts(byte* byteptr_t, uint length, Database.MostWanted db)
        {
            uint offset = 0;
            uint ID = 0;
            uint size = 0;
            byte* part5ptr_t = byteptr_t; // pointer to the part5 of the block
            byte* part6ptr_t = byteptr_t; // pointer to the part6 of the block

            while (offset < length)
            {
                ID = *(uint*)(byteptr_t + offset);
                size = *(uint*)(byteptr_t + offset + 4);
                if (offset + size > length) return; // in case of reading beyong the stream

                switch (ID)
                {
                    case CarParts.Part0:
                        db.SlotTypes.Part0.Data = CPE_Part0(byteptr_t + offset, size + 8);
                        goto default;

                    case CarParts.Part1:
                        db.SlotTypes.Part1.Data = CPE_Part1(byteptr_t + offset, size + 8);
                        goto default;

                    case CarParts.Part2:
                        db.SlotTypes.Part2.Data = CPE_Part2(byteptr_t + offset, size + 8);
                        goto default;

                    case CarParts.Part3:
                        db.SlotTypes.Part3.Data = CPE_Part3(byteptr_t + offset, size + 8);
                        goto default;

                    case CarParts.Part4:
                        db.SlotTypes.Part4.Data = CPE_Part4(byteptr_t + offset, size + 8);
                        goto default;

                    case CarParts.Part5:
                        part5ptr_t = byteptr_t + offset;
                        goto default;

                    case CarParts.Part6:
                        part6ptr_t = byteptr_t + offset;
                        goto default;

                    default:
                        offset += 8 + size;
                        break;
                }
            }
            // Disassemble part5 and part6
            CPE_Part56(part5ptr_t, part6ptr_t, db);
        }
    }
}