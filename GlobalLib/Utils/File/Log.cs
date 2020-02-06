using System;
using System.IO;



namespace GlobalLib.Utils
{
    /// <summary>
    /// Collection for writing log strings that occur during the runtime.
    /// </summary>
    public static class Log
    {
        /// <summary>
        /// Enable writing actions passed to the filename specified.
        /// </summary>
        public static bool EnableLog { get; set; } = false;

        /// <summary>
        /// Enable writing time stamps at which action was executed.
        /// </summary>
        public static bool EnableTimeWrite { get; set; } = false;

        /// <summary>
        /// Name of the file where write actions passed.
        /// </summary>
        public static string FileName { get; set; } = "Log.log";

        /// <summary>
        /// Write action string passed to the filename specified.
        /// </summary>
        /// <param name="LogEntry">String to write.</param>
        public static void Write(string LogEntry)
        {
            if (!File.Exists(FileName))
                File.Create(FileName);

            if (EnableLog)
            {
                try
                {
                    using (var LogWriter = new StreamWriter(File.Open(FileName, FileMode.Append)))
                    {
                        if (EnableTimeWrite)
                            LogWriter.Write($"[{DateTime.Now.ToString()}] : {LogEntry}" + Environment.NewLine);
                        else
                            LogWriter.Write(LogEntry + Environment.NewLine);
                    }
                }
                catch (Exception)
                {
                    EnableLog = false;
                }
            }
        }

        /// <summary>
        /// Write action strings passed to the filename specified.
        /// </summary>
        /// <param name="LogEntries">Strings to write.</param>
        public static void Write(string[] LogEntries)
        {
            if (!File.Exists(FileName))
                File.Create(FileName);

            if (EnableLog)
            {
                try
                {
                    using (var LogWriter = new StreamWriter(File.Open(FileName, FileMode.Append)))
                    {
                        foreach (var LogEntry in LogEntries)
                        {
                            if (EnableTimeWrite)
                                LogWriter.Write($"[{DateTime.Now.ToString()}] : {LogEntry}" + Environment.NewLine);
                            else
                                LogWriter.Write(LogEntry + Environment.NewLine);
                        }
                    }
                }
                catch (Exception)
                {
                    EnableLog = false;
                }
            }
        }
    }
}