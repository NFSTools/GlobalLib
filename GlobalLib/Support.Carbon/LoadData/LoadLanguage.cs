using System;
using System.IO;
using System.Windows.Forms;



namespace GlobalLib.Support.Carbon
{
    public static partial class LoadData
    {
        /// <summary>
        /// Loads English_Global file and disassembles its blocks
        /// </summary>
        /// <param name="Language_dir">Directory of the game.</param>
        /// <param name="db">Database of classes.</param>
        /// <returns>True if success.</returns>
        public static unsafe bool LoadLanguage(string Language_dir, ref Database.Carbon db)
        {
            Language_dir += @"\LANGUAGES\English_Global.bin";
            byte[] LngGlobal;

            // Get everything from English_Global.bin
            try
            {
                LngGlobal = File.ReadAllBytes(Language_dir);
                Utils.Log.Write("Reading data from English_Global.bin...");
            }
            catch (Exception) // If English_Global.bin is opened in editing mode in another program
            {
                if (Core.Process.MessageShow)
                    MessageBox.Show("Unable to read English_Global.bin file. Please close all\napplications that have it opened or\ncheck its internal data.", "Failure");
                else
                    Console.WriteLine("Unable to read English_Global.bin file.");
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