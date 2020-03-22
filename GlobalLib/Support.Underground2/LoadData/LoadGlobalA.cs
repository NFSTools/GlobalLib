using System;
using System.IO;
using System.Windows.Forms;



namespace GlobalLib.Support.Underground2
{
    public static partial class LoadData
    {
        /// <summary>
        /// Loads GlobalA file and disassembles its blocks
        /// </summary>
        /// <param name="GlobalA_dir">Directory of the game.</param>
        /// <param name="db">Database of classes.</param>
        /// <returns>True if success.</returns>
        public static unsafe bool LoadGlobalA(string GlobalA_dir, Database.Underground2 db)
        {
            GlobalA_dir += @"\GLOBAL\GlobalA.bun";

            // Get everything from GlobalA.bun
            try
            {
                db._GlobalABUN = File.ReadAllBytes(GlobalA_dir);
                Utils.Log.Write("Reading data from GlobalA.bun...");
            }
            catch (Exception) // If GlobalA.bun is opened in editing mode in another program
            {
                if (Core.Process.MessageShow)
                    MessageBox.Show("Unable to read GlobalA.bun file. Please close all\napplications that have it opened or\ncheck its internal data.", "Failure");
                else
                    Console.WriteLine("Unable to read GlobalA.bun file.");
                return false;
            }

            // Decompress if compressed
            db._GlobalABUN = Utils.JDLZ.Decompress(db._GlobalABUN);

            // Use pointers to speed up process
            fixed (byte* byteptr_t = &db._GlobalABUN[0])
            {
                uint offset = 0; // to calculate current offset
                uint ID = 0; // to get the ID of the block being read
                uint size = 0; // to get the size of the block being read

                while (offset < db._GlobalABUN.Length)
                {
                    ID = *(uint*)(byteptr_t + offset); // read ID
                    size = *(uint*)(byteptr_t + offset + 4); // read size
                    if (offset + size > db._GlobalABUN.Length)
                    {
                        if (Core.Process.MessageShow)
                            MessageBox.Show("GlobalA: unable to read beyond the stream.", "Failure");
                        else
                            Console.WriteLine("GlobalA: unable to read beyond the stream.");
                        return false;
                    }

                    switch (ID)
                    {
                        case Reflection.ID.Global.TPKBlocks:
                            int count = db.TPKBlocks.Count;
                            db.TPKBlocks.Add(new Class.TPKBlock(byteptr_t + offset, count, db));
                            db.TPKBlocks[count].InGlobalA = true;
                            break;

                        case Reflection.ID.Global.FEngFiles:
                        case Reflection.ID.Global.FNGCompress:
                            E_FNGroup(byteptr_t + offset, size + 8, db);
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