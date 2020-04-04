using System;
using System.IO;
using System.Windows.Forms;



namespace GlobalLib.Support.Underground2
{
    public static partial class SaveData
    {
        /// <summary>
        /// Saves database data into English file.
        /// </summary>
        /// <param name="Language_dir">Game directory.</param>
        /// <param name="db">Database of classes.</param>
        /// <returns>True if success.</returns>
        public static bool SaveLanguage(string Language_dir, Database.Underground2 db)
        {
            Language_dir += @"\LANGUAGES\";

            using (var br = new BinaryReader(new MemoryStream(db._LngGlobal)))
            using (var bw = new BinaryWriter(File.Open(Language_dir + "English.bin", FileMode.Create)))
            {
                bool finished = false;
                while (br.BaseStream.Position < br.BaseStream.Length)
                {
                    // Set Offset, ID and Size values, read starting in the beginning of the file
                    uint WriterSlotOffset = (uint)br.BaseStream.Position;
                    uint WriterSlotID = br.ReadUInt32();
                    int WriterSlotSize = br.ReadInt32();

                    // If one of the necessary slots is reached, replace it
                    switch (WriterSlotID)
                    {
                        case Reflection.ID.Global.STRBlocks:
                            if (!finished)
                            {
                                bw.Write(db.STRBlocks[0].Assemble());
                                br.BaseStream.Position += WriterSlotSize;
                                finished = true;
                                break;
                            }
                            else
                                goto default;

                        default:
                            bw.Write(WriterSlotID);
                            bw.Write(WriterSlotSize);
                            bw.Write(br.ReadBytes(WriterSlotSize));
                            break;
                    }
                }
            }

            using (var br = new BinaryReader(new MemoryStream(db._LngLabels)))
            using (var bw = new BinaryWriter(File.Open(Language_dir + "Labels.bin", FileMode.Create)))
            {
                bool finished = false;
                while (br.BaseStream.Position < br.BaseStream.Length)
                {
                    // Set Offset, ID and Size values, read starting in the beginning of the file
                    uint WriterSlotOffset = (uint)br.BaseStream.Position;
                    uint WriterSlotID = br.ReadUInt32();
                    int WriterSlotSize = br.ReadInt32();

                    // If one of the necessary slots is reached, replace it
                    switch (WriterSlotID)
                    {
                        case Reflection.ID.Global.STRBlocks:
                            if (!finished)
                            {
                                bw.Write(db.STRBlocks[0].ParseLabels());
                                br.BaseStream.Position += WriterSlotSize;
                                finished = true;
                                break;
                            }
                            else
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