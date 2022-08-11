using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using EMES.Forms;
using System.Threading;

namespace EMES
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        //static void Main()
        //{
        //    Application.EnableVisualStyles();
        //    Application.SetCompatibleTextRenderingDefault(false);


        //    Application.Run(new Login());//系統登入畫面
        //}
        static void Main()
        {
            bool isFirstOpen;
            Mutex mutex = new Mutex(false, Application.ProductName, out isFirstOpen);
            if (isFirstOpen)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                //Application.Run(new wfdwk());
                Application.Run(new Login());//系統登入畫面
            }
            else
            {
                MessageBox.Show("重複開啟!");
            }
            mutex.Dispose();
        }
    }
}
