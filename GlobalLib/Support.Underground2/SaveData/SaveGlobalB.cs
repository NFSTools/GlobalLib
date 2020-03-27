using System;
using System.IO;
using System.Windows.Forms;



namespace GlobalLib.Support.Underground2
{
    public static partial class SaveData
    {
        /// <summary>
        /// Saves database data into GlobalB file.
        /// </summary>
        /// <param name="GlobalB_dir">Game directory.</param>
        /// <param name="db">Database of classes.</param>
        /// <returns>True if success.</returns>
        public static bool SaveGlobalB(string GlobalB_dir, Database.Underground2 db)
        {
            GlobalB_dir += @"\GLOBAL\GlobalB.lzc";

            using (var br = new BinaryReader(new MemoryStream(db._GlobalBLZC)))
            using (var bw = new BinaryWriter(File.Open(GlobalB_dir, FileMode.Create)))
            {
                bool careerdone = false;
                int tpkindex = 0;
                I_Materials(db, bw);

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
                                break;
                            }
                            else
                                goto default;

                        case Reflection.ID.Global.Materials:
                            br.BaseStream.Position += WriterSlotSize;
                            break;

                        case Reflection.ID.Global.TPKBlocks:
                            while (db.TPKBlocks[tpkindex].InGlobalA)
                                ++tpkindex;
                            I_TPKBlock(db, bw, ref tpkindex);
                            br.BaseStream.Position += WriterSlotSize;
                            break;

                        case Reflection.ID.Global.ELabGlobal:
                            I_GlobalLibBlock(bw);
                            goto default;

                        case Reflection.ID.Global.CarTypeInfo:
                            I_CarTypeInfo(db, bw);
                            br.BaseStream.Position += WriterSlotSize;
                            break;

                        case Reflection.ID.Global.CarSkins:
                            I_CarSkins(db, bw);
                            br.BaseStream.Position += WriterSlotSize;
                            break;

                        case Reflection.ID.Global.SlotTypes:
                            I_SlotType(db, bw);
                            br.BaseStream.Position += WriterSlotSize;
                            break;

                        case Reflection.ID.Global.CarParts:
                            I_CarParts(db, bw);
                            br.BaseStream.Position += WriterSlotSize;
                            break;

                        case Reflection.ID.Global.Tracks:
                            I_Tracks(db, bw);
                            br.BaseStream.Position += WriterSlotSize;
                            break;

                        case Reflection.ID.Global.SunInfos:
                            I_SunInfos(db, bw);
                            br.BaseStream.Position += WriterSlotSize;
                            break;

                        case Reflection.ID.Global.XenonTrig:
                            I_GlobalLibBlock(bw);
                            goto default;

                        case Reflection.ID.Global.CareerInfo:
                            if (careerdone) goto default;
                            I_GlobalLibBlock(bw);
                            Framework.CareerManager.Assemble(bw, db);
                            br.BaseStream.Position += WriterSlotSize;
                            careerdone = true;
                            break;

                        case Reflection.ID.Global.PresetRides:
                            I_PresetRides(db, bw);
                            br.BaseStream.Position += WriterSlotSize;
                            break;

                        case Reflection.ID.Global.FloatChunk:
                            I_GlobalLibBlock(bw);
                            goto default;

                        default:
                            bw.Write(WriterSlotID);
                            bw.Write(WriterSlotSize);
                            bw.Write(br.ReadBytes(WriterSlotSize));
                            break;
                    }
                }
            }
            return true;
        }
    }
}