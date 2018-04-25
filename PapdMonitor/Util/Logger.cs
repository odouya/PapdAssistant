using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PapdMonitor.Util
{
    class Logger
    {
        private static string LogFile;
        private static StreamWriter sw;
        private static bool isInit = false;

        static Logger()
        {
            try
            {
                InitLogger();
            }
            catch 
            {
                
            }
        }

        static void InitLogger()
        {
            if (isInit)
                return;

            LogFile = Path.Combine(Environment.CurrentDirectory, @"Log\" + DateTime.Now.ToString("yyyyMMdd HHmmss") + ".log");
            var dir = Path.GetDirectoryName(LogFile);
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            sw = new StreamWriter(LogFile, true);
            sw.AutoFlush = true;

            isInit = true;
        }

        public static void Write(string info)
        {
            try
            {
                lock (sw)
                {
                    sw.WriteLine(DateTime.Now.ToString("u") + "\t" + info); 
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
