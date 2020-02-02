using System.Collections.Generic;



namespace GlobalLib.Support.Carbon.Parts.CarParts
{
    public class CarSpoilerType
    {
        public string CarTypeInfo { get; set; }
        public string Spoiler { get; set; }
        public string SpoilerAS { get; set; }
    }

    public class Spoilers
    {
        private byte[] data;

        /// <summary>
        /// Game index to which the class belongs to.
        /// </summary>
        public int GameINT { get => (int)Core.GameINT.Carbon; }

        /// <summary>
        /// Game string to which the class belongs to.
        /// </summary>
        public string GameSTR { get => Core.GameSTR.Carbon; }

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

                *(uint*)dataptr_t = *(uint*)byteptr_t;

                while (offset < this.data.Length)
                {
                    uint key = *(uint*)(byteptr_t + offset);
                    string CName = Core.Map.Lookup(key) ?? "";

                    // Write to new array if not a spoiler
                    if (!CNames.Contains(CName))
                    {
                        *(uint*)(dataptr_t + newoff) = key;
                        offset += 4;
                        newoff += 4;
                        continue;
                    }

                    // Else find collection name and extract
                    var CarSlot = new CarSpoilerType();
                    CarSlot.CarTypeInfo = CName;

                    uint SpoilerKey = *(uint*)(byteptr_t + offset + 0xC);
                    uint SpoilerASKey = *(uint*)(byteptr_t + offset + 0x10);
                    switch (SpoilerKey)
                    {
                        case 0xE8E9C8A4:
                            CarSlot.Spoiler = Reflection.Info.Spoiler._HATCH;
                            break;
                        case 0xAE826423:
                            CarSlot.Spoiler = Reflection.Info.Spoiler._PORSCHES;
                            break;
                        case 0x497F589C:
                            CarSlot.Spoiler = Reflection.Info.Spoiler._CARRERA;
                            break;
                        default:
                            CarSlot.Spoiler = "0x" + SpoilerKey.ToString("X8");
                            break;
                    }
                    switch (SpoilerASKey)
                    {
                        case 0x645AB209:
                            CarSlot.SpoilerAS = Reflection.Info.SpoilerAS._HATCH;
                            break;
                        case 0x33C2F508:
                            CarSlot.SpoilerAS = Reflection.Info.SpoilerAS._PORSCHES;
                            break;
                        case 0x34A77E01:
                            CarSlot.SpoilerAS = Reflection.Info.SpoilerAS._CARRERA;
                            break;
                        default:
                            CarSlot.SpoilerAS = "0x" + SpoilerASKey.ToString("X");
                            break;
                    }
                    result.Add(CarSlot);
                    offset += 0x24;
                }

                *(int*)(dataptr_t + 4) = newoff - 8;
                System.Array.Resize(ref NewData, newoff);
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
            int newsize = list.Count * 0x24 + this.data.Length;
            int padding = newsize % 0x10;
            if (padding != 0)
                newsize += padding;
            int offset = this.data.Length;

            var result = new byte[newsize];
            System.Buffer.BlockCopy(this.data, 0, result, 0, this.data.Length);

            fixed (byte* byteptr_t = &result[0])
            {
                foreach (var CarSlot in list)
                {
                    uint key = Utils.Bin.Hash(CarSlot.CarTypeInfo);
                    *(uint*)(byteptr_t + offset) = key;
                    *(uint*)(byteptr_t + offset + 4) = 0x30;
                    *(uint*)(byteptr_t + offset + 8) = key;
                    *(uint*)(byteptr_t + offset + 0xC) = Utils.Bin.Hash(CarSlot.Spoiler);
                    *(uint*)(byteptr_t + offset + 0x10) = Utils.Bin.Hash(CarSlot.SpoilerAS);
                    *(uint*)(byteptr_t + offset + 0x14) = 0xC2F6EBB0;
                    offset += 0x24;
                }
                *(uint*)byteptr_t = Reflection.ID.Global.SlotTypes;
                *(int*)(byteptr_t + 4) = newsize - 8;
            }

            return result;
        }
    }
}
