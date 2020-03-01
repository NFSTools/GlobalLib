﻿namespace GlobalLib.Support.Carbon
{
    public static partial class LoadData
    {
        private static unsafe void CPE_Part56(byte* part5ptr_t, byte* part6ptr_t, Database.Carbon db)
        {
            int len5 = *(int*)(part5ptr_t + 4) + 8; // size of part5
            int len6 = *(int*)(part6ptr_t + 4) + 8; // size of part6

            // Exclude padding
            while (*(int*)(part5ptr_t + len5 - 4) == 0)
                len5 -= 4;
            while (*(int*)(part6ptr_t + len6 - 4) == 0)
                len6 -= 4;

            int off5 = 8; // offset in part5
            int off6 = 8; // offset in part6
            int size = 0; // size of one part in part6

            // Validation check
            int check = *(part6ptr_t + len6 - 3) + 1;
            int total = (len5 - 8) / 4;
            if (check < total) len5 = check * 4 + 8;

            db.SlotTypes.Part56 = new System.Collections.Generic.List<Parts.CarParts.Part56>();
            var CarCNames = new System.Collections.Generic.List<uint>();

            for (int a1 = 0; a1 < db.CarTypeInfos.Count; ++a1)
                CarCNames.Add(db.CarTypeInfos[a1].BinKey);

            while (off5 < len5)
            {
                uint ckey = *(uint*)(part5ptr_t + off5);
                if (ckey == 0) break; // padding means end
                bool IsCar = false;
                byte current = 0;
                byte index = *(part6ptr_t + off6 + 1);
                while (true)
                {
                    if (off6 + size + 1 >= len6) break;
                    current = *(part6ptr_t + off6 + size + 1);
                    if (current != index) break;
                    else size += 4;
                }
                if (CarCNames.Contains(ckey)) IsCar = true;
                var Part = new Parts.CarParts.Part56(ckey, part6ptr_t + off6, size, IsCar);
                db.SlotTypes.Part56.Add(Part);
                off5 += 4;
                off6 += size;
                size = 0;
            }
        }
    }
}