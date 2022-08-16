using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EMES.Models;
using EMES.Forms;

using System.Data;
using System.Reflection;
using System.Net.Sockets;
using System.Net;

namespace EMES
{
    /// <summary>
    /// 所有視窗的設定寫在這裡
    /// </summary>
    public class Config
    {   
        
        // <summary>
        /// 設定視窗為根據桌面調整大小;並禁止改變 
        /// </summary>
        //public static void SetFormSize(Form Fm, string Type)
        //{
        //    int DeskWidth = Screen.PrimaryScreen.WorkingArea.Width;     //畫面寬
        //    int DeskHeight = Screen.PrimaryScreen.WorkingArea.Height;   //畫面高
        //    decimal Resize = 0.9M; //畫面縮放比
        //    //DeskWidth = 1440;
        //    //DeskHeight = 900;
        //    if (DeskWidth < 1280)
        //    {
        //        Config.Show("螢幕解析度設定太低，畫面會顯示不完全，程式無法執行，請聯絡電腦室。");
        //        Application.Exit();
        //    }

        //    switch (DeskWidth)
        //    {
        //        case 1920:
        //            Fm.Font = new Font("新細明體", 11);
        //            break;
        //        case 1680:
        //            Fm.Font = new Font("新細明體", 11);
        //            Resize = 0.95M;
        //            break;
        //        case 1600:
        //            Fm.Font = new Font("新細明體", 11);
        //            Resize = 0.95M;
        //            break;
        //        case 1440:
        //            Fm.Font = new Font("新細明體", 11);
        //            Resize = 1;
        //            break;
        //        case 1366:
        //            Fm.Font = new Font("新細明體", 10);
        //            Resize = 1;
        //            break;
        //        case 1360:
        //            Fm.Font = new Font("新細明體", 9);
        //            Resize = 1;
        //            break;
        //        case 1280:
        //            Fm.Font = new Font("新細明體", 9);
        //            Resize = 1;
        //            break;
        //        default:
        //            Fm.Font = new Font("新細明體", 10);
        //            Resize = 1;
        //            break;
        //    }
        //    Fm.Width = System.Convert.ToInt32(DeskWidth * Resize);
        //    Fm.Height = System.Convert.ToInt32(DeskHeight * Resize);
        //    Fm.StartPosition = FormStartPosition.CenterScreen;
        //    Fm.FormBorderStyle = FormBorderStyle.FixedDialog;
        //    Fm.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
        //    if (Type == "F") //維護畫面
        //    {
        //        Fm.MaximizeBox = false;
        //        Fm.ControlBox = false;
        //    }
        //    if (Type == "R" || Type == "Q" || Type == "W") //報表主畫面R;或維護畫面查詢Q;或開窗下拉畫面W
        //    {
        //        if (Type == "Q")
        //        {
        //            Fm.Width = System.Convert.ToInt32(Screen.PrimaryScreen.WorkingArea.Width * 0.45);
        //            Fm.Height = System.Convert.ToInt32(Screen.PrimaryScreen.WorkingArea.Height * 0.3);
        //        }
        //        if (Type == "W")
        //        {
        //            Fm.Width = System.Convert.ToInt32(Screen.PrimaryScreen.WorkingArea.Width * 0.35);
        //            Fm.Height = System.Convert.ToInt32(Screen.PrimaryScreen.WorkingArea.Height * 0.40);
        //        }
        //        Fm.MaximizeBox = false;
        //        Fm.MinimizeBox = false;
        //    }
        //    if (Type == "M") //選單
        //    {
        //        Fm.ControlBox = false;//保留邊框;把最大控制,小等的控制項取消
        //    }
        //    if (Type == "F" || Type == "R")
        //    {
        //        Fm.Text = string.Format("{0}－{1}", Fm.Text, Login.DB == 1 ? "正式區" : "測試區");
        //    }

        //    setTag(Fm);
        //}

        public static void SetFormSize(Form Fm, string Type)
        {
            int DeskWidth = Screen.PrimaryScreen.WorkingArea.Width;     //畫面寬
            int DeskHeight = Screen.PrimaryScreen.WorkingArea.Height;   //畫面高
            decimal Resize = 0.9M; //畫面縮放比
            //DeskWidth = 1440;
            //DeskHeight = 900;
            if (DeskWidth < 1280)
            {
                Config.Show("螢幕解析度設定太低，畫面會顯示不完全，程式無法執行，請聯絡電腦室。");
                Application.Exit();
            }

            switch (DeskWidth)
            {
                case 1920:
                    Fm.Font = new Font("新細明體", 11);
                    break;
                case 1680:
                    Fm.Font = new Font("新細明體", 11);
                    Resize = 0.95M;
                    break;
                case 1600:
                    Fm.Font = new Font("新細明體", 11);
                    Resize = 0.95M;
                    break;
                case 1440:
                    Fm.Font = new Font("新細明體", 11);
                    Resize = 1;
                    break;
                case 1366:
                    Fm.Font = new Font("新細明體", 10);
                    Resize = 1;
                    break;
                case 1360:
                    Fm.Font = new Font("新細明體", 9);
                    Resize = 1;
                    break;
                case 1280:
                    Fm.Font = new Font("新細明體", 9);
                    Resize = 1;
                    break;
                default:
                    Fm.Font = new Font("新細明體", 10);
                    Resize = 1;
                    break;
            }
            Fm.Width = System.Convert.ToInt32(DeskWidth * Resize);
            Fm.Height = System.Convert.ToInt32(DeskHeight * Resize);
            Fm.StartPosition = FormStartPosition.CenterScreen;
            Fm.FormBorderStyle = FormBorderStyle.FixedDialog;
            Fm.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            if (Type == "F") //維護畫面
            {
                Fm.MaximizeBox = false;
                Fm.ControlBox = false;
            }
            if (Type == "R" || Type == "Q" || Type == "W") //報表主畫面R;或維護畫面查詢Q;或開窗下拉畫面W
            {
                if (Type == "Q")
                {
                    Fm.Width = System.Convert.ToInt32(Screen.PrimaryScreen.WorkingArea.Width * 0.25);
                    Fm.Height = System.Convert.ToInt32(Screen.PrimaryScreen.WorkingArea.Height* 0.25);                    
                }
                if (Type == "W")
                {
                    Fm.Width = System.Convert.ToInt32(Screen.PrimaryScreen.WorkingArea.Width * 0.25);
                    Fm.Height = System.Convert.ToInt32(Screen.PrimaryScreen.WorkingArea.Height * 0.5);
                }
                Fm.MaximizeBox = false;
                Fm.MinimizeBox = false;
            }
            if (Type == "M") //選單
            {
                Fm.ControlBox = false;//保留邊框;把最大控制,小等的控制項取消
            }
            if (Type == "F" || Type == "R")
            {
                Fm.Text = string.Format("{0}－{1}", Fm.Text, Login.DB == 1 ? "正式區" : "測試區");
            }

            setTag(Fm);
        }

        private static void setTag(Control cons)
        {
            foreach (Control con in cons.Controls)
            {
                con.Tag = con.Width + ":" + con.Height + ":" + con.Left + ":" + con.Top + ":" + con.Font.Size;
                if (con.Controls.Count > 0)
                    setTag(con);
            }
        }

        //public static void SetFormSize(Form Fm, string Type)
        //{
        //    int DeskWidth = Screen.PrimaryScreen.WorkingArea.Width;
        //    int DeskHeight = Screen.PrimaryScreen.WorkingArea.Height;
        //    DeskWidth = 1440;
        //    if (DeskWidth < 1280)
        //    {
        //        Config.Show("螢幕解析度設定太低，畫面會顯示不完全，程式無法執行，請聯絡電腦室。");
        //        Application.Exit();
        //    }
        //    switch (DeskWidth)
        //    {
        //        case 1920:
        //            Fm.Font = new Font("新細明體", 11);
        //            break;
        //        case 1680:
        //            Fm.Font = new Font("新細明體", 10.5f);
        //            break;
        //        case 1600:
        //            Fm.Font = new Font("新細明體", 10);
        //            break;
        //        case 1440:
        //            Fm.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
        //            Fm.AutoSize = false;
        //            Fm.Font = new Font("新細明體", 10);
        //            break;
        //        case 1366:
        //            Fm.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
        //            Fm.AutoSize = false;
        //            Fm.Font = new Font("Lucida Fax", 9);
        //            break;
        //        case 1360:
        //            Fm.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
        //            Fm.AutoSize = false;
        //            Fm.Font = new Font("Lucida Fax", 9);
        //            break;
        //        case 1280:
        //            Fm.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
        //            Fm.AutoSize = false;
        //            Fm.Font = new Font("Lucida Fax", 9);
        //            break;
        //        default:
        //            Fm.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
        //            Fm.AutoSize = false;
        //            Fm.Font = new Font("新細明體", 10);
        //            break;
        //    }

        //    Fm.Width = System.Convert.ToInt32(DeskWidth * 0.90);
        //    Fm.Height = System.Convert.ToInt32(DeskHeight * 0.90);
        //    Fm.StartPosition = FormStartPosition.CenterScreen;
        //    Fm.FormBorderStyle = FormBorderStyle.FixedDialog;
        //    if (Type == "F") //維護畫面
        //    {
        //        Fm.MaximizeBox = false;
        //        Fm.ControlBox = false;
        //    }
        //    if (Type == "R" || Type == "Q" || Type == "W") //報表主畫面R;或維護畫面查詢Q;或開窗下拉畫面W
        //    {
        //        if (Type == "Q" || Type == "W")
        //        {
        //            Fm.Width = System.Convert.ToInt32(DeskWidth * 0.35);
        //            Fm.Height = System.Convert.ToInt32(DeskHeight * 0.40);
        //        }
        //        Fm.MaximizeBox = false;
        //        Fm.MinimizeBox = false;
        //    }
        //    if (Type == "M") //選單
        //    {
        //        Fm.ControlBox = false;//保留邊框;把最大控制,小等的控制項取消
        //    }
        //    if (Type == "F" || Type == "R")
        //    {
        //        Fm.Text = string.Format("{0}－{1}", Fm.Text, Conn.GetName(Login.DB));
        //    }


        //}




        public static void SetPer(Form Fm)
        {            
            // 找出字體大小,並算出比例
            float dpiX, dpiY;
            Graphics graphics = Fm.CreateGraphics();
            dpiX = graphics.DpiX;
            dpiY = graphics.DpiY;
            int intPercent = (dpiX == 96) ? 100 : (dpiX == 120) ? 125 : 150; 
            float Per = intPercent / 100;
            
            //電腦螢幕字體如果有變大;怕畫面會擠不下去;所以設定為10
            if (Per >1)                
                Fm.Font = new Font("新細明體", 10);
        }

        public static void TextReadOnly(TextBox e)
        {
            //清空欄位
            e.Text = string.Empty;
            //先將原本的BackColor取出來
            Color backColor = e.BackColor;
            //設定ReadOnly=true
            e.ReadOnly = true;
            //把原本的BackColor Assign回去    
            e.BackColor = backColor;
            //固定白色
            //e.BackColor = Color.White;
        }

        /// <summary>
        /// 訊息視窗,出現確認,取消
        /// </summary>
        /// <param name="Msg"></param>
        /// <returns></returns>
        public static string Message(string Msg)
        {            
            var ans = "";
            DialogResult result = MessageBox.Show(Msg, "訊息", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
                ans = "Y";
            if (result == DialogResult.Cancel)
                ans = "N";
            return ans;
        }

        /// <summary>
        /// 訊息視窗,只回應確定
        /// </summary>
        /// <param name="Msg"></param>
        public static void Show(string Msg)
        {
            MessageBox.Show(Msg, "訊息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        /// <summary>
        /// 設定DateTimePicker 日期
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="vd"></param>
        public static void Set_DateTo(DateTimePicker dt, string vd)
        {
            if (vd == null || vd == "" || vd == " ")
            {
                dt.Format = DateTimePickerFormat.Custom;
                dt.CustomFormat = " ";
            }
            else
            {
                dt.Format = DateTimePickerFormat.Custom;
                dt.CustomFormat = vd;
                dt.Value = DateTime.Parse(vd);
            }
        }

        public static void FontBlod(Control ctl_false, bool Blod)
        {
            foreach (Control c in ctl_false.Controls)
            {
                FontBlod(c, true);
                var fm = new FontFamily(c.Font.Name);//控制項字型
                var fs = c.Font.Size;//控制項字體大小
                if (c is TextBox)
                {
                    if (Blod == true)
                    {
                        c.Font = new Font(fm, fs, FontStyle.Bold);//加粗
                    }
                    else
                    {
                        c.Font = new Font(fm, fs, FontStyle.Regular);//一般
                    }
                }
                if (c is NumericUpDown)
                {
                    if (Blod == true)
                    {
                        c.Font = new Font(fm, fs, FontStyle.Bold);//加粗
                    }
                    else
                    {
                        c.Font = new Font(fm, fs, FontStyle.Regular);//一般
                    }
                }
                if (c is ComboBox)
                {
                    if (Blod == true)
                    {
                        c.Font = new Font(fm, fs, FontStyle.Bold);//加粗
                    }
                    else
                    {
                        c.Font = new Font(fm, fs, FontStyle.Regular);//一般
                    }
                }
                if (c is DateTimePicker)
                {
                    if (Blod == true)
                    {
                        c.Font = new Font(fm, fs, FontStyle.Bold);//加粗
                    }
                    else
                    {
                        c.Font = new Font(fm, fs, FontStyle.Regular);//一般
                    }
                }
            }
        }



        public static void Control_Click(object sender, EventArgs e)
        {
            if (sender is NumericUpDown)
            {
                ((NumericUpDown)sender).Select(0, 8);
                ((NumericUpDown)sender).Focus();
                ((NumericUpDown)sender).BackColor = Color.Beige;
            }
            if (sender is TextBox)
            {                
                ((TextBox)sender).BackColor = Color.Beige;
            }
            if (sender is ComboBox)
            {
                ((ComboBox)sender).BackColor = Color.Beige;
            }
            if (sender is DateTimePicker)
            {
                ((DateTimePicker)sender).BackColor = Color.Beige;
            }
             if (sender is CheckBox)
            {
                ((CheckBox)sender).BackColor = Color.Beige;
            }
        }

        public static void Control_Leave(object sender, EventArgs e)
        {            
            if (sender is NumericUpDown)
                ((NumericUpDown)sender).BackColor = Color.White;
            if (sender is TextBox)
                ((TextBox)sender).BackColor = Color.White;
            if (sender is ComboBox)
                ((ComboBox)sender).BackColor = Color.White;
            if (sender is DateTimePicker)
                ((DateTimePicker)sender).BackColor = Color.White;
            if (sender is CheckBox)
                ((CheckBox)sender).BackColor = Color.White;
        }

        public static DataTable LinqQueryToDataTable<T>(IEnumerable<T> query)
        {
            DataTable tbl = new DataTable();
            PropertyInfo[] props = null;
            foreach (T item in query)
            {
                if (props == null) //尚未初始化
                {
                    Type t = item.GetType();
                    props = t.GetProperties();
                    foreach (PropertyInfo pi in props)
                    {
                        Type colType = pi.PropertyType;
                        //針對Nullable<>特別處理
                        if (colType.IsGenericType && colType.GetGenericTypeDefinition() == typeof(Nullable<>))
                        {
                            colType = colType.GetGenericArguments()[0];
                        }
                        //建立欄位
                        tbl.Columns.Add(pi.Name, colType);
                    }
                }
                DataRow row = tbl.NewRow();
                foreach (PropertyInfo pi in props)
                {
                    row[pi.Name] = pi.GetValue(item, null) ?? DBNull.Value;
                }
                tbl.Rows.Add(row);
            }
            return tbl;
        }

        //判斷網站port是否存在
        public static bool ApiCheck(string IPStr, int Port, int Timeout)
        {
            bool success = false;
            try
            {
                using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
                    success = socket.BeginConnect(IPAddress.Parse(IPStr), Port, null, null).AsyncWaitHandle.WaitOne(Timeout, true);
            }
            catch { }
            return success;
        }

    }
}
