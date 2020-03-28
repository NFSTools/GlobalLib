﻿namespace GlobalLib.Support.Underground2
{
    public static partial class LoadData
    {
        private static unsafe void CPE_Part56(byte* part5ptr_t, byte* part6ptr_t, Database.Underground2 db)
        {
            int len5 = *(int*)(part5ptr_t + 4); // size of part5
            int len6 = *(int*)(part6ptr_t + 4); // size of part6

            if (len5 + 8 < Framework.Assert.CPPart5_AssertSize)
                throw new System.IO.FileLoadException("Detected corrupted GlobalB.lzc CarParts block. Unable to load database.");
            if (len6 + 8 < Framework.Assert.CPPart6_AssertSize)
                throw new System.IO.FileLoadException("Detected corrupted GlobalB.lzc CarParts block. Unable to load database.");

            // Exclude padding
            while (*(int*)(part5ptr_t + len5 + 4) == 0)
                len5 -= 4;
            while (*(int*)(part6ptr_t + len6 + 4) == 0)
                len6 -= 4;
            len6 = len6 / 0xE * 0xE + 8;

            int off5 = 8; // offset in part5
            int off6 = 8; // offset in part6
            int size = 0; // size of one part in part6

            // Validation check
            int check = *(part6ptr_t + len6 - 7) + 1;
            int total = len5 / 4;
            if (check < total) len5 = check * 4 + 8;

            db.SlotTypes.Part56 = new System.Collections.Generic.List<Parts.CarParts.Part56>();
            var CarCNames = new System.Collections.Generic.List<uint>();

            foreach (var car in db.CarTypeInfos.Collections)
                CarCNames.Add(car.BinKey);

            while (off5 < len5 + 8 && db.SlotTypes.Part56.Count < 75)
            {
                uint ckey = *(uint*)(part5ptr_t + off5);
                if (ckey == 0) break; // padding means end
                bool IsCar = false;
                byte current = 0;
                byte index = *(part6ptr_t + off6 + 7);
                while (true)
                {
                    if (off6 + size + 7 >= len6) break;
                    current = *(part6ptr_t + off6 + size + 7);
                    if (current != index) break;
                    else size += 0xE;
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