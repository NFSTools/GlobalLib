using System;
using System.IO;
using System.Windows.Forms;



namespace GlobalLib.Support.MostWanted
{
    public static partial class SaveData
    {
        /// <summary>
        /// Saves database data into English file.
        /// </summary>
        /// <param name="GlobalA_dir">Game directory.</param>
        /// <param name="db">Database of classes.</param>
        /// <returns>True if success.</returns>
        public static bool SaveLanguage(string Language_dir, Database.MostWanted db)
        {
            Language_dir += @"\LANGUAGES\English.bin";
            byte[] LngGlobal;
            try
            {
                LngGlobal = File.ReadAllBytes(Language_dir);
                Utils.Log.Write("Saving data into English.bin...");
            }
            catch (Exception)
            {
                if (Core.Process.MessageShow)
                    MessageBox.Show("Unable to save English.bin file. Please close all\napplications that have it opened or\ncheck its internal data.", "Failure");
                else
                    Console.WriteLine("Unable to save English.bin file.");
                return false;
            }

            // Decompress if compressed
            LngGlobal = Utils.JDLZ.Decompress(LngGlobal);

            using (var br = new BinaryReader(new MemoryStream(LngGlobal)))
            using (var bw = new BinaryWriter(File.Open(Language_dir, FileMode.Create)))
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
                                bw.Write(db.STRBlocks.Assemble());
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