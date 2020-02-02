using System;
using System.IO;
using System.Windows.Forms;



namespace GlobalLib.Support.Carbon
{
    public static partial class LoadData
    {
        /// <summary>
        /// Loads GlobalA file and disassembles its blocks
        /// </summary>
        /// <param name="GlobalA_dir">Directory of the game.</param>
        /// <param name="db">Database of classes.</param>
        /// <returns>True if success.</returns>
        public static unsafe bool LoadGlobalA(string GlobalA_dir, ref Database.Carbon db)
        {
            GlobalA_dir += @"\GLOBAL\GlobalA.bun";
            byte[] GlobalABUN;

            // Get everything from GlobalB.lzc
            try
            {
                GlobalABUN = File.ReadAllBytes(GlobalA_dir);
                Utils.Log.Write("Reading data from GlobalA.bun...");
            }
            catch (Exception) // If GlobalB.lzc is opened in editing mode in another program
            {
                if (Core.Process.MessageShow)
                    MessageBox.Show("Unable to read GlobalA.bun file. Please close all\napplications that have it opened or\ncheck its internal data.", "Failure");
                else
                    Console.WriteLine("Unable to read GlobalA.bun file.");
                return false;
            }

            // Decompress if compressed
            GlobalABUN = Utils.JDLZ.Decompress(GlobalABUN);

            // Use pointers to speed up process
            fixed (byte* byteptr_t = &GlobalABUN[0])
            {
                uint offset = 0; // to calculate current offset
                uint ID = 0; // to get the ID of the block being read
                uint size = 0; // to get the size of the block being read

                while (offset < GlobalABUN.Length)
                {
                    ID = *(uint*)(byteptr_t + offset); // read ID
                    size = *(uint*)(byteptr_t + offset + 4); // read size
                    if (offset + size > GlobalABUN.Length)
                    {
                        if (Core.Process.MessageShow)
                            MessageBox.Show("GlobalA: unable to read beyond the stream.", "Failure");
                        else
                            Console.WriteLine("GlobalA: unable to read beyond the stream.");
                        return false;
                    }

                    switch (ID)
                    {
                        case Reflection.ID.Global.TPK:
                            int count = db.TPKBlocks.Count;
                            db.TPKBlocks.Add(new Class.TPKBlock(byteptr_t + offset, count));
                            db.TPKBlocks[count].InGlobalA = true;
                            break;

                        case Reflection.ID.Global.FEngFiles:
                        case Reflection.ID.Global.FNGCompress:
                            E_FNGroup(byteptr_t + offset, size + 8, ref db);
                            break;

                        default:
                            break;
                    }
                    offset += 8 + size; // advance in offset
                }
            }
            return true;
        }
    }
}