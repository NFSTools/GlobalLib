using System;
using System.IO;
using System.Windows.Forms;



namespace GlobalLib.Support.MostWanted
{
    public static partial class LoadData
    {
        /// <summary>
        /// Loads English file and disassembles its blocks
        /// </summary>
        /// <param name="Language_dir">Directory of the game.</param>
        /// <param name="db">Database of classes.</param>
        /// <returns>True if success.</returns>
        public static unsafe bool LoadLanguage(string Language_dir, ref Database.MostWanted db)
        {
            Language_dir += @"\LANGUAGES\English.bin";
            byte[] LngGlobal;

            // Get everything from English.bin
            try
            {
                LngGlobal = File.ReadAllBytes(Language_dir);
                Utils.Log.Write("Reading data from English.bin...");
            }
            catch (Exception) // If English.bin is opened in editing mode in another program
            {
                if (Core.Process.MessageShow)
                    MessageBox.Show("Unable to read English.bin file. Please close all\napplications that have it opened or\ncheck its internal data.", "Failure");
                else
                    Console.WriteLine("Unable to read English.bin file.");
                return false;
            }

            // Decompress if compressed
            LngGlobal = Utils.JDLZ.Decompress(LngGlobal);

            // Use pointers to speed up process
            fixed (byte* byteptr_t = &LngGlobal[0])
            {
                db.STRBlocks = new Class.STRBlock(byteptr_t, LngGlobal.Length, db);
            }
            return true;
        }
    }
}