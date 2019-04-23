using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SavingSettigns
{
    class Logger
    {
        private static string path = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "\\Logs\\";

        public static void WriteToFile(string message)
        {
            if (path != null)
            {
                try
                {
                    string dir = Path.GetDirectoryName(path);
                    if (dir != null)
                    {
                        if (!Directory.Exists(dir))
                            Directory.CreateDirectory(dir);
                        StreamWriter sw = new StreamWriter(path + "ApplicationLog " + DateTime.Today.ToString("dd-MM-yyyy") + ".txt", true);
                        sw.WriteLine(DateTime.Now.ToString("dd/MM/yyyy, HH:mm:ss") + " " + message);
                        sw.Flush();
                        sw.Close();
                    }
                }
                catch (Exception ex) { }
            }
        }
    }
}
