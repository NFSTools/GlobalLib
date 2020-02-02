namespace GlobalLib.Support.MostWanted
{
    public static partial class SaveData
    {
        /// <summary>
        /// Writes all car parts into the Global data.
        /// </summary>
        /// <param name="db">Database with classes.</param>
        /// <param name="bw">BinaryWriter for writing data.</param>
        private static void I_CarParts(Database.MostWanted db, System.IO.BinaryWriter bw)
        {
            bw.Write(Reflection.ID.Global.CarParts);
            bw.Write(0xFFFFFFFF); // temp size

            int initial_size = (int)bw.BaseStream.Position;
            int CarIDOffset = initial_size + 0x30;
            int PartNumOffset = initial_size + 0x40;
            int padding = 0;

            var keylists = new System.Collections.Generic.List<uint>();
            var UsedPart56 = new System.Collections.Generic.List<Parts.CarParts.Part56>();

            // Go through all cartypeinfo, set correct usagetype and keys
            for (int a1 = 0; a1 < db.CarTypeInfos.Count; ++a1)
            {
                bool CarDoesExist = false;
                int index = 0;
                string CName = db.CarTypeInfos[a1].CollectionName;
                uint ckey = db.CarTypeInfos[a1].BinKey;
                uint okey = Utils.Bin.Hash(db.CarTypeInfos[a1].OriginalName);
                keylists.Add(ckey);
                for (index = 0; index < db.SlotTypes.Part56.Count; ++index)
                {
                    if (okey == db.SlotTypes.Part56[index].Key)
                    {
                        CarDoesExist = true;
                        break;
                    }
                }
                if (CarDoesExist)
                {
                    if (ckey != okey || db.CarTypeInfos[a1].Modified)
                        db.SlotTypes.Part56[index] = new Parts.CarParts.Part56(CName, (byte)index);
                }
                else
                {
                    var Class = new Parts.CarParts.Part56(CName, (byte)index);
                    db.SlotTypes.Part56.Add(Class);
                }
            }

            // Make new list of used Part56
            byte curlength = 0;
            for (int a1 = 0; a1 < db.SlotTypes.Part56.Count; ++a1)
            {
                if (db.SlotTypes.Part56[a1].IsCar && !keylists.Contains(db.SlotTypes.Part56[a1].Key))
                    continue;
                db.SlotTypes.Part56[a1].SetIndex(curlength++);
                UsedPart56.Add(db.SlotTypes.Part56[a1]);
            }

            db.SlotTypes.Part56 = UsedPart56;

            // Write parts 1-4
            bw.Write(db.SlotTypes.Part0.Data);
            bw.Write(db.SlotTypes.Part1.Data);
            bw.Write(db.SlotTypes.Part2.Data);
            bw.Write(db.SlotTypes.Part3.Data);
            bw.Write(db.SlotTypes.Part4.Data);

            // Write part 5
            int part5size = db.SlotTypes.Part56.Count * 4;
            padding = 0xC - (part5size % 0x10);
            if (padding == 0xC) padding = 0;
            part5size += padding;
            bw.Write(Reflection.ID.CarParts.Part5);
            bw.Write(part5size);
            for (int a1 = 0; a1 < db.SlotTypes.Part56.Count; ++a1)
                bw.Write(db.SlotTypes.Part56[a1].Key);
            for (int a1 = 0; a1 < padding; ++a1)
                bw.Write((byte)0);

            // Write part 6
            int part6size = 0;
            bw.Write(Reflection.ID.CarParts.Part6);
            int size6off = (int)bw.BaseStream.Position;
            bw.Write(0xFFFFFFFF); // temp size
            for (int a1 = 0; a1 < db.SlotTypes.Part56.Count; ++a1)
            {
                bw.Write(db.SlotTypes.Part56[a1].Data);
                part6size += db.SlotTypes.Part56[a1].Data.Length;
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
            bw.Write(db.SlotTypes.Part56.Count);
            bw.BaseStream.Position = PartNumOffset;
            bw.Write(part6size / 0xE);
            bw.BaseStream.Position = initial_size - 4;
            bw.Write((int)bw.BaseStream.Length - initial_size);
            bw.BaseStream.Position = bw.BaseStream.Length;
        }
    }
}