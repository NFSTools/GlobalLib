using System;
using System.IO;
using System.Windows.Forms;



namespace GlobalLib.Support.Underground2
{
    public static partial class SaveData
    {
        /// <summary>
        /// Saves database data into GlobalA file.
        /// </summary>
        /// <param name="GlobalA_dir">Game directory.</param>
        /// <param name="db">Database of classes.</param>
        /// <returns>True if success.</returns>
        public static bool SaveGlobalA(string GlobalA_dir, Database.Underground2 db)
        {
            GlobalA_dir += @"\GLOBAL\GlobalATest.bun";

            using (var br = new BinaryReader(new MemoryStream(db._GlobalABUN)))
            using (var bw = new BinaryWriter(File.Open(GlobalA_dir, FileMode.Create)))
            {
                int tpkindex = 0;

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

                        case Reflection.ID.Global.TPKBlocks:
                            while (!db.TPKBlocks[tpkindex].InGlobalA)
                                ++tpkindex;
                            I_TPKBlock(db, bw, ref tpkindex);
                            br.BaseStream.Position += WriterSlotSize;
                            break;

                        case Reflection.ID.Global.FEngFiles:
                        case Reflection.ID.Global.FNGCompress:
                            br.BaseStream.Position += WriterSlotSize;
                            break;

                        default:
                            bw.Write(WriterSlotID);
                            bw.Write(WriterSlotSize);
                            bw.Write(br.ReadBytes(WriterSlotSize));
                            break;
                    }
                }

                // Write all FEng files
                I_FNGroup(db, bw);
            }
            return true;
        }
    }
}