using System;
using System.IO;
using System.Windows.Forms;



namespace GlobalLib.Support.Carbon
{
    public static partial class SaveData
    {
        /// <summary>
        /// Saves database data into GlobalA file.
        /// </summary>
        /// <param name="GlobalA_dir">Game directory.</param>
        /// <param name="db">Database of classes.</param>
        /// <returns>True if success.</returns>
        public static bool SaveGlobalA(string GlobalA_dir, Database.Carbon db)
        {
            GlobalA_dir += @"\GLOBAL\GlobalA.bun";
            byte[] GlobalABUN;
            try
            {
                GlobalABUN = File.ReadAllBytes(GlobalA_dir);
                Utils.Log.Write("Saving data into GlobalA.bun...");
            }
            catch (Exception)
            {
                if (Core.Process.MessageShow)
                    MessageBox.Show("Unable to save GlobalA.bun file. Please close all\napplications that have it opened or\ncheck its internal data.", "Failure");
                else
                    Console.WriteLine("Unable to save GlobalA.bun file.");
                return false;
            }

            // Decompress if compressed
            GlobalABUN = Utils.JDLZ.Decompress(GlobalABUN);

            using (var br = new BinaryReader(new MemoryStream(GlobalABUN)))
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