using System;
using System.IO;
using System.Windows.Forms;



namespace GlobalLib.Support.Carbon
{
    public static partial class SaveData
    {
        /// <summary>
        /// Saves database data into GlobalB file.
        /// </summary>
        /// <param name="GlobalB_dir">Game directory.</param>
        /// <param name="db">Database of classes.</param>
        /// <returns>True if success.</returns>
        public static bool SaveGlobalB(string GlobalB_dir, Database.Carbon db)
        {
            GlobalB_dir += @"\GLOBAL\GlobalBTest.lzc";

            using (var br = new BinaryReader(new MemoryStream(db._GlobalBLZC)))
            using (var bw = new BinaryWriter(File.Open(GlobalB_dir, FileMode.Create)))
            {
                int tpkindex = 0;
                I_Materials(db, bw);
                I_GlobalLibBlock(db, bw);
                bool padding_was_last = false; // to keep track of last id (if true, last id is padding id)
                int total_pad_size = 0; // length of last padding array (including id and size)

                while (br.BaseStream.Position < br.BaseStream.Length)
                {
                    // Set Offset, ID and Size values, read starting in the beginning of the file
                    uint WriterSlotOffset = (uint)br.BaseStream.Position;
                    uint WriterSlotID = br.ReadUInt32();
                    int WriterSlotSize = br.ReadInt32();

                    // If one of the necessary slots is reached, replace it
                    switch (WriterSlotID)
                    {
                        case 0:
                            uint key = br.ReadUInt32();
                            br.BaseStream.Position -= 4;
                            if (key == Reflection.ID.Global.GlobalLib)
                            {
                                br.BaseStream.Position += WriterSlotSize;
                                padding_was_last = false;
                                break;
                            }
                            else
                            {
                                bw.Write(WriterSlotID);
                                bw.Write(WriterSlotSize);
                                bw.Write(br.ReadBytes(WriterSlotSize));
                                padding_was_last = true;
                                total_pad_size = WriterSlotSize + 8;
                                break;
                            }

                        case Reflection.ID.Global.Materials:
                            br.BaseStream.Position += WriterSlotSize;
                            padding_was_last = false;
                            break;

                        case Reflection.ID.Global.TPKBlocks:
                            while (db.TPKBlocks[tpkindex].InGlobalA)
                                ++tpkindex;
                            I_TPKBlock(db, bw, ref tpkindex);
                            br.BaseStream.Position += WriterSlotSize;
                            padding_was_last = false;
                            break;

                        case Reflection.ID.Global.CarTypeInfo:
                            I_CarTypeInfo(db, bw);
                            br.BaseStream.Position += WriterSlotSize;
                            padding_was_last = false;
                            break;

                        case Reflection.ID.Global.PresetRides:
                            I_PresetRides(db, bw);
                            br.BaseStream.Position += WriterSlotSize;
                            padding_was_last = false;
                            break;

                        case Reflection.ID.Global.PresetSkins:
                            I_PresetSkins(db, bw);
                            br.BaseStream.Position += WriterSlotSize;
                            padding_was_last = false;
                            break;

                        case Reflection.ID.Global.CarParts:
                            I_CarParts(db, bw);
                            br.BaseStream.Position += WriterSlotSize;
                            padding_was_last = false;
                            break;

                        case Reflection.ID.Global.Collisions:
                            I_Collisions(db, bw);
                            br.BaseStream.Position += WriterSlotSize;
                            padding_was_last = false;
                            break;

                        case Reflection.ID.Global.SlotTypes:
                            I_SlotType(db, bw);
                            br.BaseStream.Position += WriterSlotSize;
                            padding_was_last = false;
                            break;

                        case Reflection.ID.Global.PaddingReq:
                            if (!padding_was_last || total_pad_size < 0x10)
                                bw.Write(Utils.EA.Resolve.GetPaddingArray((int)bw.BaseStream.Length, 0x10));
                            else if (bw.BaseStream.Length % 0x10 != 0)
                                bw.Write(Utils.EA.Resolve.GetPaddingArray((int)bw.BaseStream.Length, 0x10));
                            goto default;

                        default:
                            bw.Write(WriterSlotID);
                            bw.Write(WriterSlotSize);
                            bw.Write(br.ReadBytes(WriterSlotSize));
                            padding_was_last = false;
                            break;
                    }
                }
            }
            return true;
        }
    }
}