﻿using GlobalLib.Core;
using GlobalLib.Reflection.Enum;
using GlobalLib.Reflection.ID;
using GlobalLib.Utils;
using System;
using System.Collections.Generic;



namespace GlobalLib.Support.MostWanted.Parts.CarParts
{
    public class CarSpoilerType
    {
        public string CarTypeInfo { get; set; }
        public eSpoiler Spoiler { get; set; }
    }

    public class Spoilers
    {
        private byte[] data;

        /// <summary>
        /// Game index to which the class belongs to.
        /// </summary>
        public int GameINT { get => (int)Core.GameINT.MostWanted; }

        /// <summary>
        /// Game string to which the class belongs to.
        /// </summary>
        public string GameSTR { get => Core.GameSTR.MostWanted; }

        // Default constructor: initialize slottype data
        public Spoilers(byte[] data)
        {
            this.data = data;
        }

        /// <summary>
        /// Gets all spoilers from the slottype block.
        /// </summary>
        /// <returns>List of all spoilers in the slottype block.</returns>
        public unsafe List<CarSpoilerType> GetSpoilers(List<string> CNames)
        {
            if (CNames == null || CNames.Count == 0) return null;
            var result = new List<CarSpoilerType>();
            var NewData = new byte[this.data.Length];
            fixed (byte* byteptr_t = &this.data[0], dataptr_t = &NewData[0])
            {
                int newoff = 8;
                int offset = 8;
                bool reached = false; // to remove padding

                *(uint*)dataptr_t = *(uint*)byteptr_t;

                while (offset < this.data.Length)
                {
                    uint key = *(uint*)(byteptr_t + offset);
                    string CName = Map.Lookup(key, false) ?? string.Empty;

                    // Write to new array if not a spoiler or if not a padding
                    if (!reached && !CNames.Contains(CName))
                    {
                        *(uint*)(dataptr_t + newoff) = key;
                        offset += 4;
                        newoff += 4;
                        continue;
                    }

                    // Else find collection name and extract
                    reached = true;
                    var CarSlot = new CarSpoilerType();
                    CarSlot.CarTypeInfo = CName;

                    uint SpoilerKey = *(uint*)(byteptr_t + offset + 0xC);
                    if (Enum.IsDefined(typeof(eSpoiler), SpoilerKey))
                        CarSlot.Spoiler = (eSpoiler)SpoilerKey;
                    else
                        CarSlot.Spoiler = eSpoiler.SPOILER_NONE;
                    result.Add(CarSlot);
                    offset += 0x10;
                }

                *(int*)(dataptr_t + 4) = newoff - 8;
                Array.Resize(ref NewData, newoff);
            }

            // Set new array
            this.data = NewData;
            return result;
        }

        /// <summary>
        /// Sets all spoilers from the passed list and returns slottype block.
        /// </summary>
        /// <param name="list">List of spoilers to be set.</param>
        /// <returns>Slottype block as a byte array.</returns>
        public unsafe byte[] SetSpoilers(List<CarSpoilerType> list)
        {
            int newsize = list.Count * 0x10 + this.data.Length;
            int padding = 0x10 - newsize % 0x10;
            if (padding != 0x10)
                newsize += padding;
            int offset = this.data.Length;

            var result = new byte[newsize];
            Buffer.BlockCopy(this.data, 0, result, 0, this.data.Length);

            fixed (byte* byteptr_t = &result[0])
            {
                foreach (var CarSlot in list)
                {
                    uint key = Bin.Hash(CarSlot.CarTypeInfo);
                    *(uint*)(byteptr_t + offset) = key;
                    *(uint*)(byteptr_t + offset + 4) = 0x2C;
                    *(uint*)(byteptr_t + offset + 8) = key;
                    *(uint*)(byteptr_t + offset + 0xC) = (uint)CarSlot.Spoiler;
                    offset += 0x10;
                }
                *(uint*)byteptr_t = Global.SlotTypes;
                *(int*)(byteptr_t + 4) = newsize - 8;
            }

            return result;
        }
    }
}
