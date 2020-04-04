using System.IO;
using GlobalLib.Utils;
using GlobalLib.Reflection.Abstract;



namespace GlobalLib.Core
{
    /// <summary>
    /// Defines the game process set during the run of the application.
    /// </summary>
    public static class Process
    {
        /// <summary>
        /// If true, enables showing message boxes when exceptions are being thrown.
        /// </summary>
        public static bool MessageShow { get; set; }

        /// <summary>
        /// Watermark that will be written in the files on saving.
        /// </summary>
        public static string Watermark { get; set; } = $"GlobalLib by MaxHwoy";

        /// <summary>
        /// Loads data from Global files in the directory chosen.
        /// </summary>
        /// <param name="db"><see cref="BasicBase"/> where data should be loaded.</param>
        /// <param name="dir">Directory of the game.</param>
        /// <returns>True on success; false otherwise.</returns>
        public static bool LoadData(BasicBase db, string dir)
        {
            bool done = true;

            switch (db.GameINT)
            {
                case GameINT.Carbon:
                    Initialize.Init();
                    done &= Support.Carbon.LoadData.LoadVaults(dir);
                    done &= Support.Carbon.LoadData.LoadLanguage(dir, (Database.Carbon)db);
                    done &= Support.Carbon.LoadData.LoadGlobalA(dir, (Database.Carbon)db);
                    done &= Support.Carbon.LoadData.LoadGlobalB(dir, (Database.Carbon)db);
                    return done;

                case GameINT.MostWanted:
                    Initialize.Init();
                    done &= Support.MostWanted.LoadData.LoadVaults(dir);
                    done &= Support.MostWanted.LoadData.LoadLanguage(dir, (Database.MostWanted)db);
                    done &= Support.MostWanted.LoadData.LoadGlobalA(dir, (Database.MostWanted)db);
                    done &= Support.MostWanted.LoadData.LoadGlobalB(dir, (Database.MostWanted)db);
                    return done;

                case GameINT.Underground2:
                    Initialize.InitUG2();
                    done &= Support.Underground2.LoadData.LoadLanguage(dir, (Database.Underground2)db);
                    done &= Support.Underground2.LoadData.LoadAudios(dir);
                    done &= Support.Underground2.LoadData.LoadWheels(dir);
                    done &= Support.Underground2.LoadData.LoadGlobalA(dir, (Database.Underground2)db);
                    done &= Support.Underground2.LoadData.LoadGlobalB(dir, (Database.Underground2)db);
                    return done;

                default:
                    return false;
            }
        }

        /// <summary>
        /// Saves data into Global files in the directory chosen.
        /// </summary>
        /// <param name="db"><see cref="BasicBase"/> from where data should be unloaded.</param>
        /// <param name="dir">Directory of the game.</param>
        /// <param name="compressed">True if compress GlobalB file on the output; false otherwise.</param>
        /// <returns>True on success; false otherwise.</returns>
        public static bool SaveData(BasicBase db, string dir, bool compressed)
        {
            bool done = true;

            switch (db.GameINT)
            {
                case GameINT.Carbon:
                    done &= Support.Carbon.SaveData.SaveGlobalA(dir, (Database.Carbon)db);
                    done &= Support.Carbon.SaveData.SaveGlobalB(dir, (Database.Carbon)db);
                    done &= Support.Carbon.SaveData.SaveLanguage(dir, (Database.Carbon)db);
                    if (done && compressed) CompressFiles(dir);
                    return done;

                case GameINT.MostWanted:
                    done &= Support.MostWanted.SaveData.SaveGlobalA(dir, (Database.MostWanted)db);
                    done &= Support.MostWanted.SaveData.SaveGlobalB(dir, (Database.MostWanted)db);
                    done &= Support.MostWanted.SaveData.SaveLanguage(dir, (Database.MostWanted)db);
                    if (done && compressed) CompressFiles(dir);
                    return done;

                case GameINT.Underground2:
                    done &= Support.Underground2.SaveData.SaveGlobalA(dir, (Database.Underground2)db);
                    done &= Support.Underground2.SaveData.SaveGlobalB(dir, (Database.Underground2)db);
                    done &= Support.Underground2.SaveData.SaveLanguage(dir, (Database.Underground2)db);
                    if (done && compressed) CompressFiles(dir);
                    return done;

                default:
                    return false;
            }
        }

        /// <summary>
        /// Compressed GlobalB file.
        /// </summary>
        private static void CompressFiles(string dir)
        {
            string dirB = dir + @"\GLOBAL\GlobalB.lzc";
            using (var ms = new MemoryStream(File.ReadAllBytes(dirB)))
            using (var bw = new BinaryWriter(File.Open(dirB, FileMode.Create)))
            {
                bw.Write(JDLZ.Compress(ms.ToArray()));
            }
        }
    }
}
