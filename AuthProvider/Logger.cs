using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace AuthProvider
{
    public class Logger
    {
        private const string Path = "logfile.txt";

        public static void LogInfo(string logMessage)
        {
            using (StreamWriter writer = new StreamWriter(Path, true))
            {
                writer.WriteLine("Info:  " + logMessage + " - " + DateTime.Now.ToString());
                writer.Close();
            }
        }
        public static void LogError(string logMessage)
        {
            using (StreamWriter writer = new StreamWriter(Path, true))
            {
                writer.WriteLine("Error:  " + logMessage + " - " + DateTime.Now.ToString());
                writer.Close();
            }
        }
    }
}
