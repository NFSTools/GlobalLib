using System;
using System.IO;
using System.Windows.Forms;



namespace GlobalLib.Support.Carbon
{
    public static partial class LoadData
    {
        /// <summary>
        /// Loads English_Global and Labels_Global files and disassembles their blocks.
        /// </summary>
        /// <param name="Language_dir">Directory of the game.</param>
        /// <param name="db">Database of classes.</param>
        /// <returns>True if success.</returns>
        public static unsafe bool LoadLanguage(string Language_dir, ref Database.Carbon db)
        {
            Language_dir += @"\LANGUAGES\";
            byte[] LngGlobal;
            byte[] LngLabels;

            // Get everything from language files
            try
            {
                LngGlobal = File.ReadAllBytes(Language_dir + "English_Global.bin");
                LngLabels = File.ReadAllBytes(Language_dir + "Labels_Global.bin");
                Utils.Log.Write("Reading data from English_Global.bin...");
                Utils.Log.Write("Reading data from Labels_Global.bin...");
            }
            catch (Exception) // If files are opened in editing mode in another program
            {
                if (Core.Process.MessageShow)
                    MessageBox.Show("Unable to read language files. Please close all\napplications that have them opened or\ncheck their internal data.", "Failure");
                else
                    Console.WriteLine("Unable to read language files.");
                return false;
            }

            // Decompress if compressed
            LngGlobal = Utils.JDLZ.Decompress(LngGlobal);
            LngLabels = Utils.JDLZ.Decompress(LngLabels);

            // Use pointers to speed up process
            fixed (byte* strptr = &LngGlobal[0], labptr = &LngLabels[0])
            {
                db.STRBlocks = new Class.STRBlock(strptr, labptr, LngGlobal.Length, LngLabels.Length, db);
            }
            return true;
        }
    }
}