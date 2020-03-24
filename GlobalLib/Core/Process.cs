namespace GlobalLib.Core
{
    /// <summary>
    /// Defines the game process set during the run of the application.
    /// </summary>
    public static class Process
    {
        /// <summary>
        /// Current game set based on the Game enum.
        /// </summary>
        public static int Set { get; set; }

        /// <summary>
        /// If true, enables showing message boxes when exceptions are being thrown.
        /// </summary>
        public static bool MessageShow { get; set; }

        /// <summary>
        /// Current directory of the game chosen.
        /// </summary>
        public static string GlobalDir { get; set; }

        /// <summary>
        /// Loads data from Global files in the directory chosen.
        /// </summary>
        /// <param name="database">Carbon database to be loaded into.</param>
        /// <returns>True if loading was successful.</returns>
        public static bool LoadData(Database.Carbon database)
        {
            if (Set != (int)GameINT.Carbon)
            {
                if (MessageShow)
                    System.Windows.Forms.MessageBox.Show("Game set is not valid for Carbon database load.", "Warning");
                else
                    System.Console.WriteLine("Game set is not valid for Carbon database load.");
                return false;
            }
            Initialize.Init();
            bool A = Support.Carbon.LoadData.LoadVaults(GlobalDir);
            bool B = Support.Carbon.LoadData.LoadGlobalA(GlobalDir, database);
            bool C = Support.Carbon.LoadData.LoadGlobalB(GlobalDir, database);
            bool D = Support.Carbon.LoadData.LoadLanguage(GlobalDir, database);
            return A && B && C && D;
        }

        /// <summary>
        /// Loads data from Global files in the directory chosen.
        /// </summary>
        /// <param name="database">MostWanted database to be loaded into.</param>
        /// <returns>True if loading was successful.</returns>
        public static bool LoadData(Database.MostWanted database)
        {
            if (Set != (int)GameINT.MostWanted)
            {
                if (MessageShow)
                    System.Windows.Forms.MessageBox.Show("Game set is not valid for MostWanted database load.", "Warning");
                else
                    System.Console.WriteLine("Game set is not valid for MostWanted database load.");
                return false;
            }
            Initialize.Init();
            bool A = Support.MostWanted.LoadData.LoadVaults(GlobalDir);
            bool B = Support.MostWanted.LoadData.LoadGlobalA(GlobalDir, database);
            bool C = Support.MostWanted.LoadData.LoadGlobalB(GlobalDir, database);
            bool D = Support.MostWanted.LoadData.LoadLanguage(GlobalDir, database);
            return A && B && C && D;
        }

        /// <summary>
        /// Loads data from Global files in the directory chosen.
        /// </summary>
        /// <param name="database">MostWanted database to be loaded into.</param>
        /// <returns>True if loading was successful.</returns>
        public static bool LoadData(Database.Underground2 database)
        {
            if (Set != (int)GameINT.Underground2)
            {
                if (MessageShow)
                    System.Windows.Forms.MessageBox.Show("Game set is not valid for MostWanted database load.", "Warning");
                else
                    System.Console.WriteLine("Game set is not valid for MostWanted database load.");
                return false;
            }
            Initialize.InitUG2();
            bool A = Support.Underground2.LoadData.LoadLanguage(GlobalDir, database);
            bool B = Support.Underground2.LoadData.LoadAudios(GlobalDir);
            bool C = Support.Underground2.LoadData.LoadWheels(GlobalDir);
            bool D = Support.Underground2.LoadData.LoadGlobalA(GlobalDir, database);
            bool E = Support.Underground2.LoadData.LoadGlobalB(GlobalDir, database);
            return A && B && C && D && E;
        }

        /// <summary>
        /// Saves data into Global files in the directory chosen.
        /// </summary>
        /// <param name="database">Carbon database of classes.</param>
        /// <param name="compressed">Compress GlobalB file on the output.</param>
        /// <returns>True if game is supported.</returns>
        public static bool SaveData(Database.Carbon database, bool compressed)
        {
            if (Set != (int)GameINT.Carbon)
            {
                if (MessageShow)
                    System.Windows.Forms.MessageBox.Show("Game set is not valid for Carbon database load.", "Warning");
                else
                    System.Console.WriteLine("Game set is not valid for Carbon database load.");
                return false;
            }
            bool A = Support.Carbon.SaveData.SaveGlobalA(GlobalDir, database);
            bool B = Support.Carbon.SaveData.SaveGlobalB(GlobalDir, database);
            bool C = Support.Carbon.SaveData.SaveLanguage(GlobalDir, database);
            if (B && compressed) CompressFiles();
            return A && B && C;
        }

        /// <summary>
        /// Saves data into Global files in the directory chosen.
        /// </summary>
        /// <param name="database">MostWanted database of classes.</param>
        /// <param name="compressed">Compress GlobalB file on the output.</param>
        /// <returns>True if game is supported.</returns>
        public static bool SaveData(Database.MostWanted database, bool compressed)
        {
            if (Set != (int)GameINT.MostWanted)
            {
                if (MessageShow)
                    System.Windows.Forms.MessageBox.Show("Game set is not valid for MostWanted database load.", "Warning");
                else
                    System.Console.WriteLine("Game set is not valid for MostWanted database load.");
                return false;
            }
            bool A = Support.MostWanted.SaveData.SaveGlobalA(GlobalDir, database);
            bool B = Support.MostWanted.SaveData.SaveGlobalB(GlobalDir, database);
            bool C = Support.MostWanted.SaveData.SaveLanguage(GlobalDir, database);
            if (B && compressed) CompressFiles();
            return A && B && C;
        }

        /// <summary>
        /// Saves data into Global files in the directory chosen.
        /// </summary>
        /// <param name="database">MostWanted database of classes.</param>
        /// <param name="compressed">Compress GlobalB file on the output.</param>
        /// <returns>True if game is supported.</returns>
        public static bool SaveData(Database.Underground2 database, bool compressed)
        {
            if (Set != (int)GameINT.Underground2)
            {
                if (MessageShow)
                    System.Windows.Forms.MessageBox.Show("Game set is not valid for MostWanted database load.", "Warning");
                else
                    System.Console.WriteLine("Game set is not valid for MostWanted database load.");
                return false;
            }
            bool A = Support.Underground2.SaveData.SaveGlobalA(GlobalDir, database);
            bool B = Support.Underground2.SaveData.SaveGlobalB(GlobalDir, database);
            bool C = Support.Underground2.SaveData.SaveLanguage(GlobalDir, database);
            if (B && compressed) CompressFiles();
            return A && B && C;
        }

        /// <summary>
        /// Compressed GlobalB file.
        /// </summary>
        private static void CompressFiles()
        {
            string dirB = GlobalDir + @"\GLOBAL\GlobalB.lzc";
            using (var ms = new System.IO.MemoryStream(System.IO.File.ReadAllBytes(dirB)))
            using (var bw = new System.IO.BinaryWriter(System.IO.File.Open(dirB, System.IO.FileMode.Create)))
            {
                bw.Write(Utils.JDLZ.Compress(ms.ToArray()));
            }
        }
    }

    /// <summary>
    /// Contains game process enumeration.
    /// </summary>
    public enum GameINT : int
    {
        Carbon = 1,
        MostWanted = 2,
        Underground2 = 3,
    }

    public static class GameSTR
    {
        public const string Carbon = "Carbon";
        public const string MostWanted = "MostWanted";
        public const string Underground2 = "Underground2";
    }
}
