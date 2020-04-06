using GlobalLib.Reflection.ID;
using GlobalLib.Support.MostWanted.Parts.CarParts;
using GlobalLib.Utils;
using System.Collections.Generic;
using System.IO;

namespace GlobalLib.Support.MostWanted
{
    public static partial class SaveData
    {
        /// <summary>
        /// Writes all car parts into the Global data.
        /// </summary>
        /// <param name="db">Database with classes.</param>
        /// <param name="bw">BinaryWriter for writing data.</param>
        private static void I_CarParts(Database.MostWanted db, BinaryWriter bw)
        {
            bw.Write(Global.CarParts);
            bw.Write(0xFFFFFFFF); // temp size

            int initial_size = (int)bw.BaseStream.Position;
            int CarIDOffset = initial_size + 0x30;
            int PartNumOffset = initial_size + 0x40;
            int padding = 0;

            var keylists = new List<uint>();
            var Intermid56 = new List<Part56>();
            var UsedPart56 = new List<Part56>();

            // Copy for processing
            for (int a1 = 0; a1 < db.SlotTypes.Part56.Count; ++a1)
                Intermid56.Add(db.SlotTypes.Part56[a1].MemoryCast());

            // Go through all cartypeinfo, set correct usagetype and keys
            foreach (var car in db.CarTypeInfos.Collections)
            {
                bool CarDoesExist = false;
                int index = 0;
                string CName = car.CollectionName;
                uint ckey = car.BinKey;
                uint okey = Bin.Hash(car.OriginalName);
                keylists.Add(ckey);
                for (index = 0; index < Intermid56.Count; ++index)
                {
                    if (okey == Intermid56[index].Key)
                    {
                        CarDoesExist = true;
                        break;
                    }
                }
                if (CarDoesExist)
                {
                    if (ckey != okey || car.Modified)
                        Intermid56[index] = new Part56(CName, (byte)index);
                }
                else
                {
                    var Class = new Part56(CName, (byte)index);
                    Intermid56.Add(Class);
                }
            }

            // Make new list of only used Part56 to write
            byte curlength = 0;
            for (int a1 = 0; a1 < Intermid56.Count; ++a1)
            {
                if (Intermid56[a1].IsCar && !keylists.Contains(Intermid56[a1].Key))
                    continue;
                Intermid56[a1].SetIndex(curlength++);
                UsedPart56.Add(Intermid56[a1]);
            }

            // Write parts 1-4
            bw.Write(db.SlotTypes.Part0.Data);
            bw.Write(db.SlotTypes.Part1.Data);
            bw.Write(db.SlotTypes.Part2.Data);
            bw.Write(db.SlotTypes.Part3.Data);
            bw.Write(db.SlotTypes.Part4.Data);

            // Write part 5
            int part5size = UsedPart56.Count * 4;
            padding = 3 - UsedPart56.Count % 4;
            if (padding != 0) part5size += padding * 4;
            bw.Write(CarParts.Part5);
            bw.Write(part5size);
            for (int a1 = 0; a1 < UsedPart56.Count; ++a1)
                bw.Write(UsedPart56[a1].Key);
            for (int a1 = 0; a1 < padding * 4; ++a1)
                bw.Write((byte)0);

            // Write part 6
            int part6size = 0;
            bw.Write(CarParts.Part6);
            int size6off = (int)bw.BaseStream.Position;
            bw.Write(0xFFFFFFFF); // temp size
            for (int a1 = 0; a1 < UsedPart56.Count; ++a1)
            {
                bw.Write(UsedPart56[a1].Data);
                part6size += UsedPart56[a1].Data.Length;
            }
            padding = 0x10 - ((part6size + 8) % 0x10);
            if (padding == 0x10) padding = 0;
            for (int a1 = 0; a1 < padding; ++a1)
                bw.Write((byte)0);
            part6size += padding;
            bw.BaseStream.Position = size6off;
            bw.Write(part6size);

            // Quick editing
            bw.BaseStream.Position = CarIDOffset;
            bw.Write(UsedPart56.Count);
            bw.BaseStream.Position = PartNumOffset;
            bw.Write(part6size / 0xE);
            bw.BaseStream.Position = initial_size - 4;
            bw.Write((int)bw.BaseStream.Length - initial_size);
            bw.BaseStream.Position = bw.BaseStream.Length;
        }
    }
}