using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace EMES.Models
{
 public   class LogRecord
    {
        public static void WriteLog(string logMsg)
        {
            string DIRNAME = Application.StartupPath + @"\Log\";
            string FILENAME = DIRNAME + DateTime.Now.ToString("yyyy-MM-ddhh") + ".txt";

            if (!Directory.Exists(DIRNAME))
                Directory.CreateDirectory(DIRNAME);

            if (!File.Exists(FILENAME))
            {
                // The File.Create method creates the file and opens a FileStream on the file. You neeed to close it.
                File.Create(FILENAME).Close();
            }
            DateTime dt = DateTime.Now;
            using (StreamWriter sw = File.AppendText(FILENAME))
            {
                sw.Write("<---" + dt.ToString("yyyy-MM-dd HH:mm:ss.fff") + "-->");
                sw.WriteLine(logMsg);
                sw.WriteLine("");
            }
        }



        //private static void Log(string logMessage, TextWriter w)
        //{
        //    w.Write("\r\nLog Entry : ");
        //    w.WriteLine("{0}", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff"));
        //    //w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString()); 
        //    w.WriteLine("  :");
        //    w.WriteLine("  :{0}", logMessage);
        //    w.WriteLine("-------------------------------");
        //}


        //public static void WriteLog(string logMsg)
        //{
        //    string logPath = Application.StartupPath + @"\Logs\";

        //    if (!Directory.Exists(logPath))
        //        Directory.CreateDirectory(logPath);
        //    DateTime dt = DateTime.Now;
        //    string logFileName = string.Format("Logquery-{0}.txt", dt.ToString("yyyy-MM-ddhh"));
        //    try
        //    {
        //        using (StreamWriter sw = File.AppendText(logPath + "\\" + logFileName))
        //        {
        //            //WriteLine為換行 
        //            sw.Write("<---" + dt.ToString("yyyy-MM-dd hh:mm:ss") + "-->");
        //            sw.WriteLine(logMsg);
        //            sw.WriteLine("");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //}

    }
}
