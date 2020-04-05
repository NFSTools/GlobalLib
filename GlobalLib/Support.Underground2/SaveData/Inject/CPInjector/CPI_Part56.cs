﻿using GlobalLib.Reflection.Enum;
using GlobalLib.Reflection.ID;
using GlobalLib.Support.Underground2.Parts.CarParts;
using GlobalLib.Utils;
using System.Collections.Generic;

namespace GlobalLib.Support.Underground2
{
	public static partial class SaveData
	{
		private static byte[] CPI_Part56(Database.Underground2 db)
		{
            // Part56 list that is used for intermediate calculations
            var Intermid56 = new List<Part56>();

            // Actual used Part56 list
            var UsedPart56 = new List<Part56>();

            // This will be used in writing new car parts
            int entries = (db.SlotTypes.Part4.Data.Length - 8) / 0x24;
            int racers = 0;
            int trafs = 0;

            // MemoryCast all Part56 for processing
            for (int a1 = 0; a1 < db.SlotTypes.Part56.Count; ++a1)
                Intermid56.Add(db.SlotTypes.Part56[a1].MemoryCast());

            // Go through all cartypeinfo, set correct usagetype and keys
            foreach (var car in db.CarTypeInfos.Collections)
            {
                if (!car.Deletable) continue; // Else (if car is old) continue

                // If car is new and uses its own auto-generated carparts
                Intermid56.Add(new Part56(car.CollectionName, car.UsageType, entries, racers, trafs));
                if (car.UsageType == eUsageType.Traffic) ++trafs;
                else if (car.UsageType == eUsageType.Racer) ++racers;
            }

            // Make new list of only used Part56 to write
            int part6size = 8;
            byte curlength = 0;
            for (int a1 = 0; a1 < Intermid56.Count; ++a1)
            {
                var _56 = Intermid56[a1];
                if (_56.IsCar && !db.CarTypeInfos.TryGetCollectionIndex(_56.BelongsTo, out int _))
                    continue;
                _56.SetIndex(curlength++);
                UsedPart56.Add(_56);
                part6size += _56.Data.Length;
            }

            // Precalculate size of Part5
            int part5size = 8 + UsedPart56.Count * 4;
            int padding = 0x10 - ((part5size + 0xC) % 0x10);
            if (padding != 0x10) part5size += padding;

            // Write data to Part0
            db.SlotTypes.Part0.SetPartsNumber((part6size - 8) / 0xE);
            db.SlotTypes.Part0.SetCarsNumber(UsedPart56.Count);

            // Precalculate size of Part6
            padding = 0x10 - ((part6size + 0x4) % 0x10);
            if (padding != 0x10) part6size += padding;

            // Write all info
            var mw = new MemoryWriter(part5size + part6size);
            mw.Write(CarParts.Part5);
            mw.Write(part5size - 8);
            foreach (var _56 in UsedPart56)
                mw.Write(_56.Key);
            mw.Position = part5size;
            mw.Write(CarParts.Part6);
            mw.Write(part6size - 8);
            foreach (var _56 in UsedPart56)
                mw.Write(_56.Data);

            return mw.Data;
        }
    }
}